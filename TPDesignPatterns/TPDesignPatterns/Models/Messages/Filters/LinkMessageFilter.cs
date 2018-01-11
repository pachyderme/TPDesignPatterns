using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Messages.Nodes;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public class LinkMessageFilter : MessageFilter
    {
        public override void Filter(Node n)
        {
            Regex myRegex = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)");
            CaptureCollection cc = myRegex.Match(n.stringContent).Captures;
            foreach (Capture c in cc)
            {
                LinkNode ln = new LinkNode(c.Value);
                n.childrenNodes.Add(ln);
            }
        }
    }
}
