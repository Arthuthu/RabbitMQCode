using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };

using (var connection = factory.CreateConnection())

using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(
        queue: "saudacao_1",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);

    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" [x] Recebida: {message}");
    };

    channel.BasicConsume(
        queue: "saudacao_1",
        autoAck: true,
        consumer: consumer);

    Console.ReadLine();
}

//---------------------------------------------------------------//---------------------------------------//

//Código com comentários

//var factory = new ConnectionFactory { HostName = "localhost" };

//using (var connection = factory.CreateConnection())

////Cria o canal conexão para operar
//using (var channel = connection.CreateModel())
//{
//    //Declaramos a fila que vamos consumir a mensagem
//    channel.QueueDeclare(
//        queue: "saudacao_1",
//        durable: false,
//        exclusive: false,
//        autoDelete: false,
//        arguments: null);

//    //Solicita a entrega das mensagens de forma assíncrona e fornece o retorno da chamada
//    var consumer = new EventingBasicConsumer(channel);

//    consumer.Received += (model, ea) =>
//    {
//        //Recebe a mensagem em formato de bytes
//        var body = ea.Body.ToArray();
//        //Converte a mensagem para formato string
//        var message = Encoding.UTF8.GetString(body);
//        //Exibindo a mensagem que foi recebida
//        Console.WriteLine($" [x] Recebida: {message}");
//    };

//    //Indica que a mensagem foi consumida para o RabbitMQ
//    channel.BasicConsume(
//        queue: "saudacao_1",
//        autoAck: true,
//        consumer: consumer);

//    Console.ReadLine();
//}
