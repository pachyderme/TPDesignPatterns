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
        public List<ClientObserver> clientObservers { get; set; }
        public ClientState state { get; set; }


        public Client()
        {
            clientObservers = new List<ClientObserver>();
        }

        public void Connect()
        {
            if(state == null)
                state = new ConnectedState();
            
            state.Connected(this);
        }
        public void Disconnect()
        {
            if (state == null)
                state = new DisconnectedState();

            state.Disconnected(this);
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