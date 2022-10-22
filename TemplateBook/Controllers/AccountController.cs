using Microsoft.AspNetCore.Mvc;
using TemplateBook.Interface;

namespace TemplateBook.Controllers
{
    public class AccountController : Controller
    {
        public readonly ILogin _user;

        public AccountController(ILogin user)
        {
            _user = user;
        }
        public IActionResult Login()
        {
            return View();
        }

        //public IActionResult GetUser(string userName,string passWord)
        //{
        //    if (string.IsNullOrEmpty(userName)) return Ok(new { IsSuccess = false, Message = "Don't empty" });
        //    if (string.IsNullOrEmpty(passWord)) return Ok(new { IsSuccess = false, Message = "Don't empty" });

        //    if (!userName.Equals("vampower")) return Ok(new { IsSuccess = false, Message = "Not Valid" });
        //    if (!passWord.Equals("0878937857")) return Ok(new { IsSuccess = false, Message = "Not Valid" });
        //    return Ok(new { IsSuccess = true, Message = "Login Success.", Url = "/Home/index" });
        //}

        public async Task<IActionResult> GetUser(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName)) return Ok(new { IsSuccess = false, Message = "Don't empty" });
            if (string.IsNullOrEmpty(passWord)) return Ok(new { IsSuccess = false, Message = "Don't empty" });

            var user = await _user.GetAllAsync();

            var isEmail = userName.Contains("@");
            if (isEmail)
            {
                var result = user.FirstOrDefault(x => x.Email.Equals(userName) && x.Password.Equals(passWord));
                if (result is null)
                {
                    return Ok(new { IsSuccess = false, Message = "User not found in the system" });
                }
            }
            else
            {
                var result = user.FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(passWord));
                if (result is null)
                {
                    return Ok(new { IsSuccess = false, Message = "User not found in the system" });
                }
            }
            return Ok(new { IsSuccess = true, Message = "Login Success!", Url = "/Home/index" ,Key = Guid.NewGuid()});
        }
    }
}
