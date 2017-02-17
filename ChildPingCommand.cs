using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace MediatRGettingStarted
{
    public class ChildPingCommand
    {
        public class ChildPingRequest : IRequest<ChildPingResponse>
        {
            public ChildPingRequest()
            {

            }
        }

        public class ChildPingResponse
        {
            public ChildPingResponse()
            {

            }
        }

        public class ChildPingHandler : IAsyncRequestHandler<ChildPingRequest, ChildPingResponse>
        {
            public ChildPingHandler()
            {
            }

            public async Task<ChildPingResponse> Handle(ChildPingRequest request)
            {
                Console.WriteLine("Child Ping");
                return new ChildPingResponse();
            }
            
        }

    }

}
