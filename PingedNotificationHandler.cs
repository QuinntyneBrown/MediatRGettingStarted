using MediatR;
using System;

namespace MediatRGettingStarted
{
    public class PingedNotificationHandler : INotificationHandler<Pinged>
    {
        public void Handle(Pinged notification)
        {
            Console.WriteLine("Notified");
        }
    }
}
