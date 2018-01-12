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
            if (n.ChildrenNodes.Count != 0)
            {
                foreach (Node nChild in n.ChildrenNodes)
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
            parent.StringContent = parent.StringContent.Replace(m.Value, $"[{count}]");
            parent.ChildrenNodes.Add(n);
            Filter(n);
        }

        protected string RemoveTags(string startTag, string endTag, Match m)
        {
            //Remove the first tag
            Regex regex = new Regex(Regex.Escape(startTag));
            string result = regex?.Replace(m.Value, string.Empty, 1);

            //Remove the last tag
            int place = result.LastIndexOf(endTag);
            return result.Remove(place, endTag.Length).Insert(place, string.Empty);
        }
    }
}
