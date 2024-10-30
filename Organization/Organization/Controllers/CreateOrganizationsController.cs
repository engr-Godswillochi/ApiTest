using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Models;

namespace Organization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateOrganizationsController : ControllerBase
    {
        private readonly CreateOrganizationContext _context;

        public CreateOrganizationsController(CreateOrganizationContext context)
        {
            _context = context;
        }

        // GET: api/CreateOrganizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateOrganization>>> GetCreateOrganization()
        {
            return await _context.CreateOrganization.ToListAsync();
        }

        // GET: api/CreateOrganizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreateOrganization>> GetCreateOrganization(int id)
        {
            var createOrganization = await _context.CreateOrganization.FindAsync(id);

            if (createOrganization == null)
            {
                return NotFound();
            }

            return createOrganization;
        }

        // PUT: api/CreateOrganizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreateOrganization(int id, CreateOrganization createOrganization)
        {
            if (id != createOrganization.ID)
            {
                return BadRequest();
            }

            _context.Entry(createOrganization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreateOrganizationExists(id))
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

        // POST: api/CreateOrganizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateOrganization>> PostCreateOrganization(CreateOrganization createOrganization)
        {
            _context.CreateOrganization.Add(createOrganization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreateOrganization", new { id = createOrganization.ID }, createOrganization);
        }

        // DELETE: api/CreateOrganizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreateOrganization(int id)
        {
            var createOrganization = await _context.CreateOrganization.FindAsync(id);
            if (createOrganization == null)
            {
                return NotFound();
            }

            _context.CreateOrganization.Remove(createOrganization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreateOrganizationExists(int id)
        {
            return _context.CreateOrganization.Any(e => e.ID == id);
        }
    }
}
