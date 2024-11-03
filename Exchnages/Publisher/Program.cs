using RabbitMQ.Client;
using System.Text;

ConnectionFactory con = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
    HostName = "localhost",
};

using (var connection = con.CreateConnection())
{
    IModel model = connection.CreateModel();

    //Direct Exchange

    model.ExchangeDeclare("DirectEXCH",ExchangeType.Headers, true,true);

    //creating the Queues 
    model.QueueDeclare("Queue-1",true,false,false,null);
    model.QueueDeclare("Queue-2", true, false, false, null);


    //Binding the Quues to Direct Exchnage

    model.QueueBind( "Queue-1", "DirectEXCH", "pqrs",new Dictionary<string, object>()
    {
        {"id",1 }
    });
    model.QueueBind("Queue-2", "DirectEXCH", "Abcd", new Dictionary<string, object>()
    {
        {"id",2 }
    });
    
    string Messages = "hi Frm Publishers";

    byte[] MessageByte = Encoding.UTF8.GetBytes(Messages);
    string Messages2 = "hi Frm Publishers for Queue2";

    byte[] MessageByte2 = Encoding.UTF8.GetBytes(Messages2);


    var prop  =  model.CreateBasicProperties();
    prop.Headers = new Dictionary<string, object>()
    {
        {"id",2 }
    };

    var prop2 = model.CreateBasicProperties();
    prop2.Headers = new Dictionary<string, object>()
    {
        {"id",1 }
    };

    model.BasicPublish("DirectEXCH","pqxrs",false,prop,MessageByte);
    model.BasicPublish("DirectEXCH", "Axbcd", false, prop2, MessageByte2);


    model.Close();
    Console.ReadLine();
}