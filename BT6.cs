using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB04
{
    public partial class BT6 : Form
    {
        public BT6()
        {
            InitializeComponent();
        }

        // Sự kiện click nút GET
        private async void btnGetInfo_Click(object sender, EventArgs e)
        {
            // 1. Lấy URL và Token từ giao diện
            string url = txtUrl.Text;
            string token = txtToken.Text.Trim();

            // 2. Validate Token (chưa nhập thì chửi)
            if (string.IsNullOrEmpty(token))
            {
                MessageBox.Show("Chưa nhập token", "Thiếu Token", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Khóa nút để tránh spam click
            rtbResponse.Text = "Đang kết nối tới server...";
            btnGetInfo.Enabled = false;

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Authorization = 
                        new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage response = await client.GetAsync(url);
                    string responseString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        rtbResponse.Text = FormatJsonManual(responseString);
                    }
                    else
                    {
                        rtbResponse.Text = $"LỖI RỒI!\nCode: {response.StatusCode}\nChi tiết: {responseString}";
                    }
                }
            }
            catch (Exception ex)
            {
                rtbResponse.Text = "Lỗi Exception: " + ex.Message;
            }
            finally
            {
                // Mở lại nút
                btnGetInfo.Enabled = true;
            }
        }

        // Hàm này tự viết để format JSON cho đẹp
        private string FormatJsonManual(string json)
        {
            return json.Replace("{", "{\n")
                    .Replace("}", "\n}")
                    .Replace(",", ",\n");
        }

    }
}