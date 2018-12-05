using System;
using KafkaNet;
using System.Linq;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Kafka.Studies.Domain
{
    public class Producer
    {
        private readonly string kafkaEndpoint;
        private readonly KafkaNet.Producer producer;
        private readonly string topic = "test_topic";

        public Producer(string topic, string endpoint)
        {
            this.topic = !string.IsNullOrEmpty(topic) ? topic : "test_topic";
            this.kafkaEndpoint = !string.IsNullOrEmpty(endpoint) ? endpoint : "http://localhost:9092";

            Uri uri = new Uri(kafkaEndpoint);
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            producer = new KafkaNet.Producer(router);
        }

        public async Task<IEnumerable<ProduceResponse>> SendMessage(string payload)
        {
            return await producer.SendMessageAsync(topic, new List<Message> { new Message(payload) });
        }
    }
}
