namespace Poller.Presentation.Hub
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;

    public class ChatHub : Hub
    {
        public override Task OnConnected()
        {
            var identity = Context.User.Identity.Name;
            Groups.Add(Context.ConnectionId, identity);
            return base.OnConnected();
        }
    }
}