using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Data;
using SkeppOHoj.Models;
using SkeppOHoj.Repositories;

namespace SkeppOHoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceClaimCommentsController : ControllerBase
    {
        private readonly SkeppOHojContext _context;
        private readonly IInsuranceClaimCommentRepository _insuranceClaimCommentRepository;

        public InsuranceClaimCommentsController(SkeppOHojContext context, IInsuranceClaimCommentRepository insuranceClaimCommentRepository)
        {
            _context = context;
            _insuranceClaimCommentRepository = insuranceClaimCommentRepository;
        }

        // GET: api/InsuranceClaimComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceClaimComment>>> GetInsuranceClaimComment()
        {
            var comments = await _insuranceClaimCommentRepository.GetInsuranceClaimCommentsAsync();
            return Ok(comments);

        }

        // GET: api/InsuranceClaimComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceClaimComment>> GetInsuranceClaimComment(int id)
        {
            var comment = await _insuranceClaimCommentRepository.GetInsuranceClaimCommentAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        

        // POST: api/InsuranceClaimComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuranceClaimComment>> PostInsuranceClaimComment(InsuranceClaimCommentCreationDto dto)
        {
            var comment = await _insuranceClaimCommentRepository.AddInsuranceClaimCommentAsync(dto);
            if (comment == null)
            {
                return BadRequest();
            }

            return Ok(comment);
        }

     
    }
}
