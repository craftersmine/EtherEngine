using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Rendering;
using craftersmine.EtherEngine.Core;

namespace craftersmine.EtherEngine.Objects.UIWidgets
{
    public class Button : UIWidget
    {
        private string _text;
        private Size _measuredTextSize;
        private Rectangle _textRenderBounds;
        private bool _isClicked;
        private int _frameCounter;
        private int _currentAnimationFrame;

        public Font Font { get; set; }
        public string Text { get { return _text; } set { _text = value; _measuredTextSize = TextRenderer.MeasureText(_text, Font); _textRenderBounds = new Rectangle((int)X, (int)Y, _measuredTextSize.Width, _measuredTextSize.Height); } }
        public Color TextColor { get; set; }
        public event EventHandler Click;

        public Button() : this(60, 20, "Button")
        { }

        public Button(int width, int height, string text) : this(width, height, text, new Font("Segoe UI", 8))
        { }

        public Button(int width, int height, string text, Font font)
        {
            Width = width;
            Height = height;
            Text = text;
            Font = font;
            TextColor = Color.White;
            Visible = true;
        }

        public override void OnRender(GLGDI renderer)
        {
            base.OnRender(renderer);
            renderer.DrawString(_text, Font, TextColor, (Transform.Width / 2) - (_measuredTextSize.Width / 2), (Transform.Height / 2) - (_measuredTextSize.Height / 2), TextQuality.High);
        }

        public override void OnMouseDown(int mouseX, int mouseY, bool mouseLeftButton, bool mouseMiddleButton, bool mouseRightButton)
        {
            base.OnMouseDown(mouseX, mouseY, mouseLeftButton, mouseMiddleButton, mouseRightButton);
            Click?.Invoke(this, EventArgs.Empty);
            _isClicked = true;
        }
    }
}
