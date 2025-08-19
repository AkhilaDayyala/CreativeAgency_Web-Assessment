using Microsoft.AspNetCore.Mvc;
using Web.CreativeAgency.Models;
using Web.CreativeAgency.Services;

namespace Web.CreativeAgency.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactService service, ILogger<ContactController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet, Route("contact")]
        public IActionResult Index() => View(new ContactFormModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactFormModel model)
        {
            await _service.SaveAsync(model);

            TempData["Success"] = "Your message has been submitted!";
            return RedirectToAction("Index");
        }
    }
}
