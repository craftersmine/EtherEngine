using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Core;

namespace craftersmine.EtherEngine.Objects
{
    /// <summary>
    /// Represents particle system. This class cannot be inherited
    /// </summary>
    public sealed class ParticleSystem : GameObject
    {
        internal List<Particle> Particles { get; set; } = new List<Particle>();
        
        private Random SizeRanger = new Random();
        private Random ParticleLifetimeRanger = new Random();

        /// <summary>
        /// Gets or sets particle lifetime
        /// </summary>
        public int ParticleLifetime { get; set; }
        /// <summary>
        /// Gets or sets particle size
        /// </summary>
        public int ParticleSize { get; set; }
        /// <summary>
        /// Gets or sets true if particles must have variative size, else false
        /// </summary>
        public bool IsParticleVariativeSize { get; set; }
        /// <summary>
        /// Gets used particle instance
        /// </summary>
        public Particle Particle { get; private set; }
        /// <summary>
        /// Gets current max particles limitation
        /// </summary>
        public int MaxParticles { get; private set; }
        /// <summary>
        /// Gets true if particle system is emitting particles, else false
        /// </summary>
        public bool IsEmitting { get; private set; }
        /// <summary>
        /// Gets or sets particle on update behaviour
        /// </summary>
        public ParticleOnUpdateAction OnUpdateAction { get; set; }

        public ParticleBehaviour ParticleBehaviour { get; set; }

        /// <summary>
        /// Creates new <see cref="ParticleSystem"/> instance with specified parameters
        /// </summary>
        /// <param name="particle">Particle template</param>
        /// <param name="particleLifetime">Particle lifetime</param>
        /// <param name="maxParticles">Maximum particles limitaion</param>
        /// <param name="particleBehaviour">Particle behaviour</param>
        /// <param name="particleSize">Particle size</param>
        /// <param name="variativeSize">True if particles must have variative size, else false</param>
        public ParticleSystem(Particle particle, ParticleBehaviour particleBehaviour, int particleLifetime, int maxParticles, int particleSize, bool variativeSize)
        {
            Particle = particle;
            ParticleLifetime = particleLifetime;
            ParticleSize = particleSize;
            IsParticleVariativeSize = variativeSize;
            ParticleBehaviour = particleBehaviour;
            MaxParticles = maxParticles;
            Collidable = false;
        }
        
        /// <summary>
        /// Calls when particle system being created
        /// </summary>
        public override void OnStart()
        {
            for (int i = 0; i < MaxParticles * 2; i++)
            {
                Particle particle = Particle.Clone();
                particle.Visible = false;
                particle.Width = ParticleSize;
                particle.Height = ParticleSize;
                particle.X = this.X;
                particle.Y = this.Y;
                particle.CurrentLifetime = ParticleLifetimeRanger.Next(-15, 0) - i;
                Particles.Add(particle);
            }
            Reset();
        }

        /// <summary>
        /// Start emit particles
        /// </summary>
        public void Emit()
        {
            if (!IsEmitting)
            {
                Reset();
                SceneManager.CurrentScene.AddGameObjects(Particles);
                IsEmitting = true;
            }
        }

        /// <summary>
        /// Stop emit particles
        /// </summary>
        public void StopEmit()
        {
            if (IsEmitting)
            {
                for (int i = 0; i < Particles.Count; i++)
                {
                    Reset();
                    SceneManager.CurrentScene.RemoveGameObject(Particles[i]);
                }
                IsEmitting = false;
            }
        }

        public void EmitOnce()
        {
            Emit();
            StopEmit();
            Reset();
        }

