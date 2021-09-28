using Eduhome.Data;
using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Contact contact = _context.Contacts.FirstOrDefault();
            return View(contact);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Review(ContactReview review)
        {
            Contact contact = await _context.Contacts.Include(x => x.ContactReviews).FirstOrDefaultAsync(x => x.Id == review.ContactId);

            if (contact == null)
                return NotFound();


            ContactReview contactReview = new ContactReview
            {
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                Email = review.Email,
                FullName = review.FullName,
                ContactId = review.ContactId,
                Subject = review.Subject,
                Message = review.Message
            };

            contact.ContactReviews.Add(contactReview);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Subscribe(Subscribe subscribe)
        {


            Subscribe subModel = new Subscribe
            {
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                Email = subscribe.Email

            };

            _context.Subscribes.Add(subModel);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
