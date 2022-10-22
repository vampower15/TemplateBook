using Newtonsoft.Json;
using TemplateBook.Interface;
using TemplateBook.Models;

namespace TemplateBook.Repository
{
    public class ThailandPostRepo : IThailandPost
    {
        private const string BaseUrl = "https://localhost:7195/api/ThailandPost/";

        private readonly HttpClient _client;
        public ThailandPostRepo(HttpClient client)
        {
            _client = client;
        }

        public Task<ThailandPostModel> DeletePostAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ThailandPostModel> GetPostByIdAsync(string zipCode)
        {
            var postof = await _client.GetAsync($"{BaseUrl}{zipCode}");

            if (!postof.IsSuccessStatusCode)
            {
                throw new Exception($"[{(int)postof.StatusCode} {postof.StatusCode}]");
            }

            var content = await postof.Content.ReadAsStringAsync();
            var zip = JsonConvert.DeserializeObject<ThailandPostModel>(content);
            return zip;
        }


        public Task<IEnumerable<ThailandPostModel>> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ThailandPostModel> InsertPostAsync(ThailandPostModel log)
        {
            throw new NotImplementedException();
        }

        public Task<ThailandPostModel> UpdatePostAsync(ThailandPostModel log)
        {
            throw new NotImplementedException();
        }
    }
}
