using Microsoft.EntityFrameworkCore;
using OnixProject.Domain.Models;
using OnixProject.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixProject.Repository.Contexts
{
    public class OnixContext : DbContext
    {
        public OnixContext(DbContextOptions<OnixContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}
