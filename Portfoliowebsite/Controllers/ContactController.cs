using Microsoft.AspNetCore.Mvc;
using Portfoliowebsite.Models;
using Portfoliowebsite.Services;

namespace Portfoliowebsite.Controllers
{
    public class ContactController : Controller
    {

        private readonly IEmailSender _email;
        public ContactController(IEmailSender email) => _email = email;

        public IActionResult Index()
        {
            return View(new ContactModel()); 
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!string.IsNullOrEmpty(model.website))
            {
                return BadRequest("Ongeldige aanvraag");
            }
            await _email.SendAsync(
                model.Name!, 
                model.Email!, 
                model.Subject!, 
                model.Message!
            );

            TempData["ThanksName"] = model.Name;
            TempData["ThanksEmail"] = model.Email;
            TempData["ThanksMessage"] = model.Message;

            return RedirectToAction(nameof(Thanks));
        }

        public IActionResult Thanks()
        {
            return View();
        }

    }
}
