using Microsoft.AspNetCore.SignalR;

namespace shop_food_api.SignalR
{
    public class HubCommon : Hub
    {
        public async Task NewMessage(long username, string message)
        {
            await Clients.All.SendAsync("messageReceived tutv19", username, message);
        }
    }
}
