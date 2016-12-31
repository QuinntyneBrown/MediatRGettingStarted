using MediatR;
using System;

namespace MediatRGettingStarted
{    
    public class PingedNotification
    {

        public class PingedNotificationRequest : INotification
        {            
        }

        public class PingedNotificationHandler : INotificationHandler<PingedNotificationRequest>
        {
            public void Handle(PingedNotificationRequest notification)
            {
                Console.WriteLine("Notified");
            }
        }
    }
}
