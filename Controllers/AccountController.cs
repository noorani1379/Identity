using Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Text;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {

        //CTOR
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            
                return View();

            //Initiat Object
          var result = await _userManager.CreateAsync(new IdentityUser()
          {
              UserName = model.UserName,
              Email = model.Email,
              PhoneNumber = model.Phone,
          },  model.Password);//for Hashing

            if (!result.Succeeded)
            {
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                    return View();
                }
            }
            // make TOKEN
            var user= await _userManager.FindByNameAsync(model.UserName);

            var token= await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //encode
            token= WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            //url for click to confirm
            string? callBackUrl = Url.ActionLink("ConfirmEmail", "Account", new { UserId = user.Id, token = token }, Request.Scheme);


            return RedirectToAction("Login");
        }
    }
}
