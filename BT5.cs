//maikhoa
//12345678
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace LAB04
{
    public partial class BT5 : Form
    {
        public BT5()
        {
            InitializeComponent();

            URL_txb.Text = "https://nt106.uitiot.vn/auth/token";
            pass_txb.PasswordChar = '*';

            
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string url = URL_txb.Text.Trim();
            string username = user_txb.Text.Trim();
            string password = pass_txb.Text;

            richTextBox1.Clear();

            
            btn.BackColor = System.Drawing.SystemColors.Control;

            
            if (string.IsNullOrEmpty(url))
            {
                btn.BackColor = Color.LightCoral;
                MessageBox.Show("Vui lòng nhập địa chỉ URL của API.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(username))
            {
                btn.BackColor = Color.LightCoral;
                MessageBox.Show("Vui lòng nhập Username.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                btn.BackColor = Color.LightCoral;
                MessageBox.Show("Vui lòng nhập Password.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            richTextBox1.AppendText("Đang kết nối...\n");

            using (var client = new HttpClient())
            {
                try
                {
                    var content = new MultipartFormDataContent
                    {
                        { new StringContent(username), "username" },
                        { new StringContent(password), "password" }
                    };

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseString = await response.Content.ReadAsStringAsync();

                    richTextBox1.AppendText("Mã trạng thái HTTP: " + (int)response.StatusCode + " (" + response.ReasonPhrase + ")\n\n");

                    if (response.IsSuccessStatusCode)
                    {
                        
                        btn.BackColor = Color.LightGreen;

                        JObject responseObject = JObject.Parse(responseString);

                        string tokenType = responseObject["token_type"]?.ToString();
                        string accessToken = responseObject["access_token"]?.ToString();

                        richTextBox1.AppendText(".-.ĐĂNG NHẬP THÀNH CÔNG.-.\n");
                        richTextBox1.AppendText($"{tokenType} {accessToken}\n");
                        richTextBox1.AppendText("Đăng nhập thành công");
                    }
                    else
                    {
                        
                        btn.BackColor = Color.LightCoral;

                        JObject responseObject = JObject.Parse(responseString);

                        richTextBox1.AppendText("ĐĂNG NHẬP THẤT BẠI\n");
                        string detail = responseObject["detail"]?.ToString() ?? "Không rõ chi tiết lỗi.";
                        richTextBox1.AppendText($"Chi tiết lỗi: {detail}\n\n");
                        richTextBox1.AppendText("Phản hồi JSON:\n" + responseString);
                    }
                }
                catch (HttpRequestException ex)
                {
                   
                    btn.BackColor = Color.LightCoral;
                    richTextBox1.AppendText("Lỗi yêu cầu HTTP:\n" + ex.Message);
                }
                catch (Exception ex)
                {
                    
                    btn.BackColor = Color.LightCoral;
                    richTextBox1.AppendText("Lỗi chung:\n" + ex.Message);
                }
            }
        }

        
    }
}