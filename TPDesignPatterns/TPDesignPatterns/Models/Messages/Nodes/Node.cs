using System;
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
            EnrichChildrenNodes(content);
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
            bool result = stringContent.Contains(s);

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
        /// <param name="content"></param>
        protected void EnrichChildrenNodes(string content)
        {
            if (childrenNodes == null)
                childrenNodes = new List<Node>();

            // parse content
        }
    }
}
