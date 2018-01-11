using System;
using System.Collections.Generic;
using TPDesignPatterns.Models.Messages.Nodes;
using TPDesignPatterns.Models.Users;

namespace TPDesignPatterns.Models.Messages
{
    public class Message : IMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public String stringContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Node nodeContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime sendDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User sender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Message()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sender"></param>
        public Message(string content, User sender)
        {
            stringContent = content;
            this.sender = sender;
            sendDate = DateTime.Now;
            nodeContent = GetNodeContent(content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Message> GetMessages()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private Node GetNodeContent(string content)
        {
            return new TextNode(content);
        }
    }
}
