using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AsyncMessageBrokerRabbitMQ
{
    static class Program
    {
        static void Main(string[] args)
        {
          //first create a conncetion facotry
          var factory = new ConnectionFactory
          {
              HostName = "localhost",
              //uri rabbitmq client management
              Uri =  new Uri("amqp://guest:guest@localhost:5672")
          };

            //create the conncetion

            using var  connection = factory.CreateConnection();
            //createting chanel
            using var channel = connection.CreateModel();

            //creating queue
            channel.QueueDeclare("demo-queue",durable:true,exclusive:false,autoDelete:false,arguments:null);//durable mean we want message should be there until the message recvd by consumer

            var message =  new { name = "Himanshu Kumar Sharma",Message = "Hello From Prodcuer Side" };

            var body =  Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("","demo-queue",null,body);
            channel.BasicPublish("", "demo-queue", null, Encoding.UTF8.GetBytes("hi there "));

        }
    }
}
