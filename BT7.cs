using System;
using System.Drawing;
using System.Windows.Forms;
using LAB04.services;
using Newtonsoft.Json.Linq;

namespace LAB04
{
    public partial class BT7 : Form
    {
        private ApiClient _apiClient;
        private string _currentUsername;
        private int _currentPage = 1;
        private int _currentPageSize = 5;
        private bool _isLoadingMyDishes = false;

        public BT7(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            
            this.Load += BT7_Load;
            this.btnRandom.Click += btnRandom_Click;
            this.btnAdd.Click += btnAdd_Click;
            this.lblLogout.Click += lblLogout_Click;
            this.numPage.ValueChanged += numPage_ValueChanged;
            this.numPageSize.ValueChanged += numPageSize_ValueChanged;
            this.tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            
            // Add FlowLayoutPanel to "Tôi đóng góp" tab
            FlowLayoutPanel flpMyDishes = new FlowLayoutPanel();
            flpMyDishes.AutoScroll = true;
            flpMyDishes.Dock = DockStyle.Fill;
            flpMyDishes.Name = "flpMyDishes";
            tabMyContributions.Controls.Add(flpMyDishes);
        }

        private async void BT7_Load(object sender, EventArgs e)
        {
            progressBar.Style = ProgressBarStyle.Marquee;
            
            // Load user info
            var userResult = await _apiClient.GetCurrentUserAsync();
            if (userResult.success && userResult.userData != null)
            {
                _currentUsername = userResult.userData["username"]?.ToString();
                lblWelcome.Text = $"Welcome, {_currentUsername}";
            }
            
            await LoadDishesAsync();
            
            progressBar.Style = ProgressBarStyle.Continuous;
        }

        private async System.Threading.Tasks.Task LoadDishesAsync()
        {
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Marquee;

            try
            {
                FlowLayoutPanel targetPanel = _isLoadingMyDishes 
                    ? tabMyContributions.Controls["flpMyDishes"] as FlowLayoutPanel 
                    : flpDishes;
                
                targetPanel.Controls.Clear();

                var result = _isLoadingMyDishes
                    ? await _apiClient.GetMyDishesAsync(_currentPage, _currentPageSize)
                    : await _apiClient.GetAllDishesAsync(_currentPage, _currentPageSize);

                if (result.success && result.data != null)
                {
                    var dishes = result.data["data"] as JArray;
                    var pagination = result.data["pagination"] as JObject;

                    if (dishes != null)
                    {
                        foreach (JObject dish in dishes)
                        {
                            var dishPanel = CreateDishPanel(dish);
                            targetPanel.Controls.Add(dishPanel);
                        }
                    }

                    // Update pagination
                    if (pagination != null)
                    {
                        int totalPages = (int)(pagination["total_pages"] ?? 1);
                        numPage.Maximum = totalPages > 0 ? totalPages : 1;
                        numPage.Value = _currentPage;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể tải danh sách món ăn!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = 100;
            }
        }

        private Panel CreateDishPanel(JObject dish)
        {
            Panel panel = new Panel();
            panel.Width = flpDishes.Width - 30;
            panel.Height = 120;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Padding = new Padding(5);

            PictureBox pb = new PictureBox();
            pb.Width = 100;
            pb.Height = 100;
            pb.Location = new Point(5, 10);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.FixedSingle;

            string imageUrl = dish["hinh_anh"]?.ToString();
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try { pb.Load(imageUrl); } 
                catch { pb.BackColor = Color.LightGray; }
            }

            Label lblName = new Label();
            lblName.Text = dish["ten_mon_an"]?.ToString() ?? "N/A";
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.Location = new Point(115, 10);
            lblName.AutoSize = true;

            Label lblPrice = new Label();
            long price = dish["gia"]?.ToObject<long>() ?? 0;
            lblPrice.Text = $"Giá: {price:N0} VNĐ";
            lblPrice.Location = new Point(115, 35);
            lblPrice.AutoSize = true;

            Label lblAddress = new Label();
            lblAddress.Text = "Địa chỉ: " + (dish["dia_chi"]?.ToString() ?? "N/A");
            lblAddress.Location = new Point(115, 55);
            lblAddress.AutoSize = true;

            Label lblContributor = new Label();
            lblContributor.Text = "Đóng góp: " + (dish["nguoi_dong_gop"]?.ToString() ?? "N/A");
            lblContributor.Location = new Point(115, 75);
            lblContributor.AutoSize = true;

            panel.Controls.Add(pb);
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(lblAddress);
            panel.Controls.Add(lblContributor);

            // Nếu là tab "Tôi đóng góp", thêm nút xóa
            if (_isLoadingMyDishes)
            {
                Button btnDelete = new Button();
                btnDelete.Text = "Xóa";
                btnDelete.Location = new Point(panel.Width - 85, 40);
                btnDelete.Size = new Size(75, 30);
                int dishId = dish["id"]?.ToObject<int>() ?? 0;
                btnDelete.Click += async (s, e) => await DeleteDish(dishId);
                panel.Controls.Add(btnDelete);
            }

            // Click để xem chi tiết
            panel.Click += (s, e) => ShowDishDetail(dish);
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Click += (s, e) => ShowDishDetail(dish);
            }

            return panel;
        }

        private void ShowDishDetail(JObject dish)
        {
            string detail = $"Tên món: {dish["ten_mon_an"]}\n" +
                          $"Giá: {dish["gia"]:N0} VNĐ\n" +
                          $"Địa chỉ: {dish["dia_chi"]}\n" +
                          $"Người đóng góp: {dish["nguoi_dong_gop"]}\n" +
                          $"Mô tả: {dish["mo_ta"]}";
            
            MessageBox.Show(detail, "Chi tiết món ăn", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async System.Threading.Tasks.Task DeleteDish(int dishId)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn xóa món ăn này?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (confirm == DialogResult.Yes)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                
                var result = await _apiClient.DeleteDishAsync(dishId);
                
                progressBar.Style = ProgressBarStyle.Continuous;

                if (result.success)
                {
                    MessageBox.Show(result.message, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDishesAsync();
                }
                else
                {
                    MessageBox.Show(result.message, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRandom_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng random món ăn chưa có API endpoint!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemMonAn addForm = new ThemMonAn(_apiClient);
            addForm.DishAdded += async (s, args) => await LoadDishesAsync();
            addForm.ShowDialog();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                this.Close();
                Login loginForm = new Login();
                loginForm.Show();
            }
        }

        private async void numPage_ValueChanged(object sender, EventArgs e)
        {
            _currentPage = (int)numPage.Value;
            await LoadDishesAsync();
        }

        private async void numPageSize_ValueChanged(object sender, EventArgs e)
        {
            _currentPageSize = (int)numPageSize.Value;
            _currentPage = 1;
            await LoadDishesAsync();
        }

        private async void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isLoadingMyDishes = (tabControl.SelectedIndex == 1);
            _currentPage = 1;
            await LoadDishesAsync();
        }
    }
}