        /// <summary>
        /// Reset particles
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < Particles.Count; i++)
            {
                Particles[i].Visible = false;
                Particles[i].IsParticleLifetimeElapsed = true;
                Particles[i].Width = ParticleSize;
                Particles[i].Height = ParticleSize;
                Particles[i].X = this.X;
                Particles[i].Y = this.Y;
                Particles[i].CurrentLifetime = ParticleLifetimeRanger.Next(-15, 0) - i;
            }
        }

        /// <summary>
        /// Calls when particle system being updated
        /// </summary>
        public override void OnUpdate(float deltaTime)
        {
            if (IsEmitting)
            {
                for (int i = 0; i < Particles.Count; i++)
                {
                    if (Particles[i].CurrentLifetime <= 0 || Particles[i].IsParticleLifetimeElapsed)
                    {
                        Particles[i].Visible = true;
                        Particles[i].IsParticleLifetimeElapsed = false;
                        if (IsParticleVariativeSize)
                            Particles[i].SizeModifier = (float)SizeRanger.Next(ParticleSize * 2 / 3, ParticleSize) / ParticleSize;
                        Particles[i].Width = (int)((float)ParticleSize * Particles[i].SizeModifier);
                        Particles[i].Height = (int)((float)ParticleSize * Particles[i].SizeModifier);
                        Particles[i].Lifetime = ParticleLifetime + ParticleLifetimeRanger.Next(-15, 0) - i;
                        Particles[i].CurrentLifetime++;
                    }
                    if (Particles[i].CurrentLifetime < Particles[i].Lifetime || !Particles[i].IsParticleLifetimeElapsed)
                    {
                        ParticleBehaviour.Invoke(Particles[i], deltaTime);
                        Particles[i].CurrentLifetime++;
                    }
                    if (Particles[i].CurrentLifetime >= Particles[i].Lifetime || Particles[i].IsParticleLifetimeElapsed)
                    {
                        Particles[i].Visible = false;
                        Particles[i].IsParticleLifetimeElapsed = true;
                        Particles[i].Width = ParticleSize;
                        Particles[i].Height = ParticleSize;
                        Particles[i].X = this.X;
                        Particles[i].Y = this.Y;
                        Particles[i].CurrentLifetime = ParticleLifetimeRanger.Next(-15, 0) - i;
                    }
                    OnUpdateAction?.Invoke(Particles[i]);
                }
            }
        }
    }

    /// <summary>
    /// Represents particle. This class cannot be inherited
    /// </summary>
    public sealed class Particle : GameObject
    {
        /// <summary>
        /// Gets or sets current particle lifetime
        /// </summary>
        public int CurrentLifetime { get; set; }
        /// <summary>
        /// Gets particle lifetime
        /// </summary>
        public int Lifetime { get; internal set; }
        /// <summary>
        /// Gets or sets particle size
        /// </summary>
        public int ParticleSize { get; set; }
        /// <summary>
        /// Gets or sets true if particle lifetime is elapsed
        /// </summary>
        public bool IsParticleLifetimeElapsed { get; set; }
        /// <summary>
        /// Gets current particle vertical velocity vector
        /// </summary>
        public float VerticalVelocity { get; set; }
        /// <summary>
        /// Gets current particle horizontal velocity vector
        /// </summary>
        public float HorizontalVelocity { get;  set; }
        /// <summary>
        /// Gets particle size modifier
        /// </summary>
        public float SizeModifier { get; internal set; }
        
        /// <summary>
        /// Creates new <see cref="Particle"/> instance
        /// </summary>
        /// <param name="texture">Particle texture</param>
        public Particle(Texture texture)
        {
            Texture = texture;
            CurrentLifetime = 0;
        }

        /// <summary>
        /// Clones particle
        /// </summary>
        /// <returns></returns>
        public Particle Clone()
        {
            return new Particle(Texture) {
                CurrentLifetime = CurrentLifetime,
                Height = Height,
                ParticleSize = ParticleSize,
                Texture = Texture,
                Visible = Visible,
                Width = Width,
                X = X,
                Y = Y,
                HorizontalVelocity = HorizontalVelocity,
                VerticalVelocity = VerticalVelocity,
                SizeModifier = SizeModifier
            };
        }
    }

    /// <summary>
    /// Represents particle OnUpdate behaviour
    /// </summary>
    /// <param name="particle">Updating particle</param>
    public delegate void ParticleOnUpdateAction(Particle particle);

    public delegate void ParticleBehaviour(Particle particle, float deltaTime);
}
