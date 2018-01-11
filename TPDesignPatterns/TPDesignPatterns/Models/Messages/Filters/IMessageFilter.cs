using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public interface IMessageFilter
    {
        void Filter(Message m);
    }
}
