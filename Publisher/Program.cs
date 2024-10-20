using RabbitMQ.Client;
using System.Text;
using System.Text.Json.Serialization;



ConnectionFactory con  = new ConnectionFactory
{
    HostName = "localhost",
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};

IConnection connection = con.CreateConnection();

IModel channel = connection.CreateModel();


while (true)
{
    string data = Console.ReadLine();
    SendMessage.SendMessageToConsumer(channel, data);

}







static  class SendMessage
{


    public static void SendMessageToConsumer(IModel channel,string body)
    {
        var Messagebody = Encoding.UTF8.GetBytes(body);
        channel.QueueDeclare("BasicDemoQueue", durable: false, exclusive: false, false, null);

        channel.BasicPublish("", "BasicDemoQueue", null, Messagebody);
    }
}


