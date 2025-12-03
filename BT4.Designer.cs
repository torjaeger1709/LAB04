namespace LAB04
{
    partial class BT4
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
            progressBar1 = new ProgressBar();
            label8 = new Label();
            label7 = new Label();
            button2 = new Button();
            ReadFile = new Button();
            SCREEN = new Label();
            label6 = new Label();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            exit = new Button();
            panel2 = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panelSeats = new FlowLayoutPanel();
            lblResult = new Label();
            btnCalculate = new Button();
            cbRoom = new ComboBox();
            cbMovie = new ComboBox();
            pbPoster = new PictureBox();
            label9 = new Label();
            txtCustomerName = new TextBox();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPoster).BeginInit();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(488, 162);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(276, 28);
            progressBar1.TabIndex = 52;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(222, 602);
            label8.Name = "label8";
            label8.Size = new Size(359, 20);
            label8.TabIndex = 51;
            label8.Text = "Đọc File: chọn File chứa tên phim và rạp chiếu.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(222, 641);
            label7.Name = "label7";
            label7.Size = new Size(243, 20);
            label7.TabIndex = 50;
            label7.Text = "Xuất File: Xuất ra File thống kê.";
            // 
            // button2
            // 
            button2.Location = new Point(354, 151);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(111, 51);
            button2.TabIndex = 49;
            button2.Text = "Xuất thống kê";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ReadFile
            // 
            ReadFile.Location = new Point(238, 151);
            ReadFile.Margin = new Padding(3, 4, 3, 4);
            ReadFile.Name = "ReadFile";
            ReadFile.Size = new Size(97, 51);
            ReadFile.TabIndex = 48;
            ReadFile.Text = "Lấy Phim";
            ReadFile.UseVisualStyleBackColor = true;
            ReadFile.Click += ReadFile_Click;
            // 
            // SCREEN
            // 
            SCREEN.AutoSize = true;
            SCREEN.Location = new Point(140, 8);
            SCREEN.Name = "SCREEN";
            SCREEN.Size = new Size(62, 20);
            SCREEN.TabIndex = 0;
            SCREEN.Text = "SCREEN";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(780, 580);
            label6.Name = "label6";
            label6.Size = new Size(134, 20);
            label6.TabIndex = 47;
            label6.Text = "Màu xám: Vé vớt";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Mistral", 25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(373, 23);
            label3.Name = "label3";
            label3.Size = new Size(309, 49);
            label3.TabIndex = 0;
            label3.Text = "The Gentlemen Theater";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(780, 555);
            label5.Name = "label5";
            label5.Size = new Size(169, 20);
            label5.TabIndex = 46;
            label5.Text = "Màu trắng: Vé thường";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(780, 530);
            label4.Name = "label4";
            label4.Size = new Size(143, 20);
            label4.TabIndex = 45;
            label4.Text = "Màu hồng: Vé VIP";
            // 
            // exit
            // 
            exit.BackColor = Color.LightCoral;
            exit.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exit.Location = new Point(386, 491);
            exit.Margin = new Padding(3, 4, 3, 4);
            exit.Name = "exit";
            exit.Size = new Size(131, 59);
            exit.TabIndex = 44;
            exit.Text = "THOÁT";
            exit.UseVisualStyleBackColor = false;
            exit.Click += exit_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.RosyBrown;
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(966, 112);
            panel2.TabIndex = 42;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(SCREEN);
            panel1.Location = new Point(535, 222);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(292, 36);
            panel1.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(233, 413);
            label2.Name = "label2";
            label2.Size = new Size(87, 26);
            label2.TabIndex = 40;
            label2.Text = "Rạp số:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(233, 317);
            label1.Name = "label1";
            label1.Size = new Size(108, 26);
            label1.TabIndex = 39;
            label1.Text = "Tên phim:";
            // 
            // panelSeats
            // 
            panelSeats.Location = new Point(544, 266);
            panelSeats.Margin = new Padding(3, 4, 3, 4);
            panelSeats.Name = "panelSeats";
            panelSeats.Size = new Size(300, 225);
            panelSeats.TabIndex = 38;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResult.Location = new Point(233, 553);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(137, 26);
            lblResult.TabIndex = 37;
            lblResult.Text = "Tổng tiền: 0đ";
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.LightGreen;
            btnCalculate.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCalculate.Location = new Point(238, 491);
            btnCalculate.Margin = new Padding(3, 4, 3, 4);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(132, 59);
            btnCalculate.TabIndex = 36;
            btnCalculate.Text = "TÍNH TIỀN";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // cbRoom
            // 
            cbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoom.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbRoom.FormattingEnabled = true;
            cbRoom.Location = new Point(238, 449);
            cbRoom.Margin = new Padding(3, 4, 3, 4);
            cbRoom.Name = "cbRoom";
            cbRoom.Size = new Size(279, 30);
            cbRoom.TabIndex = 35;
            // 
            // cbMovie
            // 
            cbMovie.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMovie.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbMovie.FormattingEnabled = true;
            cbMovie.Location = new Point(238, 353);
            cbMovie.Margin = new Padding(3, 4, 3, 4);
            cbMovie.Name = "cbMovie";
            cbMovie.Size = new Size(279, 30);
            cbMovie.TabIndex = 34;
            // 
            // pbPoster
            // 
            pbPoster.Location = new Point(12, 222);
            pbPoster.Name = "pbPoster";
            pbPoster.Size = new Size(208, 285);
            pbPoster.SizeMode = PictureBoxSizeMode.Zoom;
            pbPoster.TabIndex = 53;
            pbPoster.TabStop = false;
            pbPoster.Click += pbPoster_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(233, 230);
            label9.Name = "label9";
            label9.Size = new Size(172, 26);
            label9.TabIndex = 55;
            label9.Text = "Tên khách hàng:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCustomerName.Location = new Point(233, 266);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(267, 31);
            txtCustomerName.TabIndex = 56;
            // 
            // BT4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 682);
            Controls.Add(txtCustomerName);
            Controls.Add(label9);
            Controls.Add(pbPoster);
            Controls.Add(progressBar1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button2);
            Controls.Add(ReadFile);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(exit);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelSeats);
            Controls.Add(lblResult);
            Controls.Add(btnCalculate);
            Controls.Add(cbRoom);
            Controls.Add(cbMovie);
            Name = "BT4";
            Text = "BT4";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPoster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label8;
        private Label label7;
        private Button button2;
        private Button ReadFile;
        private Label SCREEN;
        private Label label6;
        private Label label3;
        private Label label5;
        private Label label4;
        private Button exit;
        private Panel panel2;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private FlowLayoutPanel panelSeats;
        private Label lblResult;
        private Button btnCalculate;
        private ComboBox cbRoom;
        private ComboBox cbMovie;
        private PictureBox pbPoster;
        private Label label9;
        private TextBox txtCustomerName;
    }
}