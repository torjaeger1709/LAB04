using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace LAB04
{
    public partial class BT3 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public BT3()
        {
            InitializeComponent();
            btnLoad.Enabled = false;
            btnReload.Enabled = false;
        }

        private async void BT3_Load_1(object sender, EventArgs e)
        {
            await InitWebView();
        }

        async Task InitWebView()
        {
            try
            {
                string userDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Lab04_Browser_Data");
                var env = await CoreWebView2Environment.CreateAsync(null, userDataFolder);
                await webView.EnsureCoreWebView2Async(env);

                btnLoad.Enabled = true;
                btnReload.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\n");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (webView.CoreWebView2 == null)
            {
                MessageBox.Show("Trình duyệt chưa sẵn sàng. Vui lòng đợi 1 chút.");
                return;
            }

            string url = txtUrl.Text.Trim();
            if (string.IsNullOrEmpty(url)) return;

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
                txtUrl.Text = url;
            }

            try
            {
                webView.CoreWebView2.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (webView.CoreWebView2 != null) webView.Reload();
        }
        private async void btnFiles_Click(object sender, EventArgs e)
        {
            string url = webView.Source.ToString();

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "HTML Files (*.html)|*.html|All files (*.*)|*.*";
            saveDialog.FileName = "index.html";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string htmlContent = await _httpClient.GetStringAsync(url);
                    File.WriteAllText(saveDialog.FileName, htmlContent);
                    MessageBox.Show("Đã tải file HTML thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải file: " + ex.Message);
                }
            }
        }

        private async void btnResources_Click(object sender, EventArgs e)
        {
            string url = webView.Source.ToString();
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = folderDialog.SelectedPath;

                try
                {
                    string htmlContent = await _httpClient.GetStringAsync(url);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlContent);
                    var imgNodes = doc.DocumentNode.SelectNodes("//img");
                    if (imgNodes == null || imgNodes.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy hình ảnh nào trên trang web.");
                        return;
                    }
                    int count = 0;
                    foreach (var img in imgNodes)
                    {
                        string src = img.GetAttributeValue("src", "");
                        if (string.IsNullOrEmpty(src)) continue;

                        Uri baseUri = new Uri(url);
                        Uri fullUri = new Uri(baseUri, src);

                        try
                        {
                            byte[] imageBytes = await _httpClient.GetByteArrayAsync(fullUri);

                            string fileName = Path.GetFileName(fullUri.LocalPath);
                            if (string.IsNullOrEmpty(fileName) || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                            {
                                fileName = $"image_{count}.jpg";
                            }

                            string destFile = Path.Combine(savePath, fileName);

                            await File.WriteAllBytesAsync(destFile, imageBytes);
                            count++;
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    MessageBox.Show($"Đã tải xong {count} hình ảnh vào thư mục: {savePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải tài nguyên: " + ex.Message);
                }
            }
        }

    }
}
