using System;
using System.Linq;
using Kafka.Studies.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var consumer = new Consumer("test_topic", "http://localhost:9092");
            consumer.Consume();
        }
    }
}
