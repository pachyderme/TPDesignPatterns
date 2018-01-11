using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages.Nodes
{
    public class TextNode : Node
    {
        public TextNode(string content) : base(content)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return stringContent;
        }
    }
}
