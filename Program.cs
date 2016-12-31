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
            await writer.WriteLineAsync("Sample mediator implementation using send, publish and post-request handlers in sync and async version.");
            await writer.WriteLineAsync("---------------");

            await writer.WriteLineAsync("Sending Ping...");
            var pong = await mediator.SendAsync(new Ping { Message = "Ping" });
            await writer.WriteLineAsync("Received: " + pong.Message);

            //await writer.WriteLineAsync("Sending Ping async...");
            //var response = await mediator.Send(new PingAsync { Message = "Ping" });
            //await writer.WriteLineAsync("Received async: " + response.Message);

            //await writer.WriteLineAsync("Publishing Pinged...");
            //await mediator.Publish(new Pinged());

            //await writer.WriteLineAsync("Publishing Pinged async...");
            //await mediator.Publish(new PingedAsync());
        }
    }
}
