using EasyNetQ.AutoSubscribe;
using Manulife.DNC.MSAD.Messages;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.NB.ZAPEngineService.Models
{
    public class ClientMessageConsumer : IConsumeAsync<ClientMessage>
    {
        [AutoSubscriberConsumer(SubscriptionId = "ClientMessageService.ZapQuestion")]
        public Task ConsumeAsync(ClientMessage message)
        {
            // Your business logic code here
            // eg.Generate one ZAP question records into database and send to client
            // Sample console code
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("Consume one message from RabbitMQ : {0}, I will generate one ZAP question list to client", message.ClientName);
            System.Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}
