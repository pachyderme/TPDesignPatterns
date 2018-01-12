using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages.Nodes
{
    public class LinkNode : Node
    {
        public string Link { get; set; }

        public LinkNode(string content) : base(content)
        {
        }
    }
}
