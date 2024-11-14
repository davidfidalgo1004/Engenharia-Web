using Microsoft.AspNetCore.Mvc;

namespace Aula9.Controllers
{
    public class TestCacheController : Controller
    {
        [ResponseCache(Duration = 20,Location =ResponseCacheLocation.Client)]
        public IActionResult OnClient()
        {
            return View();
        }
        [ResponseCache(Duration = 40, Location = ResponseCacheLocation.Any)]
        public IActionResult OnDownStream() { return View(); }

        [ResponseCache(CacheProfileName ="TestCacheProfile")]
        public IActionResult WithHeaders() { return View(); }

        
    }
}
