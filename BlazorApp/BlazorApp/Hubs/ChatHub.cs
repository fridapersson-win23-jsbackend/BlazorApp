using Microsoft.AspNetCore.SignalR;

namespace BlazorApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            _logger.LogInformation("Client connected: {ConnectionId}", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogInformation("Client disconnected: {ConnectionId}", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task Typing(string userName)
        {
            _logger.LogInformation("{UserName} is typing", userName);
            await Clients.Others.SendAsync("UserTyping", userName);
        }

        public async Task SendMessageToAll(string userName, string message, DateTime dateTime)
        {
            _logger.LogInformation("{UserName} sent a message: {Message} at {DateTime}", userName, message, dateTime);
            await Clients.All.SendAsync("ReceiveMessage", userName, message, dateTime);
        }
    }
}
