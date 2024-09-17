using Entities;
using BusinessLogic.core;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Presentation.web.Controllers
{
    public class RegisterController : Controller
    {
        #region Private Varieble

        private UserBusinessLogic _userBusinessLogic = new UserBusinessLogic();
        private BindingList<User> _users = new BindingList<User>();

        #endregion

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var beer = new Beer()
        //        {
        //            BeerName = model.Name,
        //            BrandId = model.BrandId,
        //        };
        //        _context.Beers.Add(beer);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "BrandName", model.BrandId);
        //    return View(model);
        //}

    }
}
