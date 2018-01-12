using System;
using System.Collections.Generic;
using System.Text;
using TPDesignPatterns.Models.Clients.Observer;

namespace TPDesignPatterns.Models.Clients
{
    public interface IClientObservable
    {
        void Unsubscribe(IClientObserver co);
        void Subscribe(IClientObserver co);
        void OnStateChange();
    }
}
