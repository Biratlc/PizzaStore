using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PizzaGuys.Models;
using PizzaGuys.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PizzaGuys.Controllers
{
    public class AccountController : BaseController
    {

        private PizzaGuysContext _context;

        public AccountController(PizzaGuysContext context)
        {
            _context = context;
        }

        // GET: Account
        public ActionResult Index()
        {

            return View();
        }


        //GET
        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)

        {
            var address = new Address
            {
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                State = model.State,
                Zip = model.Zip
            };
            _context.Address.Add(address);

            var customer = new Customer
            {
                Address = address.AddressId,
                Name = model.Name,
                Email = model.Email,
                Phone = "9856875555"
            };
            _context.Customer.Add(customer);

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        //GET
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LogInViewModel model)
        {
            var email = model.Email;

            var userLog = _context.Customer.SingleOrDefault(u => (u.Email == email)/*||(u.Email==wNum)*/);

            if (userLog != null)
            {
                SetLoggedInUser(userLog);

                var claims = new List<Claim>
                {
                     new Claim(ClaimTypes.Name, email)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. Required when setting the 
                    // ExpireTimeSpan option of CookieAuthenticationOptions 
                    // set with AddCookie. Also required when setting 
                    // ExpiresUtc.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("PizzaHome", "Home");
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }

}