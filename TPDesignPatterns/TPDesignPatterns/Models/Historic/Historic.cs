using System;
using System.Collections.Generic;
using System.Text;
using TPDesignPatterns.Models.Messages;

namespace TPDesignPatterns.Models.Historic
{
    public class Historic
    {
        /// <summary>
        /// 
        /// </summary>
        private static Historic _instance;

        public List<Message> messages;

        private Historic()
        {
            messages = new List<Message>();

            messages.Add(new Message("Hey ! coucou ! saaalluuuttt !! #545454 http://coucou.fr", null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Historic GetInstance()
        {
            if (_instance == null)
                _instance = new Historic();

            return _instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Message SearchAllMessages(string s)
        {
            Message result = null;

            foreach(Message m in messages)
            {
                if (m.Search(s))
                {
                    result = m;
                    break;
                }
            }

            return result;
        }
    }
}
