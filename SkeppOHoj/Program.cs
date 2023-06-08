using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkeppOHoj.Data;
using SkeppOHoj.Repositories;

namespace SkeppOHoj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SkeppOHojContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SkeppOHojContext") ?? throw new InvalidOperationException("Connection string 'SkeppOHojContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            builder.Services.AddScoped<IInsuranceClaimCommentRepository, InsuranceClaimCommentRepository>();
            builder.Services.AddScoped<IInsuranceClaimRepository, InsuranceClaimRepository>();
            builder.Services.AddScoped<IInsuranceTypeRepository, InsuranceTypeRepository>();
            builder.Services.AddScoped<IClaimStatusRepository, ClaimStatusRepository>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}