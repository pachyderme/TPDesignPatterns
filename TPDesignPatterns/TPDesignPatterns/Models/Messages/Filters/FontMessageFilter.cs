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
        public override void Filter(Node n)
        {
            Regex myRegex = new Regex(@"(\[*i]).*?(\[/i])|(\[b])(.*?)(\[/b])|(\[u])(.*?)(\[/u])");
            foreach (Match m in myRegex.Matches(n.stringContent))
            {
                FontStyle fs = FontStyle.None;
                if (m.Value.Contains("[i]"))
                {
                    fs = FontStyle.Italic;
                }
                if (m.Value.Contains("[b]"))
                {
                    fs = FontStyle.Bold;
                }
                if (m.Value.Contains("[u]"))
                {
                    fs = FontStyle.Underline;
                }
                Regex myRegexTag = new Regex(@"\[.+?\]");
                string s = myRegexTag.Replace(m.Value, "");
                TextNode tn = new TextNode(s+"-"+fs.ToString(), fs);
                n.childrenNodes.Add(tn);
            }


        }
    }
}
