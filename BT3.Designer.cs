namespace LAB04
{
    partial class BT3
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
            btnLoad = new Button();
            txtUrl = new TextBox();
            btnResources = new Button();
            btnFiles = new Button();
            btnReload = new Button();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(37, 18);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(114, 36);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(167, 23);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(539, 27);
            txtUrl.TabIndex = 1;
            // 
            // btnResources
            // 
            btnResources.Location = new Point(703, 75);
            btnResources.Name = "btnResources";
            btnResources.Size = new Size(166, 36);
            btnResources.TabIndex = 2;
            btnResources.Text = "Down Resources";
            btnResources.UseVisualStyleBackColor = true;
            btnResources.Click += btnResources_Click;
            // 
            // btnFiles
            // 
            btnFiles.Location = new Point(517, 75);
            btnFiles.Name = "btnFiles";
            btnFiles.Size = new Size(164, 36);
            btnFiles.TabIndex = 3;
            btnFiles.Text = "Download Files";
            btnFiles.UseVisualStyleBackColor = true;
            btnFiles.Click += btnFiles_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(755, 18);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(114, 36);
            btnReload.TabIndex = 4;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Location = new Point(0, 154);
            webView.Name = "webView";
            webView.Size = new Size(1030, 416);
            webView.TabIndex = 5;
            webView.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnReload);
            panel1.Controls.Add(btnFiles);
            panel1.Controls.Add(btnResources);
            panel1.Controls.Add(txtUrl);
            panel1.Controls.Add(btnLoad);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1030, 133);
            panel1.TabIndex = 6;
            // 
            // BT3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 570);
            Controls.Add(panel1);
            Controls.Add(webView);
            Name = "BT3";
            Text = "B4";
            Load += this.BT3_Load_1;
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoad;
        private TextBox txtUrl;
        private Button btnResources;
        private Button btnFiles;
        private Button btnReload;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Panel panel1;
    }
}