using OnixProject.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixProject.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        private List<Event> domainEvents;
        public IReadOnlyCollection<Event> DomainEvents => domainEvents?.AsReadOnly();

        public void AddDomainEvent(Event domainEvent)
        {
            domainEvents ??= new List<Event>();
            domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(Event domainEvent)
        {
            domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            domainEvents?.Clear();
        }
    }
}
