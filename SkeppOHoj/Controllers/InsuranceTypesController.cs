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
    public class InsuranceTypesController : ControllerBase
    {
        private readonly SkeppOHojContext _context;
        private readonly IInsuranceTypeRepository _insuranceTypeRepository;

        public InsuranceTypesController(SkeppOHojContext context, IInsuranceTypeRepository insuranceTypeRepository )
        {
            _context = context;
            _insuranceTypeRepository = insuranceTypeRepository;
        }

        // GET: api/InsuranceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceType>>> GetInsuranceType()
        {
            var insurancesTypes = await _insuranceTypeRepository.GetInsuranceTypesAsync();
            return Ok(insurancesTypes);

        }

        // GET: api/InsuranceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceType>> GetInsuranceType(int id)
        {
            var insuranceType = await _insuranceTypeRepository.GetInsuranceTypeAsync(id);

            if (insuranceType == null)
            {
                return NotFound();
            }

            return Ok(insuranceType);
        }


        // POST: api/InsuranceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuranceType>> PostInsuranceType(InsuranceTypeCreationDto insuranceTypeCreationDto)
        {
            var insuranceType = await _insuranceTypeRepository.AddInsuranceTypeAsync(insuranceTypeCreationDto);
            if (insuranceType == null)
            { return BadRequest(); }

            return Ok(insuranceType);
        }

        // DELETE: api/InsuranceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceType(int id)
        {

            var insuranceType = await _insuranceTypeRepository.DeleteInsuranceTypeAsync(id);
            if (insuranceType == null)
            {
                return NotFound();
            }

            return Ok(insuranceType);
        }

    }
}
