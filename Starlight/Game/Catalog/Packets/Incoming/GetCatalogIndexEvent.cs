using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog.Packets.Incoming
{
    public class GetCatalogIndexEvent : AbstractAsyncMessage
    {
        public override short Header => Headers.GetCatalogIndexEvent;

        protected override ValueTask Execute(ISession session)
        {
            return default;
        }
    }
}
