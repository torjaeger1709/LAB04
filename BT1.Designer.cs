namespace LAB04
{
    partial class BT1
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
            txtUrl = new TextBox();
            btnGet = new Button();
            rtbContent = new RichTextBox();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUrl.Location = new Point(12, 29);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(906, 31);
            txtUrl.TabIndex = 0;
            // 
            // btnGet
            // 
            btnGet.Location = new Point(924, 29);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(124, 35);
            btnGet.TabIndex = 1;
            btnGet.Text = "GET";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // rtbContent
            // 
            rtbContent.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbContent.Location = new Point(12, 76);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(1036, 463);
            rtbContent.TabIndex = 2;
            rtbContent.Text = "";
            // 
            // BT1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 551);
            Controls.Add(rtbContent);
            Controls.Add(btnGet);
            Controls.Add(txtUrl);
            Name = "BT1";
            Text = "BT1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUrl;
        private Button btnGet;
        private RichTextBox rtbContent;
    }
}