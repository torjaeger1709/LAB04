using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LAB04.services
{
    public class ApiClient
    {
        private static readonly string BASE_URL = "https://nt106.uitiot.vn";
        private readonly HttpClient _httpClient;
        private string _accessToken;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BASE_URL);
        }

        public void SetAccessToken(string token)
        {
            _accessToken = token;
            _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public string GetAccessToken()
        {
            return _accessToken;
        }

        // Đăng ký - POST /api/v1/user/signup
        public async Task<(bool success, string message)> SignUpAsync(
            string username, string email, string password,
            string firstName, string lastName, int sex,
            string birthday, string language, string phone)
        {
            try
            {
                var data = new
                {
                    username = username,
                    email = email,
                    password = password,
                    first_name = firstName,
                    last_name = lastName,
                    sex = sex,
                    birthday = birthday,
                    language = language,
                    phone = phone
                };

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/v1/user/signup", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Đăng ký thành công!");
                }
                else
                {
                    var errorObj = JObject.Parse(responseString);
                    string detail = errorObj["detail"]?.ToString() ?? "Đăng ký thất bại";
                    return (false, detail);
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Đăng nhập - POST /auth/token
        public async Task<(bool success, string message, string tokenType, string accessToken)> LoginAsync(
            string username, string password)
        {
            try
            {
                var content = new MultipartFormDataContent
                {
                    { new StringContent(username), "username" },
                    { new StringContent(password), "password" }
                };

                var response = await _httpClient.PostAsync("/auth/token", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var responseObj = JObject.Parse(responseString);
                    string tokenType = responseObj["token_type"]?.ToString();
                    string accessToken = responseObj["access_token"]?.ToString();

                    SetAccessToken(accessToken);
                    return (true, "Đăng nhập thành công!", tokenType, accessToken);
                }
                else
                {
                    var errorObj = JObject.Parse(responseString);
                    string detail = errorObj["detail"]?.ToString() ?? "Đăng nhập thất bại";
                    return (false, detail, null, null);
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message, null, null);
            }
        }

        // Lấy thông tin user hiện tại - GET /api/v1/user/me
        public async Task<(bool success, JObject userData)> GetCurrentUserAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/v1/user/me");
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var userData = JObject.Parse(responseString);
                    return (true, userData);
                }
                else
                {
                    return (false, null);
                }
            }
            catch
            {
                return (false, null);
            }
        }

        // Lấy tất cả món ăn - POST /api/v1/monan/all
        public async Task<(bool success, JObject data)> GetAllDishesAsync(int page = 1, int perPage = 10)
        {
            try
            {
                var requestData = new { page = page, per_page = perPage };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/v1/monan/all", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = JObject.Parse(responseString);
                    return (true, data);
                }
                else
                {
                    return (false, null);
                }
            }
            catch
            {
                return (false, null);
            }
        }

        // Lấy món ăn của bản thân - POST /api/v1/monan/my-dishes
        public async Task<(bool success, JObject data)> GetMyDishesAsync(int page = 1, int perPage = 10)
        {
            try
            {
                var requestData = new { page = page, per_page = perPage };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/v1/monan/my-dishes", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = JObject.Parse(responseString);
                    return (true, data);
                }
                else
                {
                    return (false, null);
                }
            }
            catch
            {
                return (false, null);
            }
        }

        // Thêm món ăn - POST /api/v1/monan/add
        public async Task<(bool success, string message)> AddDishAsync(
            string tenMonAn, long gia, string diaChi, string hinhAnh, string moTa)
        {
            try
            {
                var data = new
                {
                    ten_mon_an = tenMonAn,
                    gia = gia,
                    dia_chi = diaChi,
                    hinh_anh = hinhAnh,
                    mo_ta = moTa
                };

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/v1/monan/add", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Thêm món ăn thành công!");
                }
                else
                {
                    return (false, "Thêm món ăn thất bại!");
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Xóa món ăn - DELETE /api/v1/monan/{id}
        public async Task<(bool success, string message)> DeleteDishAsync(int dishId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/v1/monan/{dishId}");

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Xóa món ăn thành công!");
                }
                else
                {
                    return (false, "Xóa món ăn thất bại!");
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Lấy món ăn theo ID - GET /api/v1/monan/{id}
        public async Task<(bool success, JObject dish)> GetDishByIdAsync(int dishId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/v1/monan/{dishId}");
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var dish = JObject.Parse(responseString);
                    return (true, dish);
                }
                else
                {
                    return (false, null);
                }
            }
            catch
            {
                return (false, null);
            }
        }
    }
}
