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
                new Message("ITALIQUE + BOLD SIMPLE : Bo[i]nj[/i]our, [b]je[/b] [i]m'appelle[/i] Titome", null),
                new Message("ITALIQUE + BOLD COMPLEXE : Bo[i]nj[/i]our, [b]je[/b] [i]m'appelle [b]Titome[/b] et je suis imberbe[/i]", null),
                new Message("LINK : [l='http://coucou.fr']test[/l]", null),
                new Message("COLOR : [c='#333']test[/c]", null)
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
