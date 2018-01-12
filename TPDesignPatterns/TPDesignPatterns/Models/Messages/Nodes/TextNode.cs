using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages.Nodes
{
    public enum FontStyle
    {
        Bold,
        Italic,
        Underline,
        None
    }

    public class TextNode : Node
    {
        public FontStyle Fs { get; set; }

        public TextNode(string content, FontStyle fs = FontStyle.None) : base(content)
        {
            this.Fs = fs;
        }
    }
}
