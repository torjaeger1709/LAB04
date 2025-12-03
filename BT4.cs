#nullable disable // Tắt các cảnh báo null warning màu vàng

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Diagnostics;

namespace LAB04
{
    // CLASS FORM CHÍNH
    public partial class BT4 : Form
    {
        // 1. Danh sách phim lấy từ Web
        private List<MovieInfo> movieList = new List<MovieInfo>();

        // 2. Quản lý các ghế đang ĐƯỢC CHỌN (màu xanh lá)
        // Key: (Tên phim, Số phòng) -> Value: Danh sách tên ghế
        private Dictionary<(string movie, int room), List<string>> selectedSeats
            = new Dictionary<(string movie, int room), List<string>>();

        // 3. Quản lý thông tin CHI TIẾT các ghế ĐÃ ĐẶT (màu cam)
        // Key: (Tên phim, Số phòng, Tên ghế) -> Value: Thông tin người đặt (Bill)
        private Dictionary<(string movie, int room, string seat), BillInfo> seatHistory
            = new Dictionary<(string movie, int room, string seat), BillInfo>();

        public BT4()
        {
            InitializeComponent();

            // Gán sự kiện
            this.cbMovie.SelectedIndexChanged += cbMovie_SelectedIndexChanged;
            this.cbRoom.SelectedIndexChanged += cbRoom_SelectedIndexChanged;
            if (pbPoster != null) this.pbPoster.Click += pbPoster_Click;
        }

        // --- CÁC HÀM XỬ LÝ SỰ KIỆN ---

        private async void ReadFile_Click(object sender, EventArgs e)
        {
            string url = "https://betacinemas.vn/phim.htm";

            try
            {
                progressBar1.Value = 10;
                using (HttpClient client = new HttpClient())
                {
                    // Giả lập trình duyệt để tránh bị chặn
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");

                    string html = await client.GetStringAsync(url);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    progressBar1.Value = 30;

                    // XPath lấy danh sách phim
                    var movieNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'tab-content')]//div[contains(@class, 'col-')][.//img and .//a]");

                    if (movieNodes == null || movieNodes.Count == 0)
                    {
                        MessageBox.Show("Không lấy được dữ liệu phim! Vui lòng kiểm tra lại kết nối mạng.");
                        return;
                    }

                    movieList.Clear();
                    cbMovie.Items.Clear();
                    cbRoom.Items.Clear();
                    progressBar1.Maximum = movieNodes.Count + 30;

                    foreach (var node in movieNodes)
                    {
                        MovieInfo movie = new MovieInfo();

                        // Lấy tên và link
                        var titleNode = node.SelectSingleNode(".//h3/a") ?? node.SelectSingleNode(".//div[contains(@class,'film-info')]//a");
                        if (titleNode == null) titleNode = node.SelectSingleNode(".//a[contains(@href, 'chi-tiet-phim')]");

                        if (titleNode != null)
                        {
                            movie.Name = WebUtility.HtmlDecode(titleNode.InnerText.Trim());
                            string href = titleNode.GetAttributeValue("href", "");
                            movie.DetailUrl = href.StartsWith("http") ? href : "https://betacinemas.vn" + href;
                        }
                        else continue;

                        // Lấy ảnh
                        var imgNode = node.SelectSingleNode(".//img");
                        if (imgNode != null) movie.ImageUrl = imgNode.GetAttributeValue("src", "");

                        // Giả lập dữ liệu phòng/giá
                        movie.Price = 90000;
                        movie.Rooms = new List<int> { 1, 2, 3 };

                        movieList.Add(movie);
                        cbMovie.Items.Add(movie.Name);

                        progressBar1.Value++;
                    }

                    // Lưu JSON
                    string json = JsonConvert.SerializeObject(movieList, Formatting.Indented);
                    File.WriteAllText("movies.json", json);

                    MessageBox.Show($"Đã cập nhật {movieList.Count} phim mới!");
                    if (cbMovie.Items.Count > 0) cbMovie.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void cbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRoom.Items.Clear();
            if (cbMovie.SelectedItem != null)
            {
                string selectedName = cbMovie.SelectedItem.ToString();
                var movie = movieList.FirstOrDefault(m => m.Name == selectedName);

                if (movie != null)
                {
                    foreach (var room in movie.Rooms) cbRoom.Items.Add("Phòng " + room);
                    if (!string.IsNullOrEmpty(movie.ImageUrl))
                    {
                        try { pbPoster.Load(movie.ImageUrl); } catch { pbPoster.Image = null; }
                    }
                }
                if (cbRoom.Items.Count > 0) cbRoom.SelectedIndex = 0;
            }
            lblResult.Text = "Tổng tiền: 0đ";
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSeatsGrid();
        }

