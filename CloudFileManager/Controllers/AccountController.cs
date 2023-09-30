using AutoMapper;
using CFMDomainModel;
using CFMServices.Interface;
using CFMServices.Model;
using CloudFileManager.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using UI_COMMON_HELPER;
using UI_COMMON_HELPER.Helper;

namespace CloudFileManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper= mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginView login)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }
            ValidationModel<User> user= await _userService.Login(login.UserMail, login.Password);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Model.ID.ToString()),
                new Claim(ClaimTypes.Email, user.Model.UserMail),
                new Claim(ClaimTypes.Name, user.Model.UserName)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principle = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle, new AuthenticationProperties()
            {
                IsPersistent= true
            });
            return RedirectToAction("Index", "DashBoard");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return PartialView("Register",new RegisterView());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterView register)
        {
            if(!ModelState.IsValid)
            {
                return PartialView("Register", register);
            }
            Validation validationres= await _userService.ValidateUser(register.UserMail);
            if(validationres.IsError)
            {
                ModelState.AddModelError("UserMail", validationres.Message);
                return PartialView("Register", register);
            }
            User user= _mapper.Map<User>(register);
            bool result = await _userService.AddUser(user, register.Password);

            ViewBag.Message = result ? AlertService.Show(Alert.Success, "User registered successfully")  : AlertService.Show(Alert.Success, "User registration failed");

            return PartialView("Register", new RegisterView());
        }
    }
}
