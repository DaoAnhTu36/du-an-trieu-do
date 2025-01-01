using Microsoft.AspNetCore.SignalR;

namespace shop_food_api.SignalR
{
    public class NotificationHub : Hub
    {
        public async Task SendMessageToClient(string message)
        {
            if (Clients != null)
            {
                await Clients.All.SendAsync("SendMessageFromServerToClient", message);
            }
            Task.CompletedTask.Wait();
        }
    }
}
