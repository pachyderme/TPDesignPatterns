using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Messages.Nodes;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public class ColorMessageFilter : MessageFilter
    {
        protected override void FilterNode(Node n)
        {
            Regex baseRegex = new Regex(@"(\[*c='(.*)']).*?(\[\/c])");

            int count = 0;
            foreach (Match m in baseRegex.Matches(n.StringContent))
            {
                Regex colorRegex = new Regex(@"#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})");

                ColorNode cn = new ColorNode(string.Empty);

                foreach (Match mColor in colorRegex.Matches(m.Value))
                {
                    cn.Color = mColor.Value;
                }

                cn.StringContent = RemoveTags($"[c='{cn.Color}']", "[/c]", m);

                AddNode(m, cn, count, n);
                count++;
            }
        }
    }
}
