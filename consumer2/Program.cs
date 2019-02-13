using System;
using domain;
using EasyNetQ;

namespace consumer2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Preparing to read queue Consumer 2!");

            var bus = RabbitHutch.CreateBus("host=localhost");

            bus.Subscribe<MessageSample>(
                "Client2.1", 
                msg => Console.WriteLine("Producer 1 - " + msg.Content), 
                x => x.WithTopic("Producer1")
            );

            bus.Subscribe<MessageSample>(
                "Client2.2", 
                msg => Console.WriteLine("Producer 2 - " + msg.Content), 
                x => x.WithTopic("Producer2")
            );

            bus.Subscribe<MessageSample>(
                "Client2.3", 
                msg => Console.WriteLine("Producer 3 - " + msg.Content), 
                x => x.WithTopic("Producer3")
            );

            Console.ReadKey();
        }
    }
}
