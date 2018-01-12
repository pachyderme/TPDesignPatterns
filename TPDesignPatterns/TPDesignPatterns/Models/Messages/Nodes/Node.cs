﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages.Nodes
{
    public abstract class Node
    {
        /// <summary>
        /// 
        /// </summary>
        public Node next { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Node> childrenNodes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string stringContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public Node(string content)
        {
            stringContent = content;
            childrenNodes = new List<Node>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public void SetNext(Node n)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Find(string s)
        {
            bool result = stringContent.ToLower().Contains(s.ToLower());

            if (!result)
            {
                foreach (Node n in childrenNodes)
                {
                    result = n.Find(s);

                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(stringContent);
            if (Program.displayCompleteMessage)
                childrenNodes.ForEach(c =>
                {
                    result.AppendLine(c.ToString());
                });

            return result.ToString();
        }
    }
}
