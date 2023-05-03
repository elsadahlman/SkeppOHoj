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
    public class InsuranceTypesController : ControllerBase
    {
        private readonly SkeppOHojContext _context;

        public InsuranceTypesController(SkeppOHojContext context)
        {
            _context = context;
        }

        // GET: api/InsuranceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceType>>> GetInsuranceType()
        {
          if (_context.InsuranceType == null)
          {
              return NotFound();
          }
            return await _context.InsuranceType.ToListAsync();
        }

        // GET: api/InsuranceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceType>> GetInsuranceType(long id)
        {
          if (_context.InsuranceType == null)
          {
              return NotFound();
          }
            var insuranceType = await _context.InsuranceType.FindAsync(id);

            if (insuranceType == null)
            {
                return NotFound();
            }

            return insuranceType;
        }

        // PUT: api/InsuranceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceType(long id, InsuranceType insuranceType)
        {
            if (id != insuranceType.InsuranceTypeId)
            {
                return BadRequest();
            }

            _context.Entry(insuranceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceTypeExists(id))
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

        // POST: api/InsuranceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuranceType>> PostInsuranceType(InsuranceType insuranceType)
        {
          if (_context.InsuranceType == null)
          {
              return Problem("Entity set 'SkeppOHojContext.InsuranceType'  is null.");
          }
            _context.InsuranceType.Add(insuranceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceType", new { id = insuranceType.InsuranceTypeId }, insuranceType);
        }

        // DELETE: api/InsuranceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceType(long id)
        {
            if (_context.InsuranceType == null)
            {
                return NotFound();
            }
            var insuranceType = await _context.InsuranceType.FindAsync(id);
            if (insuranceType == null)
            {
                return NotFound();
            }

            _context.InsuranceType.Remove(insuranceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuranceTypeExists(long id)
        {
            return (_context.InsuranceType?.Any(e => e.InsuranceTypeId == id)).GetValueOrDefault();
        }
    }
}
