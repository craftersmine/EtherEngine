namespace craftersmine.EtherEngine.GDK.TextureEditor
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.importImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLastColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.importPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newTool = new System.Windows.Forms.ToolStripButton();
            this.openTool = new System.Windows.Forms.ToolStripButton();
            this.saveTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomOutTool = new System.Windows.Forms.ToolStripButton();
            this.zoomInTool = new System.Windows.Forms.ToolStripButton();
            this.resetZoom = new System.Windows.Forms.ToolStripButton();
            this.imageContainer = new craftersmine.EtherEngine.GDK.Editor.Texture.ImageContainer();
            this.rgbColorSelector = new craftersmine.EtherEngine.GDK.Editor.Texture.RGBColorSelector();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.importImageToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewClick);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // importImageToolStripMenuItem
            // 
            this.importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
            this.importImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importImageToolStripMenuItem.Text = "Import Image";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearTextureToolStripMenuItem,
            this.clearLastColorsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.zoom11ToolStripMenuItem,
            this.toolStripMenuItem5,
            this.importPaletteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearTextureToolStripMenuItem
            // 
            this.clearTextureToolStripMenuItem.Enabled = false;
            this.clearTextureToolStripMenuItem.Name = "clearTextureToolStripMenuItem";
            this.clearTextureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearTextureToolStripMenuItem.Text = "Clear Texture";
            // 
            // clearLastColorsToolStripMenuItem
            // 
            this.clearLastColorsToolStripMenuItem.Name = "clearLastColorsToolStripMenuItem";
            this.clearLastColorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearLastColorsToolStripMenuItem.Text = "Clear Last Colors";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Enabled = false;
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Enabled = false;
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            // 
            // zoom11ToolStripMenuItem
            // 
            this.zoom11ToolStripMenuItem.Enabled = false;
            this.zoom11ToolStripMenuItem.Name = "zoom11ToolStripMenuItem";
            this.zoom11ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoom11ToolStripMenuItem.Text = "Zoom 1:1";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(177, 6);
            // 
            // importPaletteToolStripMenuItem
            // 
            this.importPaletteToolStripMenuItem.Name = "importPaletteToolStripMenuItem";
            this.importPaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importPaletteToolStripMenuItem.Text = "Import Palette";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTool,
            this.openTool,
            this.saveTool,
            this.toolStripSeparator1,
            this.zoomOutTool,
            this.zoomInTool,
            this.resetZoom});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(692, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newTool
            // 
            this.newTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newTool.Image = ((System.Drawing.Image)(resources.GetObject("newTool.Image")));
            this.newTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newTool.Name = "newTool";
            this.newTool.Size = new System.Drawing.Size(23, 22);
            this.newTool.Text = "New";
            // 
            // openTool
            // 
            this.openTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openTool.Image = ((System.Drawing.Image)(resources.GetObject("openTool.Image")));
            this.openTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openTool.Name = "openTool";
            this.openTool.Size = new System.Drawing.Size(23, 22);
            this.openTool.Text = "Open";
            // 
            // saveTool
            // 
            this.saveTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveTool.Image = ((System.Drawing.Image)(resources.GetObject("saveTool.Image")));
            this.saveTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveTool.Name = "saveTool";
            this.saveTool.Size = new System.Drawing.Size(23, 22);
            this.saveTool.Text = "Save";
            this.saveTool.Click += new System.EventHandler(this.SaveClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomOutTool
            // 
            this.zoomOutTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutTool.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutTool.Image")));
            this.zoomOutTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutTool.Name = "zoomOutTool";
            this.zoomOutTool.Size = new System.Drawing.Size(23, 22);
            this.zoomOutTool.Text = "Zoom Out";
            // 
            // zoomInTool
            // 
            this.zoomInTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInTool.Image = ((System.Drawing.Image)(resources.GetObject("zoomInTool.Image")));
            this.zoomInTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInTool.Name = "zoomInTool";
            this.zoomInTool.Size = new System.Drawing.Size(23, 22);
            this.zoomInTool.Text = "Zoom In";
            // 
            // resetZoom
            // 
            this.resetZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resetZoom.Image = ((System.Drawing.Image)(resources.GetObject("resetZoom.Image")));
            this.resetZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetZoom.Name = "resetZoom";
            this.resetZoom.Size = new System.Drawing.Size(23, 22);
            this.resetZoom.Text = "Zoom 1:1";
            // 
            // imageContainer
            // 
            this.imageContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageContainer.AutoScroll = true;
            this.imageContainer.EnableDraw = true;
            this.imageContainer.Image = null;
            this.imageContainer.Location = new System.Drawing.Point(0, 52);
            this.imageContainer.MaximumEditableImageSize = new System.Drawing.Size(512, 512);
            this.imageContainer.Name = "imageContainer";
            this.imageContainer.Size = new System.Drawing.Size(518, 307);
            this.imageContainer.TabIndex = 3;
            this.imageContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawMouseDown);
            this.imageContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawMouseDown);
            this.imageContainer.ImageEdited += new System.EventHandler(this.ImageEdited);
            // 
            // rgbColorSelector
            // 
            this.rgbColorSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rgbColorSelector.AutoSize = true;
            this.rgbColorSelector.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rgbColorSelector.Location = new System.Drawing.Point(524, 52);
            this.rgbColorSelector.MaximumSize = new System.Drawing.Size(156, 295);
            this.rgbColorSelector.MinimumSize = new System.Drawing.Size(156, 295);
            this.rgbColorSelector.Name = "rgbColorSelector";
            this.rgbColorSelector.Palette = ((System.Drawing.Bitmap)(resources.GetObject("rgbColorSelector.Palette")));
            this.rgbColorSelector.Size = new System.Drawing.Size(156, 295);
            this.rgbColorSelector.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 359);
            this.Controls.Add(this.imageContainer);
            this.Controls.Add(this.rgbColorSelector);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem importImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLastColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem importPaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newTool;
        private System.Windows.Forms.ToolStripButton openTool;
        private System.Windows.Forms.ToolStripButton saveTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton zoomOutTool;
        private System.Windows.Forms.ToolStripButton zoomInTool;
        private System.Windows.Forms.ToolStripButton resetZoom;
        private Editor.Texture.RGBColorSelector rgbColorSelector;
        private Editor.Texture.ImageContainer imageContainer;
    }
}

