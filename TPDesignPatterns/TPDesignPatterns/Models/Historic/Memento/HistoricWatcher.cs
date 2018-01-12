using System;
using System.Collections.Generic;
using System.Text;
using TPDesignPatterns.Models.Clients;

namespace TPDesignPatterns.Models.Historic.Memento
{
    public class HistoricWatcher
    {
        public Client Client { get; set; }
        public List<HistoricMemento> HistoricMementos { get; set; }

        public HistoricWatcher()
        {
            HistoricMementos = new List<HistoricMemento>();
        }

        public void addHistoricMemento(HistoricMemento hm)
        {
            HistoricMementos.Add(hm);
        }
        public HistoricMemento getHistoricMemento()
        {
            HistoricMemento hmReturn = null;
            foreach (HistoricMemento hm in HistoricMementos)
            {
                if (hm.SavingDate == hm.Message.SendDate)
                {
                    hmReturn = hm;
                }
            }
            return hmReturn;
        }

    }
}
