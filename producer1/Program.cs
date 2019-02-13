using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain;
using EasyNetQ;

namespace producer1
{
    class Program
    {
        private static IBus _bus;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Preparing to write to queue Producer 1!");

            _bus = RabbitHutch.CreateBus("host=localhost");

            var tasks = new List<Task>();
            
            for (int i = 0; i < 1000000; i++)
                tasks.Add(SendClientMessages(i));

            await Task.WhenAll(tasks);
        }

        static async Task SendClientMessages(int topicIndex)
        {
            for (int j = 0; j < 3; j++)
            {
                var message = new MessageSample
                {
                    ClientName = $"Fulano-{topicIndex}",
                    Content = $"Conteudo {topicIndex}{j}"
                };

                await _bus.PublishAsync(message, message.ClientName);
            }
        }
    }
}
