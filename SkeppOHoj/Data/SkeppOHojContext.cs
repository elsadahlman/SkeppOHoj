using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Models;

namespace SkeppOHoj.Data
{
    public class SkeppOHojContext : DbContext
    {
        public SkeppOHojContext (DbContextOptions<SkeppOHojContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace the Initial Catalog=<Value> with your intended DB Name (Intial Catalog=MyDatabaseName)
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SkeppOHoj;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // to enable logging (see EF Core generated SQL queries), uncomment the following line:
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        public DbSet<SkeppOHoj.Models.User> User { get; set; } = default!;

        public DbSet<SkeppOHoj.Models.Insurance> Insurance { get; set; } = default!;

        public DbSet<SkeppOHoj.Models.InsuranceClaim> InsuranceClaim { get; set; } = default!;

        public DbSet<SkeppOHoj.Models.InsuranceClaimComment> InsuranceClaimComment { get; set; } = default!;

        public DbSet<SkeppOHoj.Models.InsuranceType> InsuranceType { get; set; } = default!;

        public DbSet<SkeppOHoj.Models.Status> Status { get; set; } = default!;
    }
}
