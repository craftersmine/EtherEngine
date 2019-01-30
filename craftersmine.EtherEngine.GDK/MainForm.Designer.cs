namespace craftersmine.EtherEngine.GDK
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.editSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.textureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildLaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.projectPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.projectTreeToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.projectTree = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.glControl1 = new OpenTK.GLControl();
            this.objectProperties = new System.Windows.Forms.PropertyGrid();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveTool = new System.Windows.Forms.ToolStripButton();
            this.openTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.treeIconList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.projectTreeToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMainMenu,
            this.editMenu,
            this.projectMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(1047, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMainMenu
            // 
            this.fileMainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMenu,
            this.toolStripMenuItem1,
            this.openMenu,
            this.saveMenu,
            this.closeMenu,
            this.toolStripMenuItem2,
            this.exitMenu});
            this.fileMainMenu.Name = "fileMainMenu";
            this.fileMainMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMainMenu.Text = "File";
            // 
            // createMenu
            // 
            this.createMenu.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.create_project;
            this.createMenu.Name = "createMenu";
            this.createMenu.Size = new System.Drawing.Size(180, 22);
            this.createMenu.Text = "Create Project";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // openMenu
            // 
            this.openMenu.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.open;
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(180, 22);
            this.openMenu.Text = "Open Project";
            this.openMenu.Click += new System.EventHandler(this.OpenEventHandler);
            // 
            // saveMenu
            // 
            this.saveMenu.Enabled = false;
            this.saveMenu.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.save;
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.Size = new System.Drawing.Size(180, 22);
            this.saveMenu.Text = "Save";
            this.saveMenu.Click += new System.EventHandler(this.SaveEventHandler);
            // 
            // closeMenu
            // 
            this.closeMenu.Enabled = false;
            this.closeMenu.Name = "closeMenu";
            this.closeMenu.Size = new System.Drawing.Size(180, 22);
            this.closeMenu.Text = "Close";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(180, 22);
            this.exitMenu.Text = "Exit";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicateToolStripMenuItem,
            this.toolStripMenuItem3,
            this.deleteToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.toolStripMenuItem7,
            this.editSourceToolStripMenuItem});
            this.editMenu.Enabled = false;
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(39, 20);
            this.editMenu.Text = "Edit";
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.duplicate;
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(177, 6);
            // 
            // editSourceToolStripMenuItem
            // 
            this.editSourceToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.edit_source;
            this.editSourceToolStripMenuItem.Name = "editSourceToolStripMenuItem";
            this.editSourceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editSourceToolStripMenuItem.Text = "Edit Source";
            // 
            // projectMenu
            // 
            this.projectMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.buildToolStripMenuItem,
            this.buildLaunchToolStripMenuItem,
            this.toolStripMenuItem6,
            this.projectPropertiesToolStripMenuItem});
            this.projectMenu.Enabled = false;
            this.projectMenu.Name = "projectMenu";
            this.projectMenu.Size = new System.Drawing.Size(56, 20);
            this.projectMenu.Text = "Project";
            // 
            // createToolStripMenuItem1
            // 
            this.createToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sceneToolStripMenuItem,
            this.gameObjectToolStripMenuItem,
            this.toolStripMenuItem4,
            this.textureToolStripMenuItem,
            this.animationToolStripMenuItem});
            this.createToolStripMenuItem1.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.create;
            this.createToolStripMenuItem1.Name = "createToolStripMenuItem1";
            this.createToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem1.Text = "Create...";
            // 
            // sceneToolStripMenuItem
            // 
            this.sceneToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.scene;
            this.sceneToolStripMenuItem.Name = "sceneToolStripMenuItem";
            this.sceneToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.sceneToolStripMenuItem.Text = "Scene";
            // 
            // gameObjectToolStripMenuItem
            // 
            this.gameObjectToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.gameobject;
            this.gameObjectToolStripMenuItem.Name = "gameObjectToolStripMenuItem";
            this.gameObjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.gameObjectToolStripMenuItem.Text = "Game Object";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(140, 6);
            // 
            // textureToolStripMenuItem
            // 
            this.textureToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.texture;
            this.textureToolStripMenuItem.Name = "textureToolStripMenuItem";
            this.textureToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.textureToolStripMenuItem.Text = "Texture";
            // 
            // animationToolStripMenuItem
            // 
            this.animationToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.animation;
            this.animationToolStripMenuItem.Name = "animationToolStripMenuItem";
            this.animationToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.animationToolStripMenuItem.Text = "Animation";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(177, 6);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.build;
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // buildLaunchToolStripMenuItem
            // 
            this.buildLaunchToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.run;
            this.buildLaunchToolStripMenuItem.Name = "buildLaunchToolStripMenuItem";
            this.buildLaunchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buildLaunchToolStripMenuItem.Text = "Build && Launch";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(177, 6);
            // 
            // projectPropertiesToolStripMenuItem
            // 
            this.projectPropertiesToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.properties;
            this.projectPropertiesToolStripMenuItem.Name = "projectPropertiesToolStripMenuItem";
            this.projectPropertiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.projectPropertiesToolStripMenuItem.Text = "Project Properties";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 380);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1047, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusBar";
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1047, 331);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1047, 356);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainToolStrip);
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.projectTreeToolStrip);
            this.splitContainer1.Panel1.Controls.Add(this.projectTree);
            this.splitContainer1.Panel1.Enabled = false;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1047, 331);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // projectTreeToolStrip
            // 
            this.projectTreeToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.projectTreeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.toolStripButton5});
            this.projectTreeToolStrip.Location = new System.Drawing.Point(0, 0);
            this.projectTreeToolStrip.Name = "projectTreeToolStrip";
            this.projectTreeToolStrip.Size = new System.Drawing.Size(200, 25);
            this.projectTreeToolStrip.TabIndex = 1;
            this.projectTreeToolStrip.Text = "toolStrip2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.refresh;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Refresh";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.create_folder;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Create Folder";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // projectTree
            // 
            this.projectTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectTree.Location = new System.Drawing.Point(0, 28);
            this.projectTree.Name = "projectTree";
            this.projectTree.Size = new System.Drawing.Size(200, 303);
            this.projectTree.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.glControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.objectProperties);
            this.splitContainer2.Size = new System.Drawing.Size(843, 331);
            this.splitContainer2.SplitterDistance = 603;
            this.splitContainer2.TabIndex = 0;
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(603, 331);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            // 
            // objectProperties
            // 
            this.objectProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectProperties.Location = new System.Drawing.Point(0, 0);
            this.objectProperties.Name = "objectProperties";
            this.objectProperties.Size = new System.Drawing.Size(236, 331);
            this.objectProperties.TabIndex = 0;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTool,
            this.openTool,
            this.toolStripSeparator2,
            this.toolStripButton6,
            this.toolStripButton7});
            this.mainToolStrip.Location = new System.Drawing.Point(3, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(110, 25);
            this.mainToolStrip.TabIndex = 0;
            // 
            // saveTool
            // 
            this.saveTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveTool.Enabled = false;
            this.saveTool.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.save;
            this.saveTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveTool.Name = "saveTool";
            this.saveTool.Size = new System.Drawing.Size(23, 22);
            this.saveTool.Text = "Save";
            this.saveTool.Click += new System.EventHandler(this.SaveEventHandler);
            // 
            // openTool
            // 
            this.openTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openTool.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.open;
            this.openTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openTool.Name = "openTool";
            this.openTool.Size = new System.Drawing.Size(23, 22);
            this.openTool.Text = "Open";
            this.openTool.Click += new System.EventHandler(this.OpenEventHandler);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Enabled = false;
            this.toolStripButton6.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.duplicate;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Duplicate";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Enabled = false;
            this.toolStripButton7.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.delete;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Delete";
            // 
            // treeIconList
            // 
            this.treeIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeIconList.ImageStream")));
            this.treeIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeIconList.Images.SetKeyName(0, "folder-closed");
            this.treeIconList.Images.SetKeyName(1, "folder-open");
            this.treeIconList.Images.SetKeyName(2, "unknown");
            this.treeIconList.Images.SetKeyName(3, "project");
            this.treeIconList.Images.SetKeyName(4, "animation");
            this.treeIconList.Images.SetKeyName(5, "texture");
            this.treeIconList.Images.SetKeyName(6, "source");
            this.treeIconList.Images.SetKeyName(7, "gameobject");
            this.treeIconList.Images.SetKeyName(8, "scene");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 402);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.projectTreeToolStrip.ResumeLayout(false);
            this.projectTreeToolStrip.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMainMenu;
        private System.Windows.Forms.ToolStripMenuItem createMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenu;
        private System.Windows.Forms.ToolStripMenuItem closeMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectMenu;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem textureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip projectTreeToolStrip;
        private System.Windows.Forms.TreeView projectTree;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid objectProperties;
        private System.Windows.Forms.ToolStripButton saveTool;
        private System.Windows.Forms.ToolStripButton openTool;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildLaunchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem projectPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem editSourceToolStripMenuItem;
        private System.Windows.Forms.ImageList treeIconList;
    }
}

