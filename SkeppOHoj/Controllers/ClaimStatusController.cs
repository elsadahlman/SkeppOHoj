using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Data;
using SkeppOHoj.Models;
using SkeppOHoj.Models.DTOs;
using SkeppOHoj.Repositories;

namespace SkeppOHoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimStatusController : ControllerBase
    {
        private readonly SkeppOHojContext _context;
        private readonly IClaimStatusRepository _claimStatusRepository;

        public ClaimStatusController(SkeppOHojContext context, IClaimStatusRepository claimStatusRepository)
        {
            _context = context;
            _claimStatusRepository = claimStatusRepository;
        }

        // GET: api/ClaimStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaimStatus>>> GetClaimStatus()
        {
            var status = await _claimStatusRepository.GetClaimStatusAsync();
            return Ok(status);

        }

        // GET: api/ClaimStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClaimStatus>> GetClaimStatus(int id)
        {
            var status = await _claimStatusRepository.GetClaimStatusAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }



        // POST: api/ClaimStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClaimStatus>> PostClaimStatus(ClaimStatusCreationDto dto)
        {
            var status = await _claimStatusRepository.AddClaimStatusAsync(dto);
            if (status == null)
            {
                return BadRequest();
            }

            return Ok(status);
        }


    }
}
