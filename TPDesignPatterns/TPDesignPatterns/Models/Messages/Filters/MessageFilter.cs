using System;
using System.Collections.Generic;
using System.Text;
using TPDesignPatterns.Models.Messages.Nodes;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public abstract class MessageFilter : IMessageFilter
    {
        public abstract void Filter(Node n);
    }
}
