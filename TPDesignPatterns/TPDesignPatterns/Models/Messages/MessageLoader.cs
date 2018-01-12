using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages
{
    public class MessageLoader : IMessage
    {
        public int index { get; set; }
        public int page { get; set; } 

        public List<Message> GetMessages()
        {
            index = 2;
            page = 0;
            return Message.GetMessages(index, page);
        }

        public bool Send()
        {
            throw new NotImplementedException();
        }
    }
}
