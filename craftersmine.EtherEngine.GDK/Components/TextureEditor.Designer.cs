namespace craftersmine.EtherEngine.GDK.Components
{
    partial class TextureEditor
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
            this.tip1 = new System.Windows.Forms.Label();
            this.imagePath = new System.Windows.Forms.Label();
            this.selectImg = new System.Windows.Forms.Button();
            this.tip2 = new System.Windows.Forms.Label();
            this.contentPackage = new System.Windows.Forms.TextBox();
            this.contentPackageNameLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textureName = new System.Windows.Forms.TextBox();
            this.textureNameLabel = new System.Windows.Forms.Label();
            this.create = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.SuspendLayout();
            // 
            // tip1
            // 
            this.tip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tip1.Location = new System.Drawing.Point(3, 3);
            this.tip1.Name = "tip1";
            this.tip1.Size = new System.Drawing.Size(597, 38);
            this.tip1.TabIndex = 0;
            this.tip1.Tag = "editor.texture.tip1";
            this.tip1.Text = "editor.texture.tip1";
            // 
            // imagePath
            // 
            this.imagePath.AutoEllipsis = true;
            this.imagePath.Location = new System.Drawing.Point(117, 49);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(483, 13);
            this.imagePath.TabIndex = 1;
            this.imagePath.Text = "{selectedImagePath}";
            this.imagePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectImg
            // 
            this.selectImg.Location = new System.Drawing.Point(3, 44);
            this.selectImg.Name = "selectImg";
            this.selectImg.Size = new System.Drawing.Size(108, 23);
            this.selectImg.TabIndex = 2;
            this.selectImg.Tag = "editor.texture.selectImage";
            this.selectImg.Text = "editor.texture.selectImage";
            this.selectImg.UseVisualStyleBackColor = true;
            // 
            // tip2
            // 
            this.tip2.AutoSize = true;
            this.tip2.Location = new System.Drawing.Point(3, 140);
            this.tip2.Name = "tip2";
            this.tip2.Size = new System.Drawing.Size(88, 13);
            this.tip2.TabIndex = 3;
            this.tip2.Tag = "editor.texture.tip2";
            this.tip2.Text = "editor.texture.tip2";
            // 
            // contentPackage
            // 
            this.contentPackage.Location = new System.Drawing.Point(3, 86);
            this.contentPackage.Name = "contentPackage";
            this.contentPackage.Size = new System.Drawing.Size(178, 20);
            this.contentPackage.TabIndex = 5;
            // 
            // contentPackageNameLabel
            // 
            this.contentPackageNameLabel.AutoSize = true;
            this.contentPackageNameLabel.Location = new System.Drawing.Point(3, 70);
            this.contentPackageNameLabel.Name = "contentPackageNameLabel";
            this.contentPackageNameLabel.Size = new System.Drawing.Size(178, 13);
            this.contentPackageNameLabel.TabIndex = 6;
            this.contentPackageNameLabel.Tag = "editor.texture.contentPackageName";
            this.contentPackageNameLabel.Text = "editor.texture.contentPackageName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = ".";
            // 
            // textureName
            // 
            this.textureName.Location = new System.Drawing.Point(195, 86);
            this.textureName.Name = "textureName";
            this.textureName.Size = new System.Drawing.Size(152, 20);
            this.textureName.TabIndex = 8;
            // 
            // textureNameLabel
            // 
            this.textureNameLabel.AutoSize = true;
            this.textureNameLabel.Location = new System.Drawing.Point(192, 70);
            this.textureNameLabel.Name = "textureNameLabel";
            this.textureNameLabel.Size = new System.Drawing.Size(131, 13);
            this.textureNameLabel.TabIndex = 9;
            this.textureNameLabel.Tag = "editor.texture.textureName";
            this.textureNameLabel.Text = "editor.texture.textureName";
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(422, 112);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(178, 23);
            this.create.TabIndex = 10;
            this.create.Tag = "editor.texture.create";
            this.create.Text = "editor.texture.create";
            this.create.UseVisualStyleBackColor = true;
            // 
            // preview
            // 
            this.preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.preview.Location = new System.Drawing.Point(6, 156);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(594, 277);
            this.preview.TabIndex = 4;
            this.preview.TabStop = false;
            // 
            // TextureEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.create);
            this.Controls.Add(this.textureNameLabel);
            this.Controls.Add(this.textureName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.contentPackageNameLabel);
            this.Controls.Add(this.contentPackage);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.tip2);
            this.Controls.Add(this.selectImg);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.tip1);
            this.Name = "TextureEditor";
            this.Size = new System.Drawing.Size(603, 436);
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tip1;
        private System.Windows.Forms.Label imagePath;
        private System.Windows.Forms.Button selectImg;
        private System.Windows.Forms.Label tip2;
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.TextBox contentPackage;
        private System.Windows.Forms.Label contentPackageNameLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textureName;
        private System.Windows.Forms.Label textureNameLabel;
        private System.Windows.Forms.Button create;
    }
}
