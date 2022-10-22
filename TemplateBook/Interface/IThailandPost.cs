using TemplateBook.Models;

namespace TemplateBook.Interface
{
    public interface IThailandPost
    {
        public Task<IEnumerable<ThailandPostModel>> GetPostsAsync();
        public Task<ThailandPostModel> GetPostByIdAsync(string zipCode);
        public Task<ThailandPostModel> InsertPostAsync(ThailandPostModel log);
        public Task<ThailandPostModel> UpdatePostAsync(ThailandPostModel log);
        public Task<ThailandPostModel> DeletePostAsync(string id);
    }
}
