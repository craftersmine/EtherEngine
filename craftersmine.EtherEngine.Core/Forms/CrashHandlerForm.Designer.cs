namespace craftersmine.EtherEngine.Core.Forms
{
    partial class CrashHandlerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.msg = new System.Windows.Forms.Label();
            this.hres = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stacktrace = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.exception = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(61, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oops! Something went wrong";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Game or engine can\'t handle some operation and shown what went wrong below.\r\nPlea" +
    "se send this log to game developer or engine developer. Thanks!";
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.Location = new System.Drawing.Point(14, 108);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(108, 13);
            this.msg.TabIndex = 2;
            this.msg.Text = "Message: {message}";
            // 
            // hres
            // 
            this.hres.AutoSize = true;
            this.hres.Location = new System.Drawing.Point(14, 121);
            this.hres.Name = "hres";
            this.hres.Size = new System.Drawing.Size(81, 13);
            this.hres.TabIndex = 3;
            this.hres.Text = "HResult: {hres}";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stacktrace:";
            // 
            // stacktrace
            // 
            this.stacktrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stacktrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.stacktrace.ForeColor = System.Drawing.Color.White;
            this.stacktrace.Location = new System.Drawing.Point(17, 179);
            this.stacktrace.Multiline = true;
            this.stacktrace.Name = "stacktrace";
            this.stacktrace.ReadOnly = true;
            this.stacktrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.stacktrace.Size = new System.Drawing.Size(851, 322);
            this.stacktrace.TabIndex = 999;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-1, 516);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 51);
            this.panel1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(579, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save Log to Desktop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(741, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // icon
            // 
            this.icon.Location = new System.Drawing.Point(17, 16);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(32, 32);
            this.icon.TabIndex = 7;
            this.icon.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(793, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "DUMMYTABBUTTON";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // exception
            // 
            this.exception.AutoSize = true;
            this.exception.Location = new System.Drawing.Point(14, 134);
            this.exception.Name = "exception";
            this.exception.Size = new System.Drawing.Size(119, 13);
            this.exception.TabIndex = 1000;
            this.exception.Text = "Exception: {exception}";
            // 
            // CrashHandlerForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 566);
            this.Controls.Add(this.exception);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stacktrace);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hres);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrashHandlerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "craftersmine EtherEngine - Something went wrong";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.Label hres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stacktrace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label exception;
    }
}