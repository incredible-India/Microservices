using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                //uri rabbitmq client management
                Uri = new Uri("ampq://guest:guest@localhost:5672")
            };

            //create the conncetion

            using var connection = factory.CreateConnection();
            //createting chanel
            using var channel = connection.CreateModel();

            //creating queue
            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);//durable mean we want message should be there until the message recvd by consumer


            var cosumer = new EventingBasicConsumer(channel);

            cosumer.Received += (sender, e) => { 
            
                var body = e.Body.ToArray();
                var message  =  Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("demo-queue", true, cosumer);
            Console.ReadLine();
        }
    }
}
