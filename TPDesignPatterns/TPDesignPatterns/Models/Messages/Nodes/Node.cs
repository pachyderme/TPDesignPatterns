using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages.Nodes
{
    public abstract class Node
    {
        /// <summary>
        /// Get / Set next node
        /// </summary>
        public Node Next { get; set; }

        /// <summary>
        /// Get / Set children nodes
        /// </summary>
        public List<Node> ChildrenNodes { get; set; }

        /// <summary>
        /// Get / Set the node's content
        /// </summary>
        public string StringContent { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content"></param>
        public Node(string content)
        {
            StringContent = content;
            ChildrenNodes = new List<Node>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public void SetNext(Node n)
        {

        }

        /// <summary>
        /// Check if the string is in the current node or in his children
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Find(string s)
        {
            bool result = StringContent.ToLower().Contains(s.ToLower());

            if (!result)
            {
                foreach (Node n in ChildrenNodes)
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
        /// Stringify the node
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(StringContent);
            if (Program.displayCompleteMessage)
                ChildrenNodes.ForEach(c =>
                {
                    result.AppendLine(c.ToString());
                });

            return result.ToString();
        }
    }
}
