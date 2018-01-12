using System;
using System.Collections.Generic;
using System.Text;
using TPDesignPatterns.Models.Messages.Nodes;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public interface IMessageFilter
    {
        void Filter(Node n);
    }
}
