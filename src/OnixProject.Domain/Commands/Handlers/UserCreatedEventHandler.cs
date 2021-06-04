using MediatR;
using Microsoft.AspNetCore.SignalR;
using OnixProject.Domain.Events;
using OnixProject.Domain.Hubs;
using System.Threading;
using System.Threading.Tasks;

namespace OnixProject.Domain.Handlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly IHubContext<UserEventsClientHub> hubContext;

        public UserCreatedEventHandler(IHubContext<UserEventsClientHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        public Task Handle(UserCreatedEvent @event, CancellationToken cancellationToken)
        {
            return hubContext.Clients.All.SendAsync("userCreated", @event, cancellationToken);
        }
    }
}