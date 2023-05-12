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
    public class InsuranceClaimCommentsController : ControllerBase
    {
        private readonly SkeppOHojContext _context;

        public InsuranceClaimCommentsController(SkeppOHojContext context)
        {
            _context = context;
        }

        // GET: api/InsuranceClaimComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceClaimComment>>> GetInsuranceClaimComment()
        {
          if (_context.InsuranceClaimComment == null)
          {
              return NotFound();
          }
            return await _context.InsuranceClaimComment.ToListAsync();
        }

        // GET: api/InsuranceClaimComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceClaimComment>> GetInsuranceClaimComment(int id)
        {
          if (_context.InsuranceClaimComment == null)
          {
              return NotFound();
          }
            var insuranceClaimComment = await _context.InsuranceClaimComment.FindAsync(id);

            if (insuranceClaimComment == null)
            {
                return NotFound();
            }

            return insuranceClaimComment;
        }

        // PUT: api/InsuranceClaimComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceClaimComment(int id, InsuranceClaimComment insuranceClaimComment)
        {
            if (id != insuranceClaimComment.InsuranceClaimCommentId)
            {
                return BadRequest();
            }

            _context.Entry(insuranceClaimComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceClaimCommentExists(id))
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

        // POST: api/InsuranceClaimComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuranceClaimComment>> PostInsuranceClaimComment(InsuranceClaimComment insuranceClaimComment)
        {
          if (_context.InsuranceClaimComment == null)
          {
              return Problem("Entity set 'SkeppOHojContext.InsuranceClaimComment'  is null.");
          }
            _context.InsuranceClaimComment.Add(insuranceClaimComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceClaimComment", new { id = insuranceClaimComment.InsuranceClaimCommentId }, insuranceClaimComment);
        }

        // DELETE: api/InsuranceClaimComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceClaimComment(int id)
        {
            if (_context.InsuranceClaimComment == null)
            {
                return NotFound();
            }
            var insuranceClaimComment = await _context.InsuranceClaimComment.FindAsync(id);
            if (insuranceClaimComment == null)
            {
                return NotFound();
            }

            _context.InsuranceClaimComment.Remove(insuranceClaimComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuranceClaimCommentExists(int id)
        {
            return (_context.InsuranceClaimComment?.Any(e => e.InsuranceClaimCommentId == id)).GetValueOrDefault();
        }
    }
}