        private void LoadSeatsGrid()
        {
            panelSeats.Controls.Clear();
            int rows = 3; int cols = 5;
            int btnSize = 50; int padding = 10;

            string[] rowNames = { "A", "B", "C" };
            string[] veVot = { "A1", "A5", "C1", "C5" };
            string[] veVIP = { "B2", "B3", "B4" };

            if (cbMovie.SelectedItem == null || cbRoom.SelectedItem == null) return;

            string movieName = cbMovie.SelectedItem.ToString();
            int room = int.Parse(cbRoom.SelectedItem.ToString().Replace("Phòng ", ""));
            var keySelect = (movieName, room);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    string seatName = rowNames[r] + (c + 1);
                    var keySeat = (movieName, room, seatName); // Key để tra cứu lịch sử đặt

                    Button btn = new Button();
                    btn.Name = seatName;
                    btn.Text = seatName;
                    btn.Width = btnSize; btn.Height = btnSize;
                    btn.Left = c * (btnSize + padding);
                    btn.Top = r * (btnSize + padding);
                    btn.Click += Seat_Click;

                    // 1. Kiểm tra xem ghế đã được Mua chưa (Màu Cam)
                    if (seatHistory.ContainsKey(keySeat))
                    {
                        btn.BackColor = Color.Orange;
                        // QUAN TRỌNG: Vẫn để Enable = true để click vào xem thông tin
                        btn.Enabled = true;
                    }
                    // 2. Kiểm tra xem ghế đang được Chọn để mua (Màu Xanh Lá)
                    else if (selectedSeats.ContainsKey(keySelect) && selectedSeats[keySelect].Contains(seatName))
                    {
                        btn.BackColor = Color.LightGreen;
                        btn.Tag = GetOriginalColor(seatName, veVot, veVIP); // Lưu màu gốc
                    }
                    // 3. Ghế trống (Màu gốc)
                    else
                    {
                        btn.BackColor = GetOriginalColor(seatName, veVot, veVIP);
                        btn.Tag = btn.BackColor; // Lưu màu gốc vào Tag để restore
                    }

                    panelSeats.Controls.Add(btn);
                }
            }
            panelSeats.Width = cols * (btnSize + padding);
            panelSeats.Height = rows * (btnSize + padding);
        }

        private Color GetOriginalColor(string seatName, string[] veVot, string[] veVIP)
        {
            if (veVot.Contains(seatName)) return Color.Gray;
            if (veVIP.Contains(seatName)) return Color.Pink;
            return Color.White;
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string seat = btn.Text;

            if (cbMovie.SelectedItem == null || cbRoom.SelectedItem == null) return;
            string movieName = cbMovie.SelectedItem.ToString();
            int room = int.Parse(cbRoom.SelectedItem.ToString().Replace("Phòng ", ""));

            // --- TRƯỜNG HỢP 1: Bấm vào ghế ĐÃ BÁN (Màu Cam) ---
            var keySeat = (movieName, room, seat);
            if (seatHistory.ContainsKey(keySeat))
            {
                var bill = seatHistory[keySeat];
                string info = $"--- THÔNG TIN VÉ ĐÃ ĐẶT ---\n" +
                              $"Khách hàng: {bill.CustomerName}\n" +
                              $"Ghế: {string.Join(", ", bill.BookedSeats)}\n" +
                              $"Tổng tiền hóa đơn: {bill.TotalAmount:N0} đ\n" +
                              $"Thời gian đặt: {bill.BookingTime:dd/MM/yyyy HH:mm:ss}";
                MessageBox.Show(info, "Chi tiết đặt vé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Kết thúc, không cho chọn ghế này nữa
            }

            // --- TRƯỜNG HỢP 2: Chọn/Bỏ chọn ghế để mua ---
            var keySelect = (movieName, room);
            if (!selectedSeats.ContainsKey(keySelect)) selectedSeats[keySelect] = new List<string>();

            if (selectedSeats[keySelect].Contains(seat))
            {
                // Bỏ chọn -> Trả về màu gốc
                selectedSeats[keySelect].Remove(seat);
                btn.BackColor = (Color)btn.Tag;
            }
            else
            {
                // Chọn mới -> Màu xanh lá
                selectedSeats[keySelect].Add(seat);
                btn.BackColor = Color.LightGreen;
            }

            // Tạm thời hiển thị 0đ cho đến khi nhấn Tính tiền
            lblResult.Text = "Tổng tiền: ... (Nhấn Tính Tiền)";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Kiểm tra tên khách hàng
            if (txtCustomerName == null || string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Khách Hàng trước khi thanh toán!", "Thiếu thông tin");
                if (txtCustomerName != null) txtCustomerName.Focus();
                return;
            }

            int total = 0;
            string customerName = txtCustomerName.Text.Trim();
            List<string> currentBookingSeats = new List<string>();

            // Tính tiền cho các ghế đang chọn (trong selectedSeats)
            foreach (var kv in selectedSeats)
            {
                string movieName = kv.Key.movie;
                int room = kv.Key.room;
                var movieObj = movieList.FirstOrDefault(m => m.Name == movieName);
                if (movieObj == null) continue;

                int basePrice = movieObj.Price;

                foreach (var seat in kv.Value)
                {
                    // Tính giá vé
                    int seatPrice = basePrice;
                    if (seat == "B2" || seat == "B3" || seat == "B4") seatPrice = basePrice * 2;
                    else if (seat == "A1" || seat == "A5" || seat == "C1" || seat == "C5") seatPrice = (int)(basePrice * 0.25);

                    total += seatPrice;
                    currentBookingSeats.Add(seat); // Thêm vào danh sách tạm để tạo Bill
                }
            }

            if (total == 0)
            {
                MessageBox.Show("Bạn chưa chọn ghế nào!", "Thông báo");
                return;
            }

            // Tạo Bill thông tin chung
            BillInfo newBill = new BillInfo
            {
                CustomerName = customerName,
                TotalAmount = total,
                BookingTime = DateTime.Now,
                BookedSeats = new List<string>(currentBookingSeats)
            };

            // Lưu dữ liệu vào seatHistory (Chuyển trạng thái sang Đã bán)
            foreach (var kv in selectedSeats)
            {
                string movieName = kv.Key.movie;
                int room = kv.Key.room;

                foreach (var seat in kv.Value)
                {
                    var keySeat = (movieName, room, seat);
                    // Lưu bill cho từng ghế để click vào ghế nào cũng xem được bill đó
                    seatHistory[keySeat] = newBill;
                }
            }

            // Xóa danh sách đang chọn (vì đã mua xong)
            selectedSeats.Clear();

            // Vẽ lại ghế
            LoadSeatsGrid();

            // Hiển thị Bill JSON
            string jsonBill = JsonConvert.SerializeObject(newBill, Formatting.Indented);
            lblResult.Text = "Tổng tiền: " + total.ToString("N0") + " đ";
            MessageBox.Show($"Thanh toán thành công!\n\n{jsonBill}", "Hóa đơn điện tử");

            // Reset ô nhập tên
            txtCustomerName.Text = "";
        }

        private void pbPoster_Click(object sender, EventArgs e)
        {
            if (cbMovie.SelectedItem == null) return;
            var movie = movieList.FirstOrDefault(m => m.Name == cbMovie.SelectedItem.ToString());
            if (movie != null && !string.IsNullOrEmpty(movie.DetailUrl))
            {
                Process.Start(new ProcessStartInfo { FileName = movie.DetailUrl, UseShellExecute = true });
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (movieList.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu phim!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "output_thongke.txt";
                if (sfd.ShowDialog() == DialogResult.OK) await WriteStatisticsToFile(sfd.FileName);
            }
        }

        private async Task WriteStatisticsToFile(string path)
        {
            // Logic thống kê giữ nguyên, lấy dữ liệu từ seatHistory
            try
            {
                progressBar1.Value = 0; progressBar1.Maximum = movieList.Count;
                var report = new List<dynamic>();

                foreach (var m in movieList)
                {
                    // Đếm số ghế đã bán trong seatHistory cho phim này
                    int sold = seatHistory.Keys.Count(k => k.movie == m.Name);

                    int totalSeats = 15 * m.Rooms.Count;
                    int revenue = sold * m.Price; // Tính đơn giản theo giá gốc để thống kê nhanh

                    // Nếu muốn tính doanh thu chính xác từng vé (VIP/Thường) thì phải loop qua seatHistory values
                    // Ở đây làm đơn giản theo yêu cầu bài cũ:

                    report.Add(new
                    {
                        Name = m.Name,
                        Sold = sold,
                        Remain = totalSeats - sold,
                        Revenue = revenue
                    });

                    progressBar1.Value++;
                    await Task.Delay(20);
                }

                var lines = new List<string> { "BÁO CÁO DOANH THU", new string('-', 50) };
                foreach (var r in report.OrderByDescending(x => x.Revenue))
                {
                    lines.Add($"Phim: {r.Name} | Vé: {r.Sold} | Thu: {r.Revenue:N0} đ");
                }

                File.WriteAllLines(path, lines);
                MessageBox.Show("Xuất file thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }

    // --- CÁC CLASS DỮ LIỆU (ĐỂ Ở CUỐI CÙNG) ---

    public class MovieInfo
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<int> Rooms { get; set; }
        public string ImageUrl { get; set; }
        public string DetailUrl { get; set; }
    }

    public class BillInfo
    {
        public string CustomerName { get; set; }
        public List<string> BookedSeats { get; set; }
        public int TotalAmount { get; set; }
        public DateTime BookingTime { get; set; }
    }
}