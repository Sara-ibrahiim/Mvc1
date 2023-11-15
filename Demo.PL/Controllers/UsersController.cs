using Demo.DAL.Enitities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(UserManager<ApplicationUser> userManager , ILogger<UsersController> logger) {
           _userManager = userManager;
            _logger = logger;
        }
          public async Task <IActionResult> Index(string SearchValue = "")
          {
            List<ApplicationUser> applicationUsers;
            if (string.IsNullOrEmpty(SearchValue))
                applicationUsers = await _userManager.Users.ToListAsync();
            else
                applicationUsers = await _userManager.Users.Where(user => user.Email.Trim().ToLower().Contains(SearchValue.Trim().ToLower())).ToListAsync();


            return View (applicationUsers);
           }

        public async Task <IActionResult> Details (string id, string viewName="Details")
        {
            if (id is null)
            
                return NotFound();

                var user = await _userManager.FindByIdAsync(id);
                if (user is null)
                    return NotFound();

              
            
            return View(viewName, user); 
        }

        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");


            //return View(viewName, user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id,  ApplicationUser applicationUsers)
        {
            if (id != applicationUsers.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync (id);

                    user.UserName = applicationUsers.UserName;
                    user.NormalizedUserName = applicationUsers.NormalizedUserName;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                        return RedirectToAction( nameof(Index));
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);    

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return View(applicationUsers);
            // return await Details(id, "Update");
        }







        public async Task<IActionResult> Delete(string id, ApplicationUser applicationUsers)
        {
            if (id != applicationUsers.Id)
                return NotFound();
            
            
                try
                {
                    var user = await _userManager.FindByIdAsync(id);

                   
                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                        return RedirectToAction(nameof(Index));
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                 //   ViewBag.Errors = result.Errors;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }


            return RedirectToAction(nameof(Index));
          
        }










    }
}
