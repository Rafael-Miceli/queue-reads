using System;
using domain;
using EasyNetQ;

namespace producer1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Preparing to write to queue Producer 1!");

            var bus = RabbitHutch.CreateBus("host=localhost");

            bus.Subscribe<MessageSample>(
                "Client1", 
                msg => Console.WriteLine(msg.Content), 
                x => x.WithTopic("Producer1")
            );
        }
    }
}
