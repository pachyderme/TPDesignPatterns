using System;
using System.Collections.Generic;
using TPDesignPatterns.Models.Messages.Nodes;
using TPDesignPatterns.Models.Clients;

namespace TPDesignPatterns.Models.Messages
{
    public class Message : IMessage
    {
        /// <summary>
        /// Get / Set the message's content
        /// </summary>
        public String StringContent { get; set; }

        /// <summary>
        /// Get / Set the message's node
        /// </summary>
        public Node NodeContent { get; set; }

        /// <summary>
        /// Get / Set the message's sendDate
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// Get / Set the message's sender
        /// </summary>
        public Client Sender { get; set; }

        /// <summary>
        /// Contrustor
        /// </summary>
        public Message() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content">message's content</param>
        /// <param name="sender">message's sender</param>
        public Message(string content, Client sender)
        {
            StringContent = content;
            this.Sender = sender;
            SendDate = DateTime.Now;
            NodeContent = GetNodeContent(content);
        }

        /// <summary>
        /// Get messages from database
        /// </summary>
        /// <returns></returns>
        public List<Message> GetMessages()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send the message
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search the element on the message's node
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Search(String s)
        {
            return NodeContent.Find(s);
        }

        /// <summary>
        /// Stringify the message
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return NodeContent.ToString();
        }

        /// <summary>
        /// Get the message node (Constructor)
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private Node GetNodeContent(string content)
        {
            return new TextNode(content);
        }
    }
}
