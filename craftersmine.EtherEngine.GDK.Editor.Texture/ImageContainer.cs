using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace craftersmine.EtherEngine.GDK.Editor.Texture
{
    public partial class ImageContainer : UserControl
    {
        private Bitmap imageData;
        private TextureBrush transparentTiling = new TextureBrush(Properties.Resources.transparencyTiling);
        private float zoomFac = 1.0f;

        public new event MouseEventHandler MouseMove;
        public new event MouseEventHandler MouseDown;

        [Browsable(true)]
        public event EventHandler ImageEdited;

        [Browsable(true)]
        public event EventHandler ZoomChanged;

        public Bitmap Image { get { return imageData; } set { imageData = value; UpdateImage(); UpdateCanvas(); ResizeCanvas(); } }

        public Bitmap EditedImage { get { return canvas.RazorBMP; } }

        public bool IsDrawable { get; private set; }

        [DefaultValue(false)]
        public bool EnableDraw { get; set; }

        [DefaultValue(typeof(Size), "256; 256")]
        public Size MaximumEditableImageSize { get; set; }

        [DefaultValue(1.0f)]
        public float ZoomFactor { get { return zoomFac; }
            set 
            {
                if (value > 0.25f || value < 16.0f)
                    zoomFac = value;
                if (value < 0.25f)
                    zoomFac = 0.25f;
                if (value > 16.0f)
                    zoomFac = 16.0f;
                ResizeCanvas(); UpdateImage(); UpdateCanvas();
                ZoomChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool IsImageEdited { get; private set; } = false;

        public ImageContainer()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown?.Invoke(this, e);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove?.Invoke(this, e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateImage();
            UpdateCanvas();
            ResizeCanvas();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UpdateImage();
            UpdateCanvas();
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            UpdateCanvas();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            UpdateCanvas();
        }

        private void ResizeCanvas()
        {
            if (Image == null)
            {
                canvas.Size = Size;
                IsDrawable = false;
            }
            else
            {
                IsDrawable = true;
                int canvasWidth = (int)(Image.Size.Width * ZoomFactor);
                int canvasHeight = (int)(Image.Size.Height * ZoomFactor);
                canvas.Size = new Size(canvasWidth, canvasHeight);
                int canvasX = 0;
                int canvasY = 0;
                if (canvas.Size.Width < Size.Width)
                {
                    canvasX = Size.Width / 2 - canvas.Size.Width / 2;
                }
                if (canvas.Size.Height < Size.Height)
                {
                    canvasY = Size.Height / 2 - canvas.Size.Height / 2;
                }

                if (Image.Width > MaximumEditableImageSize.Width)
                    IsDrawable = false;
                if (Image.Height > MaximumEditableImageSize.Height)
                    IsDrawable = false;

                canvas.Location = new Point(canvasX, canvasY);
            }
        }

        private void UpdateImage()
        {
            canvas.RazorGFX.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            canvas.RazorGFX.Clear(Color.White);
            canvas.RazorGFX.FillRectangle(transparentTiling, canvas.ClientRectangle);
            if (Image != null)
                canvas.RazorGFX.DrawImage(Image, 0, 0, Image.Width * ZoomFactor, Image.Height * ZoomFactor);
        }

        private void UpdateCanvas()
        {
            try
            {
                canvas.RazorPaint();
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Warning! We are ran out of memory, so we reset zoom scale back to 1x", "Ran out of memory!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ZoomFactor = 1.0f;
            }
        }

        public void CreateImage(int width, int height)
        {
            Image = new Bitmap(width, height);
            ResizeCanvas();
            UpdateImage();
            UpdateCanvas();
            IsImageEdited = false;
        }

        public void DrawPixel(Color color, int x, int y)
        {
            if (IsDrawable && EnableDraw)
            {
                if (x > 0 && x < canvas.Width && y > 0 && y < canvas.Height)
                {
                    int xZoomed = (int)Math.Round(x / ZoomFactor);
                    int yZoomed = (int)Math.Round(y / ZoomFactor);
                    Image.SetPixel(xZoomed, yZoomed, color);
                    IsImageEdited = true;
                    ImageEdited?.Invoke(this, EventArgs.Empty);
                    UpdateImage();
                    UpdateCanvas();
                }
            }
        }

        public void ClearImage(Color color)
        {
            canvas.RazorGFX.Clear(color);
            UpdateImage();
            ResizeCanvas();
            UpdateCanvas();
        }

        public void RemoveImage()
        {
            Image = null;
            UpdateImage();
            ResizeCanvas();
            UpdateCanvas();
            IsImageEdited = false;
        }
    }
}
