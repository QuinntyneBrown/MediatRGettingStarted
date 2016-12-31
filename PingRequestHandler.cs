using MediatR;
using System.Threading.Tasks;

namespace MediatRGettingStarted
{
    public class PingRequestHandler : IAsyncRequestHandler<Ping,Pong>
    {
        public async Task<Pong> Handle(Ping message) => await Task.FromResult(new Pong());       
    }
}
