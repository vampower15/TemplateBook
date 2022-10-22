using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using TemplateBook.Interface;
using TemplateBook.Repository;

namespace TemplateBook.Controllers
{
    public class ThailandPostController : Controller
    {
        private readonly IThailandPost _post;
        public ThailandPostController(IThailandPost zipcode)
        {
            _post = zipcode;
        }

        public IActionResult ThailandPost()
        {
            return View();
        }

        public async Task<IActionResult> GetThailandPostById(string zipCode)
        {
            try
            {
                var result = await _post.GetPostByIdAsync(zipCode);
                if (result is null)
                {
                    return Ok(new { IsSuccess = false, Message = "Data not found", Result = "" });
                }
                return Ok(new { IsSuccess = true, Message = "Succress", Result = result });
            }
            catch (Exception ex)
            {
                return Ok(new { IsSuccess = false, Message = ex.Message, Result = "" });
            }
        }
    }
}