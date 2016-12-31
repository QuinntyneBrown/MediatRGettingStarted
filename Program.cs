using MediatR;
using System;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;
using System.IO;

namespace MediatRGettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = UnityConfiguration.GetContainer().Resolve<IMediator>();

            Runner.Run(mediator, Console.Out).Wait();

            Console.ReadKey();
        }
    }

    public static class Runner
    {
        public static async Task Run(IMediator mediator, TextWriter writer)
        {
            await writer.WriteLineAsync("Sample mediator implementation");
            await writer.WriteLineAsync("---------------");

            await writer.WriteLineAsync("Sending Ping...");
            var pong = await mediator.SendAsync(new PingCommand.Ping { Message = "Ping" });

            mediator.Publish(new PingedNotification.PingedNotificationRequest());

            await writer.WriteLineAsync("Received: " + pong.Message);
        }
    }
}
