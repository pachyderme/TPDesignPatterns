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
        /// <param name="content"></param>
        public Node(string content)
        {
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
        /// <param name="code"></param>
        /// <returns></returns>
        protected bool Find(int code)
        {
            return true;
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
