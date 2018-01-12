using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Clients.States
{
    public class ConnectedState : ClientState
    {
        public override void Connected(Client c)
        {
            SetState(c, this);
        }

        public override void Disconnected(Client c)
        {
            c.Sauvegarder();
            SetState(c, new DisconnectedState());
        }
    }
}
