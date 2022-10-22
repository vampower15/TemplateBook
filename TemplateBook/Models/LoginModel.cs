using Microsoft.AspNetCore.Http;

namespace TemplateBook.Models
{
    public class LoginModel
    {
        public int UserId { get; set; } = 0;
        public string UserName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public int StatusId { get; set; } = 0;
    }
}
