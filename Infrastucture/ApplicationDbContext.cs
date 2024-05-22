using Application.Interface;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();  
        }
    }
}
