using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Messages.Nodes;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public class ColorMessageFilter : MessageFilter
    {
        public override void Filter(Node n)
        {
            Regex myRegex = new Regex("#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})");
            foreach (Match m in myRegex.Matches(n.stringContent))
            {
                ColorNode cn = new ColorNode(m.Value);
                n.childrenNodes.Add(cn);
            }
        }


    }
}
