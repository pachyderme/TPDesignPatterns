using TPDesignPatterns.Models.Clients.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Clients.States;
using TPDesignPatterns.Models.Historic.Memento;
using TPDesignPatterns.Models.Exports;

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

    }
}