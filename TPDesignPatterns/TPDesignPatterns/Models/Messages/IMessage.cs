using System;
using System.Collections.Generic;
using System.Text;

namespace TPDesignPatterns.Models.Messages
{
    public interface IMessage
    {
        List<Message> GetMessages();
        bool Send();
    }
}
