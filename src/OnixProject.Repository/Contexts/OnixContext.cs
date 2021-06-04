using MediatR;
using Microsoft.EntityFrameworkCore;
using OnixProject.Domain.Events;
using OnixProject.Domain.Models;
using OnixProject.Domain.Repositories;
using OnixProject.Repository.Mappings;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnixProject.Repository.Contexts
{
    public class OnixContext : DbContext
    {
        private readonly IMediator mediatorHandler;

        public OnixContext(DbContextOptions<OnixContext> options, IMediator mediatorHandler) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            this.mediatorHandler = mediatorHandler;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            var success = result > 0;
            if (success) await mediatorHandler.PublishDomainEvents(this);
            return result;
        }

        public async Task<bool> CommitAsync()
        {
            // After executing this line all the changes (from the Command Handler and Domain Event Handlers)
            // performed through the DbContext will be committed
            var success = await SaveChangesAsync() > 0;

            

            return success;
        }
    }
    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents<T>(this IMediator mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}