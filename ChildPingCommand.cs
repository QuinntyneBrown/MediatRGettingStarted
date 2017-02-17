using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace MediatRGettingStarted
{
    public class ChildPingCommand
    {
        public class ChildPingRequest : IRequest<ChildPingResponse> { }

        public class ChildPingResponse { }

        public class ChildPingHandler : IAsyncRequestHandler<ChildPingRequest, ChildPingResponse>
        {
            public async Task<ChildPingResponse> Handle(ChildPingRequest request)
            {
                Console.WriteLine("Child Ping");
                return await Task.FromResult(new ChildPingResponse());
            }            
        }
    }
}
