using Backend_EF6SQLite.Data;
using Backend_EF6SQLite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_EF6SQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
        {
            _context.contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Ok(await _context.contacts.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            return Ok(await _context.contacts.ToListAsync());   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _context.contacts.FindAsync(id);
            if(contact == null)
            {
                return BadRequest("Character not found.");  
            }

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactRequest updateContactRequest)
        {
            var contact = await _context.contacts.FindAsync(id);

            if (contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Address = updateContactRequest.Address;
                contact.Phone = updateContactRequest.Phone;
                contact.Email = updateContactRequest.Email;

                await _context.SaveChangesAsync();

                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            // talk with contact table to find the resource with the primary key of id
            var contact = await _context.contacts.FindAsync(id);

            if (contact != null)
            {
                _context.Remove(contact);
                await _context.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound();

        }

    }
}
