using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GdmStore.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using GdmStore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;


namespace GdmStore.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
       //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    
                    user = new User { Email = model.Email, Password = model.Password };
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); 

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); 

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин или пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
           
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
     
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }





        //public IActionResult Login()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public IActionResult Login(string userName, string password)
        //{
        //    if (!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    //Check the user name and password  
        //    //Here can be implemented checking logic from the database  
        //    ClaimsIdentity identity = null;
        //    bool isAuthenticated = false;

        //    if (userName == "Admin" && password == "password")
        //    {

        //        //Create the identity for the user  
        //        identity = new ClaimsIdentity(new[] {
        //            new Claim(ClaimTypes.Name, userName),
        //            new Claim(ClaimTypes.Role, "Admin")
        //        }, CookieAuthenticationDefaults.AuthenticationScheme);

        //        isAuthenticated = true;
        //    }

        //    if (userName == "Mukesh" && password == "password")
        //    {
        //        //Create the identity for the user  
        //        identity = new ClaimsIdentity(new[] {
        //            new Claim(ClaimTypes.Name, userName),
        //            new Claim(ClaimTypes.Role, "User")
        //        }, CookieAuthenticationDefaults.AuthenticationScheme);

        //        isAuthenticated = true;
        //    }

        //    if (isAuthenticated)
        //    {
        //        var principal = new ClaimsPrincipal(identity);

        //        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Logout()
        //{
        //    var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Login");
        //}





        //private UserManager<IdentityUser> userManager;
        //private SignInManager<IdentityUser> signInManager;
        //public AccountController(UserManager<IdentityUser> userMgr,
        //SignInManager<IdentityUser> signInMgr)
        //{
        //    userManager = userMgr;
        //    signInManager = signInMgr;
        //}

        //[AllowAnonymous]
        //public ViewResult Login(string returnUrl)
        //{
        //    return View(new LoginModel
        //    {
        //        ReturnUrl = returnUrl
        //    });
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginModel loginModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
        //        if (user != null)
        //        {
        //            await signInManager.SignOutAsync();
        //            if ((await signInManager.PasswordSignInAsync(user,
        //            loginModel.Password, false, false)).Succeeded)
        //            {
        //                return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
        //            }
        //        }
        //    }
        //    ModelState.AddModelError("", "Invalid name or password");
        //    return View(loginModel);
        //}

        //public async Task<RedirectResult> Logout(string returnUrl = "/")
        //{
        //    await signInManager.SignOutAsync();
        //    return Redirect(returnUrl);
        //}

    }
}
       



