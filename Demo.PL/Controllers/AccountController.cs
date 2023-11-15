using Demo.DAL.Enitities;
using Demo.PL.Helper;
using Demo.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Demo.PL.Controllers
{

    public class AccountController : Controller

    {
        private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

	
		public AccountController(
            UserManager<ApplicationUser> userManager,
		   SignInManager<ApplicationUser> signInManager
            )
        {

            _userManager = userManager;
			_signInManager = signInManager;
			//_signInManager = signInManager;

		}

	

		//public IActionResult SignUp()
		//{

		//    return View(new SignUpViewModel());
		//}





		public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email.Split('@')[0],
                    IsAgree = model.IsAgree,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return RedirectToAction("Login");
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);


            }
            return View(model);
        }

        public IActionResult Login( string? ReturnUrl)
        {

            return View(new SignInViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is null)
                    ModelState.AddModelError("", "Invaild Email");
                var isCorrectPassword = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!isCorrectPassword)
                {
                 
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe,false);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                }

            }


            return View(model); 

        }


        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }




        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
            
            if(user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetPasswordLink =Url.Action("ResetPassword","Account" , new { model.Email,Token=token },Request.Scheme);
                var email = new Email
                {
                    Title = "ResetPassword",
                    Body = resetPasswordLink,
                    To = model.Email
                };

                    EmailSettings.SendEmail(email);
                    return RedirectToAction("CompleteForgetPassword");
          
            }
                ModelState.AddModelError("", "Invalid Email");
            }
            return View();
        }

        public IActionResult CompleteForgetPassword()
        {
            return View();
        }

        public IActionResult ResetPassword( string Email , string Token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                        return RedirectToAction("Login");
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);

                }
            }
            return View(model);
        }


        public IActionResult AccessDenied()
        {

            return View();
        }
    }     


}
