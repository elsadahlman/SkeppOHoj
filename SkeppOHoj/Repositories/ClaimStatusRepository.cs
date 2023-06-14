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
    public interface IClaimStatusRepository
    {
        Task<ClaimStatus> GetClaimStatusAsync(int ClaimStatusId);
        Task<List<ClaimStatus>> GetClaimStatusAsync();
        Task<ClaimStatus> DeleteClaimStatusAsync(int ClaimStatusId);
        Task<ClaimStatus> AddClaimStatusAsync(ClaimStatusCreationDto dto);
    }

    public class ClaimStatusRepository : IClaimStatusRepository
    {

        private readonly SkeppOHojContext context;
        private readonly IMapper mapper;

        public ClaimStatusRepository(SkeppOHojContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ClaimStatus> GetClaimStatusAsync(int ClaimStatusId)
        {
            var status = await context.ClaimStatus.FirstOrDefaultAsync(x => x.ClaimStatusId == ClaimStatusId);
            return status;
        }

        public async Task<List<ClaimStatus>> GetClaimstatusAsync()
        {
            var status = await context.ClaimStatus.ToListAsync();
            return status;
        }

        public async Task<ClaimStatus> DeleteClaimStatusAsync(int ClaimStatusId)
        {
            var status = await context.ClaimStatus.FirstOrDefaultAsync(x => x.ClaimStatusId == ClaimStatusId);

            if (status == null)
            {
                return null;
            }

            context.ClaimStatus.Remove(status);
            context.SaveChanges();
            return status;
        }

        public async Task<ClaimStatus> AddClaimStatusAsync(ClaimStatusCreationDto dto)
        {
            var status = mapper.Map<ClaimStatus>(dto);
            var addedstatus = context.ClaimStatus.Add(status);
            context.SaveChanges();
            return addedstatus.Entity;
        }

        public Task<List<ClaimStatus>> GetClaimStatusAsync()
        {
            throw new NotImplementedException();
        }
    }
}
