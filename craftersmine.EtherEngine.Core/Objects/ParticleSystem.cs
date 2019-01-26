using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Core;

namespace craftersmine.EtherEngine.Objects
{
    public sealed class ParticleSystem : GameObject
    {
        internal List<Particle> Particles { get; set; } = new List<Particle>();

        private Random HorizVeloRanger = new Random();
        private Random VertVeloRanger = new Random();
        private Random SizeRanger = new Random();
        private Random ParticleLifetimeRanger = new Random();

        public int ParticleLifetime { get; set; }
        public float ParticleVerticalVelocity { get; set; }
        public float ParticleHorizontalVelocity { get; set; }
        public int ParticleSize { get; set; }
        public bool IsParticleVariativeSize { get; set; }
        public Particle Particle { get; private set; }
        public int MaxParticles { get; private set; }
        public bool IsEmitting { get; private set; }

        public ParticleSystem(Particle particle, int particleLifetime, int maxParticles, float particleVerticalVelocity, float particleHorizontalVelocity, int particleSize, bool variativeSize)
        {
            Particle = particle;
            ParticleLifetime = particleLifetime;
            ParticleVerticalVelocity = particleVerticalVelocity;
            ParticleHorizontalVelocity = particleHorizontalVelocity;
            ParticleSize = particleSize;
            IsParticleVariativeSize = variativeSize;
            MaxParticles = maxParticles;
        }

        public override void OnStart()
        {
            for (int i = 0; i < MaxParticles; i++)
            {
                Particle particle = Particle.Clone();
                particle.Visible = false;
                particle.Width = ParticleSize;
                particle.Height = ParticleSize;
                particle.X = this.X;
                particle.Y = this.Y;
                Particles.Add(particle);
            }
            Reset();
        }

        public void Emit()
        {
            Reset();
            SceneManager.CurrentScene.AddGameObjects(Particles);
            IsEmitting = true;
        }

        public void StopEmit()
        {
            for (int i = 0; i < Particles.Count; i++)
            {
                Reset();
                SceneManager.CurrentScene.RemoveGameObject(Particles[i]);
            }
            IsEmitting = false;
        }

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
            }
        }

        public override void OnUpdate()
        {
            if (IsEmitting)
            {
                for (int i = 0; i < Particles.Count; i++)
                {
                    if (Particles[i].CurrentLifetime == 0 || Particles[i].IsParticleLifetimeElapsed)
                    {
                        Particles[i].Visible = true;
                        Particles[i].IsParticleLifetimeElapsed = false;
                        if (IsParticleVariativeSize)
                            Particles[i].SizeModifier = (float)SizeRanger.Next(ParticleSize * 2 / 3, ParticleSize) / ParticleSize;
                        Particles[i].Width = (int)((float)ParticleSize * Particles[i].SizeModifier);
                        Particles[i].Height = (int)((float)ParticleSize * Particles[i].SizeModifier);
                        Particles[i].VerticalVelocity = ParticleVerticalVelocity * (float)VertVeloRanger.Next(1, 4) / 4;
                        Particles[i].HorizontalVelocity = ParticleHorizontalVelocity * (float)HorizVeloRanger.Next(-1, 4) / 4;
                        Particles[i].Lifetime = ParticleLifetime + ParticleLifetimeRanger.Next(-5, 5);
                        Particles[i].CurrentLifetime++;
                    }
                    if (Particles[i].CurrentLifetime < Particles[i].Lifetime || !Particles[i].IsParticleLifetimeElapsed)
                    {
                        Particles[i].X += Particles[i].HorizontalVelocity;
                        Particles[i].Y -= Particles[i].VerticalVelocity;
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
                        Particles[i].CurrentLifetime = 0;
                    }
                }
            }
        }
    }

    public sealed class Particle : GameObject
    {
        public int CurrentLifetime { get; set; }
        public int Lifetime { get; internal set; }
        public int ParticleSize { get; set; }
        public bool IsParticleLifetimeElapsed { get; set; }
        public float VerticalVelocity { get; internal set; }
        public float HorizontalVelocity { get; internal set; }
        public float SizeModifier { get; internal set; }
        
        public Particle(Texture texture)
        {
            Texture = texture;
            CurrentLifetime = 0;
        }

        public Particle Clone()
        {
            return new Particle(Texture) {
                CurrentLifetime = CurrentLifetime, Height = Height, ParticleSize = ParticleSize,
                Texture = Texture, Visible = Visible, Width = Width, X = X, Y = Y,
                HorizontalVelocity = HorizontalVelocity, VerticalVelocity = VerticalVelocity, SizeModifier = SizeModifier };
        }
    }
}
