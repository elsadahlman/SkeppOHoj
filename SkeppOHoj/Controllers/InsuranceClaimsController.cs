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
    public class InsuranceClaimsController : ControllerBase
    {
        private readonly SkeppOHojContext _context;
        private readonly IInsuranceClaimRepository _insuranceClaimRepository;

        public InsuranceClaimsController(SkeppOHojContext context, IInsuranceClaimRepository insuranceClaimRepository)
        {
            _context = context;
            _insuranceClaimRepository = insuranceClaimRepository;
        }

        // GET: api/InsuranceClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceClaim>>> GetInsuranceClaim()
        {
            var claims = await _insuranceClaimRepository.GetInsuranceClaimsAsync();
            return Ok(claims);

        }

        // GET: api/InsuranceClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceClaim>> GetInsuranceClaim(int id)
        {
            var claim = await _insuranceClaimRepository.GetInsuranceClaimAsync(id);

            if (claim == null)
            {
                return NotFound();
            }

            return Ok(claim);
        }



        // POST: api/InsuranceClaims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuranceClaim>> PostInsuranceClaim(InsuranceClaimCreationDto dto)
        {
            var claim = await _insuranceClaimRepository.AddInsuranceClaimAsync(dto);
            if (claim == null)
            {
                return BadRequest();
            }

            return Ok(claim);
        }


    }
}
