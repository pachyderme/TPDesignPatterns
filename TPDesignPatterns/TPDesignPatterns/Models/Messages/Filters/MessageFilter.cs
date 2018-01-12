using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Messages.Nodes;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public abstract class MessageFilter : IMessageFilter
    {
        protected abstract void FilterNode(Node n);

        public void Filter(Node n)
        {
            if (n.childrenNodes.Count != 0)
            {
                foreach (Node nChild in n.childrenNodes)
                {
                    Filter(nChild);
                }
            }
            else
            {
                FilterNode(n);
            }
        }

        protected void AddNode(Match m, Node n, int count, Node parent)
        {
            parent.stringContent = parent.stringContent.Replace(m.Value, $"[{count}]");
            parent.childrenNodes.Add(n);
            Filter(n);
        }

        protected string RemoveTags(string startTag, string endTag, Match m)
        {
            //[i]
            Regex regex = new Regex(Regex.Escape(startTag));
            string result = regex?.Replace(m.Value, string.Empty, 1);

            //[/i]
            int place = result.LastIndexOf(endTag);
            return result.Remove(place, endTag.Length).Insert(place, string.Empty);
        }
    }
}
