using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TPDesignPatterns.Models.Messages;
using TPDesignPatterns.Models.Messages.Filters;

namespace TPDesignPatterns.Models.Historic
{
    public class Historic
    {
        /// <summary>
        /// 
        /// </summary>
        private static Historic _instance;

        public static List<IMessageFilter> filters;

        public List<Message> messages;

        private Historic()
        {
            messages = new List<Message>() {
                new Message("Hey ! coucou ! saaalluuuttt !! #545454 http://coucou.fr", null),
                new Message("Chouette ! Youyouuu!! #FFF https://coucou.fr/chouette", null),
                new Message("Bo[i]nj[/i]our, [b]je[/b] [i]m'appelle[/i] Titome", null)
            };

            filters = new List<IMessageFilter>() {
                new ColorMessageFilter(),
                new FontMessageFilter(),
                new LinkMessageFilter()
            };

            FilterAllMessages();
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

        /// <summary>
        /// 
        /// </summary>
        private void FilterAllMessages()
        {
            foreach(Message m in messages)
            {
                foreach(IMessageFilter f in filters)
                {
                    f.Filter(m.nodeContent);
                }
            }
        }
    }
}
