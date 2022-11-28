using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using GroceryApi.Models;
using System.Collections.Generic;

namespace GroceryApi.Models
{
    public class GroceryAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public GroceryAPIDBContext(DbContextOptions<GroceryAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("GroceryData");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Grocery> GroceryItems { get; set; } = null!;
        public DbSet<Info> ItemInfo { get; set; } = null!;
    }
}
