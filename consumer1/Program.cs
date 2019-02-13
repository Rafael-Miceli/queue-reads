using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain;
using EasyNetQ;

namespace consumer1
{
    class Program
    {

        private static IBus _bus;
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Preparing to read queue Consumer 1!");

            _bus = RabbitHutch.CreateBus("host=localhost");

            var tasks = new List<Task>();

            for (int i = 0; i < 1000000; i++)
                tasks.Add(ConsumeClients(i));

            await Task.WhenAll(tasks);

            Console.ReadKey();
        }

        static async Task ConsumeClients(int topicIndex)
        {
            _bus.Subscribe<MessageSample>(
                    $"Client1.{topicIndex}", 
                    msg => Console.WriteLine("Producer 1 - " + msg.Content),
                    x => x.WithTopic($"Fulano-{topicIndex}")
                );
        }
    }
}
