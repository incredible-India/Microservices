using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory con = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
   // HostName = "localhost",
};

using (var connection = con.CreateConnection())
{
    IModel model = connection.CreateModel();

    //Direct Exchange

    //model.ExchangeDeclare("DirectEXCH", ExchangeType.Direct, true, true,null);

    ////creating the Queues 
    //model.QueueDeclare("Queue-1", true, false, false, null);
    //model.QueueDeclare("Queue-2", true, false, false, null);


    ////Binding the Quues to Direct Exchnage

    //model.QueueBind("Queue-1", "DirectEXCH", "pqrs", null);
    //model.QueueBind( "Queue-2", "DirectEXCH", "Abcd", null);


    EventingBasicConsumer consumer = new EventingBasicConsumer(model);

    consumer.Received += (senders, args) =>
    {

        Console.WriteLine(Encoding.UTF8.GetString(args.Body.ToArray()));

     
    };


    model.BasicConsume("Queue-2", true, consumer);
    model.BasicConsume("Queue-1", true, consumer);


    model.Close();

    Console.ReadLine();

}