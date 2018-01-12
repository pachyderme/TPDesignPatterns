using TPDesignPatterns.Models.Clients.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Clients.States;
using TPDesignPatterns.Models.Historic.Memento;
using TPDesignPatterns.Models.Exports;
using TPDesignPatterns.Models.Messages;
using System.Threading;

namespace TPDesignPatterns.Models.Clients
{
    public class Client : IClientObservable
    {
        public List<ClientObserver> ClientObservers { get; set; }
        public ClientState State { get; set; }
        public HistoricWatcher HistoricWatcher { get; set; }
        public static IExportData ExportData { get; set; }
        public string Pseudo { get; set; }

        public Client(string pseudo)
        {
            ClientObservers = new List<ClientObserver>();
            Pseudo = pseudo;
        }

        public void Connect()
        {
            if (State == null)
                State = new ConnectedState();

            State.Connected(this);

            Historic.Historic.GetInstance().DisplayAllMessages();
        }

        public List<Message> GetMessages()
        {
            return Historic.Historic.GetInstance().GetMessages();
        }

        public void Disconnect()
        {
            if (State == null)
                State = new DisconnectedState();

            State.Disconnected(this);
        }

        public void OnStateChange()
        {
            throw new NotImplementedException();
        }

        public void Subscribe(IClientObserver co)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(IClientObserver co)
        {
            throw new NotImplementedException();
        }

        public void Sauvegarder() => HistoricWatcher.addHistoricMemento(new HistoricMemento(this));
        public void Restore() => HistoricWatcher.getHistoricMemento();

        public void Export(string exportDataType)
        {
            switch (exportDataType)
            {
                case ExportDataType.JSON:
                    ExportData = new ExportJSON();
                    break;
                case ExportDataType.XML:
                    ExportData = new ExportXML();
                    break;
                case ExportDataType.SQL:
                    ExportData = new ExportSQL();
                    break;
            }

            ExportData.Export();
        }

        /// <summary>
        /// Send the message
        /// </summary>
        /// <returns></returns>
        public void Send(string message)
        {
            Console.WriteLine("Sending message ...");

            Thread.Sleep(1000);

            Message m = new Message(message, this);
            Database.Database.GetInstance().SaveMessage(m);
            Console.Clear();

            Historic.Historic.GetInstance().DisplayAllMessages();
        }
    }
}