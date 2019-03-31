namespace craftersmine.EtherEngine.GDK.Editor.Texture
{
    partial class ImageContainer
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new RazorGDI.RazorPainterControl();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.AutoSize = true;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.MinimumSize = new System.Drawing.Size(2, 2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(128, 128);
            this.canvas.TabIndex = 0;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            // 
            // ImageContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.canvas);
            this.Name = "ImageContainer";
            this.Size = new System.Drawing.Size(128, 128);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RazorGDI.RazorPainterControl canvas;
    }
}
