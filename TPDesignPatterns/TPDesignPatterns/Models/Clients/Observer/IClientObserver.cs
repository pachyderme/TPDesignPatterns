using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Clients.Observer
{
    public interface IClientObserver
    {
        void Refresh(IClientObservable co);
    }
}
