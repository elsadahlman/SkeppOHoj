using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Data;
using SkeppOHoj.Models;

namespace SkeppOHoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceClaimsController : ControllerBase
    {
        private readonly SkeppOHojContext _context;

        public InsuranceClaimsController(SkeppOHojContext context)
        {
            _context = context;
        }

        // GET: api/InsuranceClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceClaim>>> GetInsuranceClaim()
        {
          if (_context.InsuranceClaim == null)
          {
              return NotFound();
          }
            return await _context.InsuranceClaim.ToListAsync();
        }

        // GET: api/InsuranceClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceClaim>> GetInsuranceClaim(long id)
        {
          if (_context.InsuranceClaim == null)
          {
              return NotFound();
          }
            var insuranceClaim = await _context.InsuranceClaim.FindAsync(id);

            if (insuranceClaim == null)
            {
                return NotFound();
            }

            return insuranceClaim;
        }

        // PUT: api/InsuranceClaims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceClaim(long id, InsuranceClaim insuranceClaim)
        {
            if (id != insuranceClaim.InsuranceClaimId)
            {
                return BadRequest();
            }

            _context.Entry(insuranceClaim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceClaimExists(id))
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

        // POST: api/InsuranceClaims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuranceClaim>> PostInsuranceClaim(InsuranceClaim insuranceClaim)
        {
          if (_context.InsuranceClaim == null)
          {
              return Problem("Entity set 'SkeppOHojContext.InsuranceClaim'  is null.");
          }
            _context.InsuranceClaim.Add(insuranceClaim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceClaim", new { id = insuranceClaim.InsuranceClaimId }, insuranceClaim);
        }

        // DELETE: api/InsuranceClaims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceClaim(long id)
        {
            if (_context.InsuranceClaim == null)
            {
                return NotFound();
            }
            var insuranceClaim = await _context.InsuranceClaim.FindAsync(id);
            if (insuranceClaim == null)
            {
                return NotFound();
            }

            _context.InsuranceClaim.Remove(insuranceClaim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuranceClaimExists(long id)
        {
            return (_context.InsuranceClaim?.Any(e => e.InsuranceClaimId == id)).GetValueOrDefault();
        }
    }
}
