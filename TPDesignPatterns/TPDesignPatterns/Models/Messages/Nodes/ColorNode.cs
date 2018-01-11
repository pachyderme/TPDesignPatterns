﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages.Nodes
{
    public class ColorNode : Node
    {
        public ColorNode(string content) : base(content)
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
