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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.projectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gDKSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.previewContainer = new System.Windows.Forms.Panel();
            this.projectTreeToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.projectTree = new System.Windows.Forms.TreeView();
            this.treeIconList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.objectProperties = new System.Windows.Forms.PropertyGrid();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.projectTreeRefresh = new System.Windows.Forms.ToolStripButton();
            this.projectTreeCreateFolder = new System.Windows.Forms.ToolStripButton();
            this.mainToolSave = new System.Windows.Forms.ToolStripButton();
            this.mainToolOpen = new System.Windows.Forms.ToolStripButton();
            this.mainToolbarDuplicate = new System.Windows.Forms.ToolStripButton();
            this.mainToolDelete = new System.Windows.Forms.ToolStripButton();
            this.createMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectCreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.textureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.contentPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildLaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.previewContainer.SuspendLayout();
            this.projectTreeToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMainMenu,
            this.editMenu,
            this.projectMenu,
            this.serviceToolStripMenuItem});
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
            this.fileMainMenu.Size = new System.Drawing.Size(69, 20);
            this.fileMainMenu.Tag = "menu.file";
            this.fileMainMenu.Text = "menu.file";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // closeMenu
            // 
            this.closeMenu.Enabled = false;
            this.closeMenu.Name = "closeMenu";
            this.closeMenu.Size = new System.Drawing.Size(196, 22);
            this.closeMenu.Tag = "menu.file.close";
            this.closeMenu.Text = "menu.file.close";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(196, 22);
            this.exitMenu.Tag = "menu.file.exit";
            this.exitMenu.Text = "menu.file.exit";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicateMenu,
            this.toolStripMenuItem3,
            this.deleteToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.toolStripMenuItem7,
            this.editSourceToolStripMenuItem});
            this.editMenu.Enabled = false;
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(73, 20);
            this.editMenu.Tag = "menu.edit";
            this.editMenu.Text = "menu.edit";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 6);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.resetToolStripMenuItem.Tag = "menu.edit.reset";
            this.resetToolStripMenuItem.Text = "menu.edit.reset";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(184, 6);
            // 
            // projectMenu
            // 
            this.projectMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectCreateToolStripMenuItem,
            this.toolStripMenuItem5,
            this.buildToolStripMenuItem,
            this.buildLaunchToolStripMenuItem,
            this.toolStripMenuItem6,
            this.projectPropertiesToolStripMenuItem});
            this.projectMenu.Enabled = false;
            this.projectMenu.Name = "projectMenu";
            this.projectMenu.Size = new System.Drawing.Size(90, 20);
            this.projectMenu.Tag = "menu.project";
            this.projectMenu.Text = "menu.project";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(233, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(233, 6);
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gDKSettingsToolStripMenuItem});
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.serviceToolStripMenuItem.Tag = "menu.service";
            this.serviceToolStripMenuItem.Text = "menu.service";
            // 
            // gDKSettingsToolStripMenuItem
            // 
            this.gDKSettingsToolStripMenuItem.Name = "gDKSettingsToolStripMenuItem";
            this.gDKSettingsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.gDKSettingsToolStripMenuItem.Tag = "menu.service.settings";
            this.gDKSettingsToolStripMenuItem.Text = "menu.service.settings";
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
            this.splitContainer1.Panel1.Controls.Add(this.previewContainer);
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
            // previewContainer
            // 
            this.previewContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewContainer.Controls.Add(this.previewBox);
            this.previewContainer.Location = new System.Drawing.Point(0, 131);
            this.previewContainer.Name = "previewContainer";
            this.previewContainer.Size = new System.Drawing.Size(200, 200);
            this.previewContainer.TabIndex = 2;
            // 
            // projectTreeToolStrip
            // 
            this.projectTreeToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.projectTreeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectTreeRefresh,
            this.toolStripSeparator1,
            this.projectTreeCreateFolder});
            this.projectTreeToolStrip.Location = new System.Drawing.Point(0, 0);
            this.projectTreeToolStrip.Name = "projectTreeToolStrip";
            this.projectTreeToolStrip.Size = new System.Drawing.Size(200, 25);
            this.projectTreeToolStrip.TabIndex = 1;
            this.projectTreeToolStrip.Text = "toolStrip2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // projectTree
            // 
            this.projectTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectTree.ImageIndex = 0;
            this.projectTree.ImageList = this.treeIconList;
            this.projectTree.Location = new System.Drawing.Point(0, 28);
            this.projectTree.Name = "projectTree";
            this.projectTree.SelectedImageIndex = 0;
            this.projectTree.Size = new System.Drawing.Size(200, 97);
            this.projectTree.TabIndex = 0;
            this.projectTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.projectTree_NodeMouseClick);
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
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.mainTabs);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.objectProperties);
            this.splitContainer2.Size = new System.Drawing.Size(843, 331);
            this.splitContainer2.SplitterDistance = 603;
            this.splitContainer2.TabIndex = 0;
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
            this.mainToolSave,
            this.mainToolOpen,
            this.toolStripSeparator2,
            this.mainToolbarDuplicate,
            this.mainToolDelete});
            this.mainToolStrip.Location = new System.Drawing.Point(3, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(110, 25);
            this.mainToolStrip.TabIndex = 0;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // mainTabs
            // 
            this.mainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabs.Location = new System.Drawing.Point(0, 0);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(603, 331);
            this.mainTabs.TabIndex = 0;
            // 
            // previewBox
            // 
            this.previewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(0, 0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(200, 200);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            // 
            // projectTreeRefresh
            // 
            this.projectTreeRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.projectTreeRefresh.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.refresh;
            this.projectTreeRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.projectTreeRefresh.Name = "projectTreeRefresh";
            this.projectTreeRefresh.Size = new System.Drawing.Size(23, 22);
            this.projectTreeRefresh.Tag = "toolbar.projectTree.refresh";
            this.projectTreeRefresh.Text = "toolbar.projectTree.refresh";
            // 
            // projectTreeCreateFolder
            // 
            this.projectTreeCreateFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.projectTreeCreateFolder.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.create_folder;
            this.projectTreeCreateFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.projectTreeCreateFolder.Name = "projectTreeCreateFolder";
            this.projectTreeCreateFolder.Size = new System.Drawing.Size(23, 22);
            this.projectTreeCreateFolder.Tag = "toolbar.projectTree.createFolder";
            this.projectTreeCreateFolder.Text = "toolbar.projectTree.createFolder";
            // 
            // mainToolSave
            // 
            this.mainToolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mainToolSave.Enabled = false;
            this.mainToolSave.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.save;
            this.mainToolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mainToolSave.Name = "mainToolSave";
            this.mainToolSave.Size = new System.Drawing.Size(23, 22);
            this.mainToolSave.Tag = "toolbar.main.save";
            this.mainToolSave.Text = "toolbar.main.save";
            this.mainToolSave.Click += new System.EventHandler(this.SaveEventHandler);
            // 
            // mainToolOpen
            // 
            this.mainToolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mainToolOpen.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.open;
            this.mainToolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mainToolOpen.Name = "mainToolOpen";
            this.mainToolOpen.Size = new System.Drawing.Size(23, 22);
            this.mainToolOpen.Tag = "toolbar.main.open";
            this.mainToolOpen.Text = "toolbar.main.open";
            this.mainToolOpen.Click += new System.EventHandler(this.OpenEventHandler);
            // 
            // mainToolbarDuplicate
            // 
            this.mainToolbarDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mainToolbarDuplicate.Enabled = false;
            this.mainToolbarDuplicate.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.duplicate;
            this.mainToolbarDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mainToolbarDuplicate.Name = "mainToolbarDuplicate";
            this.mainToolbarDuplicate.Size = new System.Drawing.Size(23, 22);
            this.mainToolbarDuplicate.Tag = "toolbar.main.duplicate";
            this.mainToolbarDuplicate.Text = "toolbar.main.duplicate";
            // 
            // mainToolDelete
            // 
            this.mainToolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mainToolDelete.Enabled = false;
            this.mainToolDelete.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.delete;
            this.mainToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mainToolDelete.Name = "mainToolDelete";
            this.mainToolDelete.Size = new System.Drawing.Size(23, 22);
            this.mainToolDelete.Tag = "toolbar.main.delete";
            this.mainToolDelete.Text = "toolbar.main.delete";
            // 
            // createMenu
            // 
            this.createMenu.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.create_project;
            this.createMenu.Name = "createMenu";
            this.createMenu.Size = new System.Drawing.Size(196, 22);
            this.createMenu.Tag = "menu.file.createProject";
            this.createMenu.Text = "menu.file.createProject";
            // 
            // openMenu
            // 
            this.openMenu.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.open;
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(196, 22);
            this.openMenu.Tag = "menu.file.openProject";
            this.openMenu.Text = "menu.file.openProject";
            this.openMenu.Click += new System.EventHandler(this.OpenEventHandler);
            // 
            // saveMenu
            // 
            this.saveMenu.Enabled = false;
            this.saveMenu.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.save;
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.Size = new System.Drawing.Size(196, 22);
            this.saveMenu.Tag = "menu.file.save";
            this.saveMenu.Text = "menu.file.save";
            this.saveMenu.Click += new System.EventHandler(this.SaveEventHandler);
            // 
            // duplicateMenu
            // 
            this.duplicateMenu.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.duplicate;
            this.duplicateMenu.Name = "duplicateMenu";
            this.duplicateMenu.Size = new System.Drawing.Size(187, 22);
            this.duplicateMenu.Tag = "menu.edit.duplicate";
            this.duplicateMenu.Text = "menu.edit.duplicate";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deleteToolStripMenuItem.Tag = "menu.edit.delete";
            this.deleteToolStripMenuItem.Text = "menu.edit.delete";
            // 
            // editSourceToolStripMenuItem
            // 
            this.editSourceToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.edit_source;
            this.editSourceToolStripMenuItem.Name = "editSourceToolStripMenuItem";
            this.editSourceToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.editSourceToolStripMenuItem.Tag = "menu.edit.editSource";
            this.editSourceToolStripMenuItem.Text = "menu.edit.editSource";
            // 
            // projectCreateToolStripMenuItem
            // 
            this.projectCreateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sceneToolStripMenuItem,
            this.gameObjectToolStripMenuItem,
            this.toolStripMenuItem4,
            this.textureToolStripMenuItem,
            this.animationToolStripMenuItem,
            this.toolStripMenuItem8,
            this.contentPackageToolStripMenuItem});
            this.projectCreateToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.create;
            this.projectCreateToolStripMenuItem.Name = "projectCreateToolStripMenuItem";
            this.projectCreateToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.projectCreateToolStripMenuItem.Tag = "menu.project.create";
            this.projectCreateToolStripMenuItem.Text = "menu.project.create";
            // 
            // sceneToolStripMenuItem
            // 
            this.sceneToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.scene;
            this.sceneToolStripMenuItem.Name = "sceneToolStripMenuItem";
            this.sceneToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.sceneToolStripMenuItem.Tag = "menu.project.create.scene";
            this.sceneToolStripMenuItem.Text = "menu.project.create.scene";
            // 
            // gameObjectToolStripMenuItem
            // 
            this.gameObjectToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.gameobject;
            this.gameObjectToolStripMenuItem.Name = "gameObjectToolStripMenuItem";
            this.gameObjectToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.gameObjectToolStripMenuItem.Tag = "menu.project.create.gameObject";
            this.gameObjectToolStripMenuItem.Text = "menu.project.create.gameObject";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(265, 6);
            // 
            // textureToolStripMenuItem
            // 
            this.textureToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.texture;
            this.textureToolStripMenuItem.Name = "textureToolStripMenuItem";
            this.textureToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.textureToolStripMenuItem.Tag = "menu.project.create.texture";
            this.textureToolStripMenuItem.Text = "menu.project.create.texture";
            // 
            // animationToolStripMenuItem
            // 
            this.animationToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.animation;
            this.animationToolStripMenuItem.Name = "animationToolStripMenuItem";
            this.animationToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.animationToolStripMenuItem.Tag = "menu.project.create.animation";
            this.animationToolStripMenuItem.Text = "menu.project.create.animation";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(265, 6);
            // 
            // contentPackageToolStripMenuItem
            // 
            this.contentPackageToolStripMenuItem.Name = "contentPackageToolStripMenuItem";
            this.contentPackageToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.contentPackageToolStripMenuItem.Tag = "menu.project.create.contentPackage";
            this.contentPackageToolStripMenuItem.Text = "menu.project.create.contentPackage";
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.build;
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.buildToolStripMenuItem.Tag = "menu.project.build";
            this.buildToolStripMenuItem.Text = "menu.project.build";
            // 
            // buildLaunchToolStripMenuItem
            // 
            this.buildLaunchToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.run;
            this.buildLaunchToolStripMenuItem.Name = "buildLaunchToolStripMenuItem";
            this.buildLaunchToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.buildLaunchToolStripMenuItem.Tag = "menu.project.buildAndLaunch";
            this.buildLaunchToolStripMenuItem.Text = "menu.project.buildAndLaunch";
            // 
            // projectPropertiesToolStripMenuItem
            // 
            this.projectPropertiesToolStripMenuItem.Image = global::craftersmine.EtherEngine.GDK.Properties.Resources.properties;
            this.projectPropertiesToolStripMenuItem.Name = "projectPropertiesToolStripMenuItem";
            this.projectPropertiesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.projectPropertiesToolStripMenuItem.Tag = "menu.project.properties";
            this.projectPropertiesToolStripMenuItem.Text = "menu.project.properties";
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
            this.previewContainer.ResumeLayout(false);
            this.projectTreeToolStrip.ResumeLayout(false);
            this.projectTreeToolStrip.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem duplicateMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectMenu;
        private System.Windows.Forms.ToolStripMenuItem projectCreateToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripButton mainToolSave;
        private System.Windows.Forms.ToolStripButton mainToolOpen;
        private System.Windows.Forms.ToolStripButton projectTreeRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton projectTreeCreateFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton mainToolbarDuplicate;
        private System.Windows.Forms.ToolStripButton mainToolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildLaunchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem projectPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem editSourceToolStripMenuItem;
        private System.Windows.Forms.ImageList treeIconList;
        private System.Windows.Forms.Panel previewContainer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem contentPackageToolStripMenuItem;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gDKSettingsToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabs;
    }
}

