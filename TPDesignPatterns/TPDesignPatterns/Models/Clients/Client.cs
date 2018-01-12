using TPDesignPatterns.Models.Clients.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Clients.States;

namespace TPDesignPatterns.Models.Clients
{
    public class Client : IClientObservable
    {
        public List<ClientObserver> ClientObservers { get; set; }
        public ClientState State { get; set; }

        public Client()
        {
            ClientObservers = new List<ClientObserver>();
        }

        public void Connect()
        {
            if(State == null)
                State = new ConnectedState();
            
            State.Connected(this);
        }
        public void Disconnect()
        {
            if (State == null)
                State = new DisconnectedState();

            State.Disconnected(this);
        }

        public void OnStateChange()
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe(IClientObserver co)
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe(IClientObserver co)
        {
            throw new System.NotImplementedException();
        }


    }
}