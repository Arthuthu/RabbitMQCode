using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };

using (var connection = factory.CreateConnection())

using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(
        queue: "saudacao_1",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);

    string message = "Bem vindo ao RabbitMQ (Mensagem teste)";

    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(
        exchange: "",
        routingKey: "saudacao_1",
        basicProperties: null,
        body: body);

    Console.WriteLine($" [x] Enviada : {message}");
}

Console.ReadLine();

//---------------------------------------------------------------//---------------------------------------//

////Define uma conexão com um nó RabbitMQ em localhost
//var factory = new ConnectionFactory() { HostName = "localhost" };

////Abre uma conexão com um nó RabbitMQ
//using (var connection = factory.CreateConnection())

////Cria um canal onde sera definido uma fila, mensagem e onde sera publicada a mensagem
//using (var channel = connection.CreateModel())
//{
//    //Criação da fila = queue
//    channel.QueueDeclare(
//        //Nome da fila
//        queue: "saudacao_1",
//        //Se true a fila permanece ativa apos o servidor ser reiniciado
//        durable: false,
//        //Se true ela só pode ser acessada via conexão atual e são excluidas ao fechar a conexão
//        exclusive: false,
//        //Se true sera deletada automaticamente após o consumidor usar a fila
//        autoDelete: false,
//        arguments: null);

//    //Cria uma mensagem que sera enviada para fila em formato string
//    string message = "Bem vindo ao RabbitMQ";

//    //Converte a mensagem de formato em string para formato bytes (RabbitMQ trabalha somente assim)
//    var body = Encoding.UTF8.GetBytes(message);

//    channel.BasicPublish(
//        exchange: "",
//        //O nome da fila que sera publicada
//        routingKey: "saudacao_1",
//        basicProperties: null,
//        //O corpo da mensagem que sera publicada
//        body: body);

//    Console.WriteLine($" [x] Enviada : {message}");
//}

//Console.ReadLine();
