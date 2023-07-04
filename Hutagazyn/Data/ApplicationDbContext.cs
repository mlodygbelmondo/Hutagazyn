using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hutagazyn.Models;

namespace Hutagazyn.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hutagazyn.Models.Product>? Product { get; set; }
        public DbSet<Hutagazyn.Models.AdditionalOrderInfo>? AdditionalOrderInfo { get; set; }
        public DbSet<Hutagazyn.Models.Delivery>? Delivery { get; set; }
        public DbSet<Hutagazyn.Models.Group>? Group { get; set; }
        public DbSet<Hutagazyn.Models.Order>? Order { get; set; }
    }
}