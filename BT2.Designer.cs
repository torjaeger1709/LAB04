namespace LAB04
{
    partial class BT2
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
            lblUrl = new Label();
            txtUrl = new TextBox();
            lblFilePath = new Label();
            txtFilePath = new TextBox();
            btnBrowse = new Button();
            btnDownload = new Button();
            rtbContent = new RichTextBox();
            lblContent = new Label();
            SuspendLayout();
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(20, 20);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(38, 20);
            lblUrl.TabIndex = 0;
            lblUrl.Text = "URL:";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(120, 17);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(550, 27);
            txtUrl.TabIndex = 1;
            txtUrl.Text = "http://uit.edu.vn";
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(20, 60);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(93, 20);
            lblFilePath.TabIndex = 2;
            lblFilePath.Text = "Ðý?ng d?n:";
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(120, 57);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(430, 27);
            txtFilePath.TabIndex = 3;
            txtFilePath.Text = "E:\\uit.html";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(565, 55);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(105, 30);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Ch?n file...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnDownload
            // 
            btnDownload.BackColor = SystemColors.Highlight;
            btnDownload.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(690, 15);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(130, 70);
            btnDownload.TabIndex = 5;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // rtbContent
            // 
            rtbContent.Font = new Font("Consolas", 9F);
            rtbContent.Location = new Point(20, 130);
            rtbContent.Name = "rtbContent";
            rtbContent.ReadOnly = true;
            rtbContent.Size = new Size(800, 400);
            rtbContent.TabIndex = 6;
            rtbContent.Text = "";
            rtbContent.WordWrap = false;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContent.Location = new Point(20, 105);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(168, 20);
            lblContent.TabIndex = 7;
            lblContent.Text = "N?i dung trang web:";
            // 
            // BT2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 550);
            Controls.Add(lblContent);
            Controls.Add(rtbContent);
            Controls.Add(btnDownload);
            Controls.Add(btnBrowse);
            Controls.Add(txtFilePath);
            Controls.Add(lblFilePath);
            Controls.Add(txtUrl);
            Controls.Add(lblUrl);
            Name = "BT2";
            Text = "Bài 2 - Download Web Content";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUrl;
        private TextBox txtUrl;
        private Label lblFilePath;
        private TextBox txtFilePath;
        private Button btnBrowse;
        private Button btnDownload;
        private RichTextBox rtbContent;
        private Label lblContent;
    }
}
