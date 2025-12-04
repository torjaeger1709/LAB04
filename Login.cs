using System;
using System.Drawing;
using System.Windows.Forms;
using LAB04.services;

namespace LAB04
{
    public partial class Login : Form
    {
        private ApiClient _apiClient;

        public Login()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            
            this.btnLogin.Click += btnLogin_Click;
            this.llblSignUp.Click += llblSignUp_Click;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            btn.BackColor = SystemColors.Control;

            if (string.IsNullOrEmpty(username))
            {
                btn.BackColor = Color.LightCoral;
                MessageBox.Show("Vui lòng nhập Username!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                btn.BackColor = Color.LightCoral;
                MessageBox.Show("Vui lòng nhập Password!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btn.Enabled = false;
            btnLogin.Text = "Đang đăng nhập...";

            try
            {
                var result = await _apiClient.LoginAsync(username, password);

                if (result.success)
                {
                    btn.BackColor = Color.LightGreen;
                    MessageBox.Show(result.message, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Mở form BT7
                    BT7 mainForm = new BT7(_apiClient);
                    mainForm.Show();
                    this.Hide();
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
                btnLogin.Text = "Login";
            }
        }

        private void llblSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp(_apiClient);
            signUpForm.ShowDialog();
        }
    }
}
