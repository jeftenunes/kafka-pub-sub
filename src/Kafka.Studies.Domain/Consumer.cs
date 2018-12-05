using System;
using KafkaNet;
using System.Linq;
using System.Text;
using KafkaNet.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Kafka.Studies.Domain
{
    public class Consumer
    {
        private readonly string kafkaEndpoint;
        private readonly KafkaNet.Consumer consumer;
        private readonly string topic = "test_topic";

        public Consumer(string topic, string endpoint)
        {
            this.topic = !string.IsNullOrEmpty(topic) ? topic : "test_topic";
            this.kafkaEndpoint = !string.IsNullOrEmpty(endpoint) ? endpoint : "http://localhost:9092";

            Uri uri = new Uri(kafkaEndpoint);
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            consumer = new KafkaNet.Consumer(new ConsumerOptions(this.topic, router));
        }

        public void Consume()
        {
            foreach (var message in consumer.Consume())
            {
                Console.WriteLine(Encoding.UTF8.GetString(message.Value));
            }
        }
    }
}
