using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TPDesignPatterns.Models.Messages.Nodes;

namespace TPDesignPatterns.Models.Messages.Filters
{
    public class FontMessageFilter : MessageFilter
    {
        /// <summary>
        /// Recherche les balises [i][/i] ou [][/b] d'un texte
        /// </summary>
        /// <param name="n"></param>
        protected override void FilterNode(Node n)
        {
            Regex myRegex = new Regex(@"(\[*i]).*?(\[/i])|(\[b])(.*?)(\[/b])|(\[u])(.*?)(\[/u])");

            foreach (Match m in myRegex.Matches(n.StringContent))
            {
                string endTag = string.Empty;
                string startTag = string.Empty;

                FontStyle fs = FontStyle.None;
                if (m.Value.StartsWith("[i]"))
                {
                    fs = FontStyle.Italic;
                    startTag = "[i]";
                    endTag = "[/i]";
                }
                else if (m.Value.StartsWith("[b]"))
                {
                    fs = FontStyle.Bold;
                    startTag = "[b]";
                    endTag = "[/b]";
                }
                else if (m.Value.StartsWith("[u]"))
                {
                    fs = FontStyle.Underline;
                    startTag = "[u]";
                    endTag = "[/u]";
                }

                TextNode tn = new TextNode(RemoveTags(startTag, endTag, m), fs);

                AddNode(m, tn, n);
            }
        }
    }
}
