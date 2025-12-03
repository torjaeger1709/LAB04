using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class B5 : Form
    {
        private Dictionary<string, (int price, List<int> rooms)> movies =
            new Dictionary<string, (int, List<int>)>();

        private Dictionary<(string movie, int room), List<string>> bookedSeats
            = new Dictionary<(string movie, int room), List<string>>();

        private Dictionary<(string movie, int room), List<string>> selectedSeats
            = new Dictionary<(string movie, int room), List<string>>();

        public B5()
        {
            InitializeComponent();
            this.cbMovie.SelectedIndexChanged += cbMovie_SelectedIndexChanged;
            this.cbRoom.SelectedIndexChanged += cbRoom_SelectedIndexChanged;
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn file chứa tên phim, giá vé và phòng chiếu";
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                movies.Clear();
                cbMovie.Items.Clear();
                cbRoom.Items.Clear();

                string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);

                // Kiểm tra xem số dòng có chia hết cho 3 không
                if (lines.Length % 3 != 0)
                {
                    MessageBox.Show("File không đúng định dạng! (phải gồm: Tên phim, Giá vé, Phòng chiếu)",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đọc 3 dòng một lần
                for (int i = 0; i < lines.Length; i += 3)
                {
                    string name = lines[i].Trim();
                    if (string.IsNullOrWhiteSpace(name)) continue;

                    if (!int.TryParse(lines[i + 1].Trim(), out int price))
                    {
                        MessageBox.Show($"Giá vé không hợp lệ ở dòng {i + 2}");
                        continue;
                    }

                    string[] roomTokens = lines[i + 2].Split(',');
                    List<int> rooms = new List<int>();
                    foreach (string token in roomTokens)
                    {
                        if (int.TryParse(token.Trim(), out int r))
                            rooms.Add(r);
                    }

                    if (rooms.Count == 0)
                    {
                        MessageBox.Show($"Phim '{name}' không có phòng chiếu hợp lệ!");
                        continue;
                    }

                    movies[name] = (price, rooms);
                    cbMovie.Items.Add(name);
                }

                if (cbMovie.Items.Count > 0)
                    cbMovie.SelectedIndex = 0;

                MessageBox.Show("Đọc file thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRoom.Items.Clear();

            if (cbMovie.SelectedItem != null)
            {
                string selected = cbMovie.SelectedItem.ToString();

                if (movies.ContainsKey(selected))
                {
                    foreach (var room in movies[selected].Item2)
                    {
                        cbRoom.Items.Add("Phòng " + room);
                    }
                }

                if (cbRoom.Items.Count > 0)
                    cbRoom.SelectedIndex = 0;
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

            int rows = 3;
            int cols = 5;
            int btnSize = 50;
            int padding = 10;

            string[] rowNames = { "A", "B", "C" };
            string[] veVot = { "A1", "A5", "C1", "C5" };
            string[] veThuong = { "A2", "A3", "A4", "C2", "C3", "C4", "B1", "B5" };
            string[] veVIP = { "B2", "B3", "B4" };

            if (cbMovie.SelectedItem == null || cbRoom.SelectedItem == null)
                return;

            string movie = cbMovie.SelectedItem.ToString();
            int room = int.Parse(cbRoom.SelectedItem.ToString().Replace("Phòng ", ""));
            var key = (movie, room);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    string seatName = rowNames[r] + (c + 1);

                    Button btn = new Button();
                    btn.Name = seatName;
                    btn.Text = seatName;
                    btn.Width = btnSize;
                    btn.Height = btnSize;
                    btn.Left = c * (btnSize + padding);
                    btn.Top = r * (btnSize + padding);

                    if (veVot.Contains(seatName))
                        btn.BackColor = Color.Gray;
                    else if (veVIP.Contains(seatName))
                        btn.BackColor = Color.Pink;
                    else
                        btn.BackColor = Color.White;

                    btn.Tag = btn.BackColor;
                    btn.Click += Seat_Click;

                    if (bookedSeats.ContainsKey(key) && bookedSeats[key].Contains(seatName))
                    {
                        btn.BackColor = Color.Orange;
                        btn.Enabled = false;
                    }
                    else if (selectedSeats.ContainsKey(key) && selectedSeats[key].Contains(seatName))
                    {
                        btn.BackColor = Color.LightGreen;
                    }

                    panelSeats.Controls.Add(btn);
                }
            }

            panelSeats.Width = cols * (btnSize + padding);
            panelSeats.Height = rows * (btnSize + padding);
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string seat = btn.Text;

            if (cbMovie.SelectedItem == null || cbRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng trước khi chọn ghế.");
                return;
            }

            string movie = cbMovie.SelectedItem.ToString();
            int room = int.Parse(cbRoom.SelectedItem.ToString().Replace("Phòng ", ""));
            var key = (movie, room);

            if (!bookedSeats.ContainsKey(key))
                bookedSeats[key] = new List<string>();
            if (!selectedSeats.ContainsKey(key))
                selectedSeats[key] = new List<string>();

            if (bookedSeats[key].Contains(seat))
                return;

            if (selectedSeats[key].Contains(seat))
            {
                selectedSeats[key].Remove(seat);
                btn.BackColor = (Color)btn.Tag;
            }
            else
            {
                int totalSeatsSelected = selectedSeats.SelectMany(kv => kv.Value).Count();
                if (totalSeatsSelected >= 2)
                {
                    MessageBox.Show("Không thể chọn quá 2 vé!", "Giới hạn vé");
                    return;
                }

                selectedSeats[key].Add(seat);
                btn.BackColor = Color.LightGreen;
            }
            lblResult.Text = "Tổng tiền: 0đ";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int total = 0;

            foreach (var kv in selectedSeats)
            {
                string movie = kv.Key.movie;
                int basePrice = movies[movie].Item1;

                foreach (var seat in kv.Value)
                {
                    if (seat.Equals("B2") || seat.Equals("B3") || seat.Equals("B4"))
                        total += (int)(basePrice * 2);
                    else if (seat.Equals("A1") || seat.Equals("A5") || seat.Equals("C1") || seat.Equals("C5"))
                        total += (int)(basePrice * 0.25);
                    else
                        total += basePrice;
                }

                if (!bookedSeats.ContainsKey(kv.Key))
                    bookedSeats[kv.Key] = new List<string>();
                bookedSeats[kv.Key].AddRange(kv.Value);
            }

            selectedSeats.Clear();
            LoadSeatsGrid();
            lblResult.Text = "Tổng tiền: " + total.ToString("N0") + " đ";
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (movies.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu phim để thống kê!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Chọn nơi lưu file thống kê";
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FileName = "output5.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName;
                    await WriteStatisticsToFile(path);
                }
            }
        }

        private async Task WriteStatisticsToFile(string path)
        {
            try
            {
                // Chuẩn bị progress bar
                progressBar1.Value = 0;
                progressBar1.Maximum = movies.Count;

                // Tính toán báo cáo cho từng phim
                var report = new List<(string movie, int sold, int remain, double rate, int revenue)>();

                foreach (var m in movies)
                {
                    string movie = m.Key;
                    int basePrice = m.Value.price;

                    int sold = bookedSeats
                        .Where(x => x.Key.movie == movie)
                        .Sum(x => x.Value.Count);

                    int totalSeats = 15 * m.Value.rooms.Count; // 3x5 ghế mỗi phòng
                    int remain = totalSeats - sold;
                    double rate = totalSeats > 0 ? (double)sold / totalSeats * 100 : 0;

                    int revenue = sold * basePrice;
                    report.Add((movie, sold, remain, rate, revenue));
                }

                // Xếp hạng theo doanh thu (giảm dần)
                var ranked = report
                    .OrderByDescending(x => x.revenue)
                    .Select((x, index) => new
                    {
                        Rank = index + 1,
                        x.movie,
                        x.sold,
                        x.remain,
                        x.rate,
                        x.revenue
                    })
                    .ToList();

                // Ghi file với cột căn đều
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    sw.WriteLine("Thống kê doanh thu phim");
                    sw.WriteLine(new string('-', 100));
                    sw.WriteLine(
                        string.Format("{0,-35} | {1,10} | {2,10} | {3,15} | {4,18} | {5,6}",
                        "Tên phim", "Vé bán ra", "Vé tồn", "Tỉ lệ bán ra (%)", "Doanh thu (đ)", "Hạng"));
                    sw.WriteLine(new string('-', 100));

                    int i = 0;
                    foreach (var item in ranked)
                    {
                        sw.WriteLine(string.Format(
                            "{0,-35} | {1,10} | {2,10} | {3,15:F2} | {4,18:N0} | {5,6}",
                            item.movie, item.sold, item.remain, item.rate, item.revenue, item.Rank));

                        // Cập nhật progress bar
                        i++;
                        progressBar1.Value = i;
                        await Task.Delay(100); // mô phỏng tiến trình
                    }
                }

                MessageBox.Show($"Đã ghi file thống kê thành công:\n{path}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
