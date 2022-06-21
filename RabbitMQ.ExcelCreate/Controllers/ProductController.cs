using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RabbitMQ.ExcelCreate.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
       
        public IActionResult Index()
        {

            return View();
        }
    }
}
