using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Clients.States
{
    public class DisconnectedState : ClientState
    {
        public override void Connected(Client c)
        {
            c.Restore();
            SetState(c, new ConnectedState());
        }

        public override void Disconnected(Client c)
        {
            SetState(c, this);
        }
    }
}
