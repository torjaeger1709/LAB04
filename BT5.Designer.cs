namespace LAB04
{
    partial class BT5
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
            URL_txb = new TextBox();
            user_txb = new TextBox();
            richTextBox1 = new RichTextBox();
            pass_txb = new TextBox();
            login_btn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // URL_txb
            // 
            URL_txb.Location = new Point(109, 22);
            URL_txb.Name = "URL_txb";
            URL_txb.Size = new Size(576, 27);
            URL_txb.TabIndex = 0;
            URL_txb.TextChanged += textBox1_TextChanged;
            // 
            // user_txb
            // 
            user_txb.Location = new Point(109, 83);
            user_txb.Name = "user_txb";
            user_txb.Size = new Size(452, 27);
            user_txb.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(40, 180);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(645, 258);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // pass_txb
            // 
            pass_txb.Location = new Point(109, 129);
            pass_txb.Name = "pass_txb";
            pass_txb.Size = new Size(452, 27);
            pass_txb.TabIndex = 3;
            // 
            // login_btn
            // 
            login_btn.Location = new Point(577, 82);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(108, 74);
            login_btn.TabIndex = 4;
            login_btn.Text = "LOGIN";
            login_btn.UseVisualStyleBackColor = true;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 26);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 5;
            label1.Text = "URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 87);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 6;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 133);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 7;
            label3.Text = "Password";
            // 
            // BT5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(login_btn);
            Controls.Add(pass_txb);
            Controls.Add(richTextBox1);
            Controls.Add(user_txb);
            Controls.Add(URL_txb);
            Name = "BT5";
            Text = "BT5";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox URL_txb;
        private TextBox user_txb;
        private RichTextBox richTextBox1;
        private TextBox pass_txb;
        private Button login_btn;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}