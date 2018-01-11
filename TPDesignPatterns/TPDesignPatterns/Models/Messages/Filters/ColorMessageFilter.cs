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
            CaptureCollection cc = myRegex.Match(n.stringContent).Captures;
            foreach (Capture c in cc)
            {
                ColorNode cn = new ColorNode(c.Value);
                n.childrenNodes.Add(cn);
                Historic.Historic.filters[1].Filter(cn);
                Historic.Historic.filters[2].Filter(cn);
            }
        }


    }
}
