using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public abstract class MessageFilter : IMessageFilter
    {
        public abstract void Filter(Message m);
    }
}
