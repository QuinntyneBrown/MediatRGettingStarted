using MediatR;

namespace MediatRGettingStarted
{
    public class Ping : IAsyncRequest<Pong>
    {
        public string Message { get; set; }
    }
}
