namespace craftersmine.EtherEngine.GDK.Components
{
    partial class SceneEditor
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
            this.openGLWindow = new craftersmine.EtherEngine.GDK.Components.GLGDIControl();
            this.SuspendLayout();
            // 
            // openGLWindow
            // 
            this.openGLWindow.BackColor = System.Drawing.Color.Black;
            this.openGLWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLWindow.GLGDIInstance = null;
            this.openGLWindow.Location = new System.Drawing.Point(0, 0);
            this.openGLWindow.Name = "openGLWindow";
            this.openGLWindow.Size = new System.Drawing.Size(757, 504);
            this.openGLWindow.TabIndex = 1;
            this.openGLWindow.VSync = false;
            // 
            // SceneEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.openGLWindow);
            this.Name = "SceneEditor";
            this.Size = new System.Drawing.Size(757, 504);
            this.ResumeLayout(false);

        }

        #endregion
        private GLGDIControl openGLWindow;
    }
}
