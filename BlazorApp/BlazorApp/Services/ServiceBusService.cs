using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BlazorWebbApp.Services;

public class ServiceBusService
{
    private readonly IConfiguration _config;
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;

    public ServiceBusService(IConfiguration config)
    {

        _config = config;

        _client = new ServiceBusClient(_config.GetConnectionString("ServiceBusConnection"));

        _sender = _client.CreateSender(_config.GetValue<string>("ServiceBus:SenderQueueName"));
    }

    public async Task SendMessageAsync(string email)
    {
        try
        {
            var message = new { Email = email }; 
            var jsonString = JsonConvert.SerializeObject(message);
            var serviceBusMessage = new ServiceBusMessage(jsonString);

            await _sender.SendMessageAsync(serviceBusMessage);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR : ServiceBusService.SendMessageAsync() :: {ex.Message} ");
        }
    }


}
