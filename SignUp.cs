using System;
using System.Drawing;
using System.Windows.Forms;
using LAB04.services;

namespace LAB04
{
    public partial class SignUp : Form
    {
        private ApiClient _apiClient;

        public SignUp(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            
            this.btnClear.Click += btnClear_Click;
            this.btnSubmit.Click += btnSubmit_Click;
            
            rdoMale.Checked = true;
            dtpBirthday.Value = new DateTime(2000, 1, 1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
            txtPhone.Clear();
            rdoMale.Checked = true;
            dtpBirthday.Value = new DateTime(2000, 1, 1);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Validate
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập Username!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Password phải có ít nhất 8 ký tự!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Vui lòng nhập Email hợp lệ!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            btn.BackColor = SystemColors.Control;
            btn.Enabled = false;
            btnSubmit.Text = "Đang xử lý...";

            try
            {
                int sex = rdoMale.Checked ? 0 : 1;
                string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");

                var result = await _apiClient.SignUpAsync(
                    txtUsername.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text,
                    txtFirstname.Text.Trim(),
                    txtLastname.Text.Trim(),
                    sex,
                    birthday,
                    "vi",
                    txtPhone.Text.Trim()
                );

                if (result.success)
                {
                    btn.BackColor = Color.LightGreen;
                    MessageBox.Show(result.message, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                btnSubmit.Text = "Submit";
            }
        }
    }
}
