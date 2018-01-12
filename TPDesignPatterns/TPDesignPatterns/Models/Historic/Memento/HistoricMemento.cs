using System;
using System.Collections.Generic;
using System.Text;
using TPDesignPatterns.Models.Clients;
using TPDesignPatterns.Models.Messages;

namespace TPDesignPatterns.Models.Historic.Memento
{
    public class HistoricMemento
    {
        public DateTime SavingDate { get; set; }
        public Message Message { get; set; }
        public Client Client { get; set; }

        public HistoricMemento(Client client)
        {
            Client = client;
            Message = Historic.GetInstance().GetLastMessage();
            SavingDate = DateTime.Now;
        }
    }
}
