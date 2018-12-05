using System;
using System.Linq;
using Kafka.Studies.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Kafka.Studies.ConsoleProducer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var producer = new Producer("test_topic", "http://localhost:9092");

            do
            {
                Console.WriteLine("Digite uma mensagem");
                producer.SendMessage(Console.ReadLine()).Wait();
            }
            while (true);
        }
    }
}
