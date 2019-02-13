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

            for (int i = 0; i < 100; i++)
            {
                var message = new MessageSample
                {
                    Id = i+1,
                    Category = "Producer1",
                    Content = $"Conteudo 1{i}"
                };

                bus.Publish(message, message.Category);
            }
        }
    }
}
