using Eduhome.Areas.Manage.ViewModels;
using Eduhome.Data;
using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]

    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ContactViewModel contactVM = new ContactViewModel
            {
                Contact = _context.Contacts.FirstOrDefault()
            };
            return View(contactVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            Contact existContact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id);

            if (existContact == null)
                return NotFound();

            existContact.Email = contact.Email;
            existContact.Phone = contact.Phone;
            existContact.WebSiteUrl = contact.WebSiteUrl;
            existContact.ModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Review(int contactId)
        {
            List<ContactReview> contactReviews = await _context.ContactReviews.Where(x => x.ContactId == contactId).ToListAsync();

            return View(contactReviews);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteReview(int id)
        {
            ContactReview review = await _context.ContactReviews.FirstOrDefaultAsync(x => x.Id == id);
            Contact contact = await _context.Contacts.Include(x => x.ContactReviews).FirstOrDefaultAsync(x => x.Id == review.ContactId);


            if (review == null)
                return NotFound();

            _context.ContactReviews.Remove(review);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }



    }
}
