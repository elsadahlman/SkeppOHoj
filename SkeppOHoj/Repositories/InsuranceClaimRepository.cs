using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Data;
using SkeppOHoj.Models;
using SkeppOHoj.Models.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.Design;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkeppOHoj.Repositories
{
    public interface IInsuranceClaimRepository
    {
        Task<InsuranceClaim> GetInsuranceClaimAsync(int insuranceClaimId);
        Task<List<InsuranceClaim>> GetInsuranceClaimsAsync();
        Task<InsuranceClaim> DeleteInsuranceClaimAsync(int insuranceClaimId);
        Task<InsuranceClaim> AddInsuranceClaimAsync(InsuranceClaimCreationDto dto);
    }

    public class InsuranceClaimRepository : IInsuranceClaimRepository
    {

        private readonly SkeppOHojContext context;
        private readonly IMapper mapper;

        public InsuranceClaimRepository(SkeppOHojContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<InsuranceClaim> GetInsuranceClaimAsync(int insuranceClaimId)
        {
            var comment = await context.InsuranceClaim.FirstOrDefaultAsync(x => x.InsuranceClaimId == insuranceClaimId);
            return comment;
        }

        public async Task<List<InsuranceClaim>> GetInsuranceClaimsAsync()
        {
            var comments = await context.InsuranceClaim.ToListAsync();
            return comments;
        }

        public async Task<InsuranceClaim> DeleteInsuranceClaimAsync(int insuranceClaimId)
        {
            var comment = await context.InsuranceClaim.FirstOrDefaultAsync(x => x.InsuranceClaimId == insuranceClaimId);

            if (comment == null)
            {
                return null;
            }

            context.InsuranceClaim.Remove(comment);
            context.SaveChanges();
            return comment;
        }

        public async Task<InsuranceClaim> AddInsuranceClaimAsync(InsuranceClaimCreationDto dto)
        {
            var comment = mapper.Map<InsuranceClaim>(dto);
            var addedComment = context.InsuranceClaim.Add(comment); 
            context.SaveChanges();
            return addedComment.Entity;
        }

    }
}
