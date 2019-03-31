using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace craftersmine.EtherEngine.GDK.Editor.Texture
{
    public partial class RGBColorSelector : UserControl
    {
        private List<Color> LastColors;
        private Bitmap paletteData;

        [DefaultValue(typeof(Color), "255,255,255")]
        public Color SelectedColor { get; private set; }
        
        public Bitmap Palette {
            get {
                return paletteData;
            }
            set {
                paletteData = value;
                palette.BackgroundImage = paletteData;
            } }

        [Browsable(true)]
        public event EventHandler SelectedColorChanged;

        public RGBColorSelector()
        {
            InitializeComponent();
            paletteData = (Bitmap)palette.BackgroundImage;
            SelectedColor = Color.White;
            LastColors = new List<Color>(7);
            for (int i = 0; i < 7; i++)
            {
                LastColors.Add(SelectedColor);
            }
            UpdateLastColors(SelectedColor);
            UpdateColor(SelectedColor);
        }

        private void UpdateColor(Color color)
        {
            SelectedColor = color;

            selectedColor.BackColor = SelectedColor;
            redSlider.Value = SelectedColor.R;
            greenSlider.Value = SelectedColor.G;
            blueSlider.Value = SelectedColor.B;
            alphaSlider.Value = SelectedColor.A;
            redValue.Text = SelectedColor.R.ToString();
            greenValue.Text = SelectedColor.G.ToString();
            blueValue.Text = SelectedColor.B.ToString();
            alphaValue.Text = SelectedColor.A.ToString();
            hexademical.Text = "#" + SelectedColor.ToArgb().ToString("X");

            SelectedColorChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateLastColorsVisualization()
        {
            lastColor1.BackColor = LastColors[0];
            lastColor2.BackColor = LastColors[1];
            lastColor3.BackColor = LastColors[2];
            lastColor4.BackColor = LastColors[3];
            lastColor5.BackColor = LastColors[4];
            lastColor6.BackColor = LastColors[5];
            lastColor7.BackColor = LastColors[6];
        }

        private void UpdateLastColors(Color newColor)
        {
            if (LastColors.Count < 6)
            {
                LastColors.Insert(0, newColor);
            }
            else
            {
                LastColors.Remove(LastColors[LastColors.Count - 1]);
                LastColors.Insert(0, newColor);
            }

            UpdateLastColorsVisualization();
        }

        private void palette_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    try
                    {
                        if (e.Location.X > 0 && e.Location.Y > 0 && e.Location.X < ClientSize.Width && e.Location.Y < ClientSize.Height)
                        {
                            UpdateColor(Palette.GetPixel(e.Location.X, e.Location.Y));
                        }
                    }
                    catch
                    {

                    }
                    break;
            }
        }

        private void palette_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    try
                    {
                        if (e.Location.X > 0 && e.Location.Y > 0 && e.Location.X < ClientSize.Width && e.Location.Y < ClientSize.Height)
                        {
                            UpdateColor(Palette.GetPixel(e.Location.X, e.Location.Y));
                        }
                    }
                    catch {
                        
                    }
                    break;
            }
        }

        private void palette_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateLastColors(SelectedColor);
        }

        private void lastColor1_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    UpdateColor(lastColor1.BackColor);
                    break;
                case MouseButtons.Right:
                    lastColor1.BackColor = SelectedColor;
                    LastColors[0] = SelectedColor;
                    UpdateLastColorsVisualization();
                    break;
            }
        }

        private void lastColor2_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    UpdateColor(lastColor2.BackColor);
                    break;
                case MouseButtons.Right:
                    lastColor2.BackColor = SelectedColor;
                    LastColors[1] = SelectedColor;
                    UpdateLastColorsVisualization();
                    break;
            }
        }

        private void lastColor3_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    UpdateColor(lastColor3.BackColor);
                    break;
                case MouseButtons.Right:
                    lastColor3.BackColor = SelectedColor;
                    LastColors[2] = SelectedColor;
                    UpdateLastColorsVisualization();
                    break;
            }
        }

        private void lastColor4_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    UpdateColor(lastColor4.BackColor);
                    break;
                case MouseButtons.Right:
                    lastColor4.BackColor = SelectedColor;
                    LastColors[3] = SelectedColor;
                    UpdateLastColorsVisualization();
                    break;
            }
        }

        private void lastColor5_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    UpdateColor(lastColor5.BackColor);
                    break;
                case MouseButtons.Right:
                    lastColor5.BackColor = SelectedColor;
                    LastColors[4] = SelectedColor;
                    UpdateLastColorsVisualization();
                    break;
            }
        }

        private void lastColor6_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    UpdateColor(lastColor6.BackColor);
                    break;
                case MouseButtons.Right:
                    lastColor6.BackColor = SelectedColor;
                    LastColors[5] = SelectedColor;
                    UpdateLastColorsVisualization();
                    break;
            }
        }

        private void lastColor7_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    UpdateColor(lastColor7.BackColor);
                    break;
                case MouseButtons.Right:
                    lastColor7.BackColor = SelectedColor;
                    LastColors[6] = SelectedColor;
                    UpdateLastColorsVisualization();
                    break;
            }
        }

        private void redValue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(redValue.Text, out int r))
            {
                if (r < 0)
                {
                    r = 0;
                    redValue.Text = "0";
                }
                if (r > 255)
                {
                    r = 255;
                    redValue.Text = "255";
                }
                SelectedColor = Color.FromArgb(SelectedColor.A, r, SelectedColor.G, SelectedColor.B);
                redSlider.Value = r;
                UpdateColor(SelectedColor);
            }
        }

        private void greenValue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(greenValue.Text, out int g))
            {
                if (g < 0)
                {
                    g = 0;
                    greenValue.Text = "0";
                }
                if (g > 255)
                {
                    g = 255;
                    greenValue.Text = "255";
                }
                greenSlider.Value = g;
                SelectedColor = Color.FromArgb(SelectedColor.A, SelectedColor.R, g, SelectedColor.B);
                UpdateColor(SelectedColor);
            }
        }

        private void blueValue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(blueValue.Text, out int b))
            {
                if (b < 0)
                {
                    b = 0;
                    blueValue.Text = "0";
                }
                if (b > 255)
                {
                    b = 255;
                    blueValue.Text = "255";
                }
                blueSlider.Value = b;
                SelectedColor = Color.FromArgb(SelectedColor.A, SelectedColor.R, SelectedColor.G, b);
                UpdateColor(SelectedColor);
            }
        }

        private void alphaValue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(alphaValue.Text, out int a))
            {
                if (a < 0)
                {
                    a = 0;
                    alphaValue.Text = "0";
                }
                if (a > 255)
                {
                    a = 255;
                    alphaValue.Text = "255";
                }
                alphaSlider.Value = a;
                SelectedColor = Color.FromArgb(a, SelectedColor.R, SelectedColor.G, SelectedColor.B);
                UpdateColor(SelectedColor);
            }
        }

        private void redSlider_Scroll(object sender, EventArgs e)
        {
            redValue.Text = redSlider.Value.ToString();
        }

        private void greenSlider_Scroll(object sender, EventArgs e)
        {
            greenValue.Text = greenSlider.Value.ToString();
        }

        private void blueSlider_Scroll(object sender, EventArgs e)
        {
            blueValue.Text = blueSlider.Value.ToString();
        }

        private void alphaSlider_Scroll(object sender, EventArgs e)
        {
            alphaValue.Text = alphaSlider.Value.ToString();
        }
    }
}
