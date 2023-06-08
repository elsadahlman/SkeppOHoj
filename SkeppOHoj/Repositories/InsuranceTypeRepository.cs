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
    public interface IInsuranceTypeRepository
    {
        Task<InsuranceType> GetInsuranceTypeAsync(int insuranceTypeId);
        Task<List<InsuranceType>> GetInsuranceTypesAsync();
        Task<InsuranceType> DeleteInsuranceTypeAsync(int insuranceTypeId);
        Task<InsuranceType> AddInsuranceTypeAsync(InsuranceTypeCreationDto dto);
    }

    public class InsuranceTypeRepository : IInsuranceTypeRepository
    {

        private readonly SkeppOHojContext context;
        private readonly IMapper mapper;

        public InsuranceTypeRepository(SkeppOHojContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<InsuranceType> GetInsuranceTypeAsync(int insuranceTypeId)
        {
            var insuranceType = await context.InsuranceType.FirstOrDefaultAsync(x => x.InsuranceTypeId == insuranceTypeId);
            return insuranceType;
        }

        public async Task<List<InsuranceType>> GetInsuranceTypesAsync()
        {
            var insuranceTypes = await context.InsuranceType.ToListAsync();
            return insuranceTypes;
        }

        public async Task<InsuranceType> DeleteInsuranceTypeAsync(int insuranceTypeId)
        {
            var insuranceType = await context.InsuranceType.FirstOrDefaultAsync(x => x.InsuranceTypeId == insuranceTypeId);

            if (insuranceType == null)
            {
                return null;
            }

            context.InsuranceType.Remove(insuranceType);
            context.SaveChanges();
            return insuranceType;
        }

        public async Task<InsuranceType> AddInsuranceTypeAsync(InsuranceTypeCreationDto dto)
        {
            var insuranceType = mapper.Map<InsuranceType>(dto);
            var addedType = context.InsuranceType.Add(insuranceType); 
            context.SaveChanges();
            return addedType.Entity;
        }

    }
}
