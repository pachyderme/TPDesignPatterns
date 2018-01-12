using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages.Nodes
{
    public class ColorNode : Node
    {
        public string Color { get; set; }

        public ColorNode(string content) : base(content)
        {
        }
    }
}
