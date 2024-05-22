using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; }
        Task SaveChangesAsync();
    }
}
