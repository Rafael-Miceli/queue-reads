using System;
using domain;
using EasyNetQ;

namespace consumer1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Preparing to read queue Consumer 1!");

            var bus = RabbitHutch.CreateBus("host=localhost");

            var con1 = bus.Subscribe<MessageSample>(
                "Client1.1", 
                msg => Console.WriteLine("Producer 1 - " + msg.Content), 
                x => x.WithTopic("Producer1")
            );

            con1.Dispose();

            var con2 = bus.Subscribe<MessageSample>(
                "Client1.2", 
                msg => Console.WriteLine("Producer 2 - " + msg.Content), 
                x => x.WithTopic("Producer2")
            );

            con1.Dispose();

            var con3 = bus.Subscribe<MessageSample>(
                "Client1.3", 
                msg => Console.WriteLine("Producer 3 - " + msg.Content), 
                x => x.WithTopic("Producer3")
            );

            con1.Dispose();

            Console.ReadKey();
        }
    }
}
