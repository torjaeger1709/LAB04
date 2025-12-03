using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LAB04
{
    public partial class BT2 : Form
    {
        public BT2()
        {
            InitializeComponent();
            lblUrl.Text = "URL:";
            lblFilePath.Text = "Đường dẫn:";
            lblContent.Text = "Nội dung trang web:";
            btnBrowse.Text = "Chọn file...";
            btnDownload.Text = "Download";
            this.Text = "Bài 2 - Download Web Content";
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            string filePath = txtFilePath.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUrl.Focus();
                return;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFilePath.Focus();
                return;
            }

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            btnDownload.Enabled = false;
            rtbContent.Text = "Đang tải nội dung trang web...\n";
            
            try
            {
                using (WebClient myClient = new WebClient())
                {
                    myClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
                    
                    myClient.Encoding = Encoding.UTF8;

                    string htmlContent = await myClient.DownloadStringTaskAsync(url);
                    
                    rtbContent.Text = htmlContent;

                    await myClient.DownloadFileTaskAsync(url, filePath);

                    MessageBox.Show($"Tải thành công!\nFile được lưu tại: {filePath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (WebException ex)
            {
                rtbContent.Text = $"Lỗi kết nối: {ex.Message}";
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                rtbContent.Text = $"Lỗi: {ex.Message}";
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDownload.Enabled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "HTML Files (*.html)|*.html|All files (*.*)|*.*";
                saveDialog.DefaultExt = "html";
                saveDialog.FileName = "webpage.html";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = saveDialog.FileName;
                }
            }
        }
    }
}
