using CFMServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CloudFileManager.Controllers
{
    public class SharedFileController : Controller
    {
        private readonly IUserFileService _userFileService;
        public SharedFileController(IUserFileService userFileService)
        {
            _userFileService = userFileService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
