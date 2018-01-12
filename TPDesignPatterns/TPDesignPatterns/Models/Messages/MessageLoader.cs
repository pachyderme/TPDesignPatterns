using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages
{
    public class MessageLoader : IMessage
    {
        public int Index { get; set; }
        public int Page { get; set; } 

        public List<Message> GetMessages()
        {
            Index = 10;
            Page = 0;
            return Message.GetMessages(Index, Page);
        }
    }
}
