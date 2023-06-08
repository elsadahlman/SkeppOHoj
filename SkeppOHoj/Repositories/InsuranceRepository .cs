using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Data;
using SkeppOHoj.Models;
using SkeppOHoj.Models.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace SkeppOHoj.Repositories
{
    public interface IInsuranceRepository
    {
        Task<Insurance> GetInsuranceAsync(int insuranceId);
        Task<List<Insurance>> GetInsurancesAsync();
        Task<Insurance> DeleteInsuranceAsync(int insuranceId);
        Task<Insurance> AddInsuranceAsync(InsuranceCreationDto dto);
        Task<Insurance> PutInsuranceAsync(int id, InsuranceUpdateDto insuranceDto);
    }

    public class InsuranceRepository : IInsuranceRepository
    {

        private readonly SkeppOHojContext context;
        private readonly IMapper mapper;

        public InsuranceRepository(SkeppOHojContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Insurance> GetInsuranceAsync(int insuranceId)
        {
            var insurance = await 
                context.Insurance
                    .Where(x => x.InsuranceId == insuranceId)
                    .Include(x => x.User)
                    .Include(x => x.InsuranceType)
                    .FirstOrDefaultAsync();

            return insurance;
        }

        public async Task<List<Insurance>> GetInsurancesAsync()
        {
            var insurances = await context.Insurance.ToListAsync();
            return insurances;
        }

        public async Task<Insurance> DeleteInsuranceAsync(int insuranceId)
        {
            var insurance = await context.Insurance.FirstOrDefaultAsync(x => x.InsuranceId == insuranceId);

            if (insurance == null)
            {
                return null;
            }

            context.Insurance.Remove(insurance);
            context.SaveChanges();
            return insurance;
        }

        public async Task<Insurance> AddInsuranceAsync(InsuranceCreationDto dto)
        {
            Insurance insurance = mapper.Map<Insurance>(dto);
            var addedInsurance = context.Insurance.Add(insurance); 
            context.SaveChanges();
            return addedInsurance.Entity;
        }

        public async Task<Insurance> PutInsuranceAsync(int id, InsuranceUpdateDto insuranceDto)
        {
            var insurance = await context.Insurance.FirstOrDefaultAsync(x => x.InsuranceId == id);
            if (insurance == null)
            {
                return null;
            }

            insurance = mapper.Map<InsuranceUpdateDto, Insurance>(insuranceDto, insurance);
            context.SaveChanges();

            return insurance;
        }

    }
}
