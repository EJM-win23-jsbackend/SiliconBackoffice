using Azure.Messaging.ServiceBus;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace EJMSiliconBackoffice.Services
{
    public class ServiceBusHandler
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;
        private readonly ServiceBusProcessor _processor;

        //Denna del är den som ligger och lyssnar, som är en "Subscriber" 
        //Kö-del...
        public ServiceBusHandler(string connectionString, string unsubscribeQueueName, string subscribeQueueName)
        {
            _client = new ServiceBusClient(connectionString);
            _sender = _client.CreateSender(unsubscribeQueueName);
            _processor = _client.CreateProcessor(subscribeQueueName);

            _processor.ProcessMessageAsync += MessageHandler;
            _processor.ProcessErrorAsync += ErrorHandler;

        }

        public async Task NotifyUserDeletionAsync(string userEmail)
        {
            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(userEmail));
            await _sender.SendMessageAsync(message);
            Console.WriteLine($"Sent message: {userEmail}");
        }

        private async Task ErrorHandler(ProcessErrorEventArgs args)
        {
            string message = args.Exception.ToString();
            Console.WriteLine($"Exception: {message}");
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            try
            {
                string message = args.Message.Body.ToString();
                Console.WriteLine($"Message received: {message}");

                await PublishAsync(message);

                //Detta gör så att meddelandet kan tas bort från kön
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception ex)
            { Debug.WriteLine(ex.Message); }
        }

        //Denna del är det som skickar tillbaka ett meddelande...
        public async Task PublishAsync(string message, string messageType = null!)
        {
            try
            {
                //Detta blir ett serviceBusMessage
                var payload = new ServiceBusMessage(message);

                if (messageType != null)
                {
                    payload.ApplicationProperties.Add("messageType", messageType);

                    await _sender.SendMessageAsync(payload);
                    Console.WriteLine("Message published");
                }
            }
            catch (Exception ex)
            { Debug.WriteLine("Publish" + ex.Message); }
        }

        public async Task StartSubscribingAsync() => await _processor.StartProcessingAsync();

        public async Task StopSubscribingAsync() => await _processor.StopProcessingAsync();
    }
}