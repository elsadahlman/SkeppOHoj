using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SkeppOHoj.Data;
using SkeppOHoj.Models;
using SkeppOHoj.Models.DTOs;
using SkeppOHoj.Repositories;

namespace SkeppOHoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancesController : ControllerBase
    {
        private readonly SkeppOHojContext _context;
        private readonly IInsuranceRepository _insuranceRepository;

        public InsurancesController(SkeppOHojContext context, IInsuranceRepository insuranceRepository)
        {
            _context = context;
            _insuranceRepository = insuranceRepository;
        }

        // GET: api/Insurances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetInsurance()
        {
            var insurances = await _insuranceRepository.GetInsurancesAsync();
            return Ok(insurances);
        }

        // GET: api/Insurances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insurance>> GetInsurance(int id)
        {
            var insurance = await _insuranceRepository.GetInsuranceAsync(id);

            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }

        // PUT: api/Insurances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsurance(int id, InsuranceUpdateDto insuranceDto)
        {
            var insurance = await _insuranceRepository.PutInsuranceAsync(id, insuranceDto);
            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);

        }

        // POST: api/Insurances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insurance>> PostInsurance(InsuranceCreationDto insuranceDto)
        {

            var insurance = await _insuranceRepository.AddInsuranceAsync(insuranceDto);
            if (insurance == null)
            { return BadRequest(); }

            return Ok(insurance);
        }

        // DELETE: api/Insurances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {

            var insurance = await _insuranceRepository.DeleteInsuranceAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);

        }

        private async Task<bool> InsuranceExists(int id)
        {
            var insurance = await _insuranceRepository.GetInsuranceAsync(id);
            if (insurance != null)
            {
                return true;
            }

            return false;
        }
    }
}
