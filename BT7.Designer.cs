namespace LAB04
{
    partial class BT7
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.tabMyContributions = new System.Windows.Forms.TabPage();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.flpDishes = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLogout = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblPage = new System.Windows.Forms.Label();
            this.numPage = new System.Windows.Forms.NumericUpDown();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.tabControl.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(338, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÔM NAY ÃN G??";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAll);
            this.tabControl.Controls.Add(this.tabMyContributions);
            this.tabControl.Location = new System.Drawing.Point(19, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 450);
            this.tabControl.TabIndex = 1;
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.flpDishes);
            this.tabAll.Location = new System.Drawing.Point(4, 22);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(752, 424);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // tabMyContributions
            // 
            this.tabMyContributions.Location = new System.Drawing.Point(4, 22);
            this.tabMyContributions.Name = "tabMyContributions";
            this.tabMyContributions.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyContributions.Size = new System.Drawing.Size(752, 424);
            this.tabMyContributions.TabIndex = 1;
            this.tabMyContributions.Text = "Tôi ðóng góp";
            this.tabMyContributions.UseVisualStyleBackColor = true;
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(550, 20);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(100, 30);
            this.btnRandom.TabIndex = 2;
            this.btnRandom.Text = "Ãn g? gi??";
            this.btnRandom.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(670, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm món ãn";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // flpDishes
            // 
            this.flpDishes.AutoScroll = true;
            this.flpDishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDishes.Location = new System.Drawing.Point(3, 3);
            this.flpDishes.Name = "flpDishes";
            this.flpDishes.Size = new System.Drawing.Size(746, 418);
            this.flpDishes.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome,
            this.lblLogout,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(791, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(90, 17);
            this.lblWelcome.Text = "Welcome, User";
            // 
            // lblLogout
            // 
            this.lblLogout.IsLink = true;
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(45, 17);
            this.lblLogout.Text = "Logout";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(550, 518);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(32, 13);
            this.lblPage.TabIndex = 5;
            this.lblPage.Text = "Page";
            // 
            // numPage
            // 
            this.numPage.Location = new System.Drawing.Point(588, 516);
            this.numPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPage.Name = "numPage";
            this.numPage.Size = new System.Drawing.Size(50, 20);
            this.numPage.TabIndex = 6;
            this.numPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(650, 518);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(55, 13);
            this.lblPageSize.TabIndex = 7;
            this.lblPageSize.Text = "Page size";
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(711, 516);
            this.numPageSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(50, 20);
            this.numPageSize.TabIndex = 8;
            this.numPageSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // BT7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 561);
            this.Controls.Add(this.numPageSize);
            this.Controls.Add(this.lblPageSize);
            this.Controls.Add(this.numPage);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblTitle);
            this.Name = "BT7";
            this.Text = "Hôm nay ãn g??";
            this.tabControl.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.TabPage tabMyContributions;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel flpDishes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
        private System.Windows.Forms.ToolStripStatusLabel lblLogout;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.NumericUpDown numPage;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.NumericUpDown numPageSize;
    }
}
