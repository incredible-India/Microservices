using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;




ConnectionFactory conn = new ConnectionFactory
{

    HostName = "localhost",
    Uri = new Uri("amqp://guest:guest@localhost:5672")

};


IConnection connection = conn.CreateConnection();

IModel model = connection.CreateModel();


model.QueueDeclare("BasicDemoQueue", false, false, false, null);

EventingBasicConsumer consumer = new EventingBasicConsumer(model);


consumer.Received += (sender, args) => {

    Console.WriteLine($"we received the information from the publisher");

    Console.WriteLine( Encoding.UTF8.GetString(args.Body.ToArray()));



};


model.BasicConsume("BasicDemoQueue",true,consumer);



Console.ReadLine();






