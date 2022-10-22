using TemplateBook.Models;

namespace TemplateBook.Interface
{
    public interface ILogin 
    {
        public Task <IEnumerable<LoginModel>> GetAllAsync();
        public Task <LoginModel> GetByIdAsync(int id);
        public Task <LoginModel> InsertAsync(LoginModel log);
        public Task <LoginModel> UpdateAsync(LoginModel log);
        public  Task DeleteUserAsync(int id);
    }
}
