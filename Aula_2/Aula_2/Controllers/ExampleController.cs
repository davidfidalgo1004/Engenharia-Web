using Microsoft.AspNetCore.Mvc;

namespace Aula_2.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection formdata)
        {
            ViewData["text_inserted"]= formdata["name"];
            ViewData["other_Text_inserted"] = formdata["age"];
            return View("Index2");
        }
    }
}
