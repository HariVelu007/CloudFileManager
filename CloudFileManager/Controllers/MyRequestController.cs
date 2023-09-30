using CFMServices.Implementation;
using CFMServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CloudFileManager.Controllers
{
    public class MyRequestController : Controller
    {
        private readonly IUserFileService _userFileService;
        public MyRequestController(IUserFileService userFileService)
        {
            _userFileService = userFileService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
