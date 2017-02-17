using MediatR;
using System;
using System.Threading.Tasks;

namespace MediatRGettingStarted
{
    public class PingCommand
    {
        public class Ping : IRequest<Pong>
        {
            public string Message { get; set; }
        }

        public class Pong
        {
            public string Message { get; set; }
        }

        public class PingRequestHandler 
            :IAsyncRequestHandler<Ping,Pong>
        {
            public PingRequestHandler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<Pong> Handle(Ping message) {
                var response =  await _mediator.Send(new ChildPingCommand.ChildPingRequest());
                return new Pong();
            }

            private readonly IMediator _mediator;
        }
    }
}
