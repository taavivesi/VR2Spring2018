using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using WebApp.Data;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/ContactTypes")]
    public class ContactTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactTypes
        [HttpGet]
        public IEnumerable<ContactType> GetContactTypes()
        {
            return _context.ContactTypes;
        }

        // GET: api/ContactTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactType = await _context.ContactTypes.SingleOrDefaultAsync(m => m.ContactTypeId == id);

            if (contactType == null)
            {
                return NotFound();
            }

            return Ok(contactType);
        }

        // PUT: api/ContactTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactType([FromRoute] int id, [FromBody] ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactType.ContactTypeId)
            {
                return BadRequest();
            }

            _context.Entry(contactType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactTypes
        [HttpPost]
        public async Task<IActionResult> PostContactType([FromBody] ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ContactTypes.Add(contactType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactType", new { id = contactType.ContactTypeId }, contactType);
        }

        // DELETE: api/ContactTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactType = await _context.ContactTypes.SingleOrDefaultAsync(m => m.ContactTypeId == id);
            if (contactType == null)
            {
                return NotFound();
            }

            _context.ContactTypes.Remove(contactType);
            await _context.SaveChangesAsync();

            return Ok(contactType);
        }

        private bool ContactTypeExists(int id)
        {
            return _context.ContactTypes.Any(e => e.ContactTypeId == id);
        }
    }
}