using System;
using System.Drawing;
using System.Windows.Forms;
using LAB04.services;

namespace LAB04
{
    public partial class ThemMonAn : Form
    {
        private ApiClient _apiClient;
        public event EventHandler DishAdded;

        public ThemMonAn(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            
            this.btnClear.Click += btnClear_Click;
            this.btnThem.Click += btnThem_Click;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenMonAn.Clear();
            txtGia.Clear();
            txtDiaChi.Clear();
            txtHinhAnh.Clear();
            txtMoTa.Clear();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (string.IsNullOrWhiteSpace(txtTenMonAn.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMonAn.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGia.Text) || !long.TryParse(txtGia.Text, out long gia))
            {
                MessageBox.Show("Vui lòng nhập giá hợp lệ!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            btn.BackColor = SystemColors.Control;
            btn.Enabled = false;
            btnThem.Text = "Đang thêm...";

            try
            {
                var result = await _apiClient.AddDishAsync(
                    txtTenMonAn.Text.Trim(),
                    gia,
                    txtDiaChi.Text.Trim(),
                    txtHinhAnh.Text.Trim(),
                    txtMoTa.Text.Trim()
                );

                if (result.success)
                {
                    btn.BackColor = Color.LightGreen;
                    MessageBox.Show(result.message, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    DishAdded?.Invoke(this, EventArgs.Empty);
                    btnClear_Click(null, null);
                    this.Close();
                }
                else
                {
                    btn.BackColor = Color.LightCoral;
                    MessageBox.Show(result.message, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                btn.BackColor = Color.LightCoral;
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn.Enabled = true;
                btnThem.Text = "Thêm";
            }
        }
    }
}
