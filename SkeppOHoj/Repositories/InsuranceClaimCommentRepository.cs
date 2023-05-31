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
    public interface IInsuranceClaimCommentRepository
    {
        Task<InsuranceClaimComment> GetInsuranceClaimCommentAsync(int insuranceClaimCommentId);
        Task<List<InsuranceClaimComment>> GetInsuranceClaimCommentsAsync();
        Task<InsuranceClaimComment> DeleteInsuranceClaimCommentAsync(int insuranceClaimCommentId);
        Task<InsuranceClaimComment> AddInsuranceClaimCommentAsync(InsuranceClaimCommentCreationDto dto);
    }

    public class InsuranceClaimCommentRepository : IInsuranceClaimCommentRepository
    {

        private readonly SkeppOHojContext context;
        private readonly IMapper mapper;

        public InsuranceClaimCommentRepository(SkeppOHojContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<InsuranceClaimComment> GetInsuranceClaimCommentAsync(int insuranceClaimCommentId)
        {
            var comment = await context.InsuranceClaimComment.FirstOrDefaultAsync(x => x.InsuranceClaimCommentId == insuranceClaimCommentId);
            return comment;
        }

        public async Task<List<InsuranceClaimComment>> GetInsuranceClaimCommentsAsync()
        {
            var comments = await context.InsuranceClaimComment.ToListAsync();
            return comments;
        }

        public async Task<InsuranceClaimComment> DeleteInsuranceClaimCommentAsync(int insuranceClaimCommentId)
        {
            var comment = await context.InsuranceClaimComment.FirstOrDefaultAsync(x => x.InsuranceClaimCommentId == insuranceClaimCommentId);

            if (comment == null)
            {
                return null;
            }

            context.InsuranceClaimComment.Remove(comment);
            context.SaveChanges();
            return comment;
        }

        public async Task<InsuranceClaimComment> AddInsuranceClaimCommentAsync(InsuranceClaimCommentCreationDto dto)
        {
            var comment = mapper.Map<InsuranceClaimComment>(dto);
            var addedComment = context.InsuranceClaimComment.Add(comment); 
            context.SaveChanges();
            return addedComment.Entity;
        }

    }
}
