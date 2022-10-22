using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using TemplateBook.Interface;
using TemplateBook.Models;

namespace TemplateBook.Repository
{
    public class LoginRepo : ILogin
    {
        private const string BaseUrl = "https://localhost:7195/api/Users/All";

        private readonly HttpClient _client;
        public LoginRepo (HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<LoginModel>> GetAllAsync()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<LoginModel>>(content);

            return users;
        }

        public async Task<LoginModel> GetByIdAsync(int id)
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<LoginModel>(content);

            return user;
        }

        public async Task<LoginModel> InsertAsync(LoginModel log)
        {
            var content = JsonConvert.SerializeObject(log);
            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add a todo task");
            }

            var insertUser = JsonConvert.DeserializeObject<LoginModel>(await httpResponse.Content.ReadAsStringAsync());
            return insertUser;
        }

        public async Task<LoginModel> UpdateAsync(LoginModel log)
        {
            var content = JsonConvert.SerializeObject(log);
            var httpResponse = await _client.PutAsync($"{BaseUrl}{log.UserId}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update todo task");
            }

            var updateUser = JsonConvert.DeserializeObject<LoginModel>(await httpResponse.Content.ReadAsStringAsync());
            return updateUser;
        }
        public async Task DeleteUserAsync(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{BaseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the todo item");
            }
        }
    }
}
