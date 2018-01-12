using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Messages.Nodes;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public class LinkMessageFilter : MessageFilter
    {
        protected override void FilterNode(Node n)
        {
            Regex baseRegex = new Regex(@"(\[*l='(.*)']).*?(\[\/l])");

            foreach (Match m in baseRegex.Matches(n.StringContent))
            {
                Regex linkRegex = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)");

                LinkNode ln = new LinkNode(string.Empty);

                foreach (Match mLink in linkRegex.Matches(m.Value))
                {
                    ln.Link = mLink.Value;
                }

                ln.StringContent = RemoveTags($"[l='{ln.Link}']", "[/l]", m);

                AddNode(m, ln, n);
            }
        }
    }
}
