using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Clients.States
{
    public abstract class ClientState
    {
        protected void SetState(Client c, ClientState cs)
        {
            c.State = cs;
        }
        public abstract void Disconnected(Client c);
        public abstract void Connected(Client c);
    }
}
