using System;
using System.Collections.Generic;
using TPDesignPatterns.Models.Messages.Nodes;
using TPDesignPatterns.Models.Clients;
using TPDesignPatterns.Models.Database;

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
        public Client sender { get; set; }

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
        public Message(string content, Client sender)
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
        public static List<Message> GetMessages(int index, int page)
        {
            return Database.Database.GetInstance().GetMessages(index, page);
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
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Search(String s)
        {
            return nodeContent.Find(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return nodeContent.ToString();
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

        public List<Message> GetMessages()
        {
            throw new NotImplementedException();
        }
    }
}
