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

        public DbSet<SkeppOHoj.Models.User> User { get; set; } = default!;
    }
}
