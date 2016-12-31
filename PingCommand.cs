using MediatR;
using System;
using System.Threading.Tasks;

namespace MediatRGettingStarted
{
    public class PingCommand
    {
        public class Ping : IAsyncRequest<Pong>
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
            public async Task<Pong> Handle(Ping message) => await Task.FromResult(new Pong());
        }
    }
}
