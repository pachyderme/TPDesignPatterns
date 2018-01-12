using TPDesignPatterns.Models.Clients.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Clients.States;
using TPDesignPatterns.Models.Historic.Memento;

namespace TPDesignPatterns.Models.Clients
{
    public class Client : IClientObservable
    {
        public List<ClientObserver> ClientObservers { get; set; }
        public ClientState State { get; set; }
        public HistoricWatcher HistoricWatcher { get; set; }



        public Client()
        {
            ClientObservers = new List<ClientObserver>();
        }

        public void Connect()
        {
            if (state == null)
                state = new ConnectedState();

            state.Connected(this);

            Console.WriteLine("================ ALL MESSAGES =================="); 

            GetMessage().ForEach(m => Console.WriteLine(m.ToString())); 
            Program.displayCompleteMessage = false; 

            Console.WriteLine("================ ALL MESSAGES =================="); 
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

        public List<Messages.Message> GetMessage()
        {
            return Historic.Historic.GetInstance().GetMessages();
        }

        public void Sauvegarder() => HistoricWatcher.addHistoricMemento(new HistoricMemento(this));

    }
}