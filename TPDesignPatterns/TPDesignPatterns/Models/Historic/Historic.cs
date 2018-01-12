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

        public static List<IMessageFilter> Filters { get; set; }

        public List<Message> Messages { get; set; }

        public MessageLoader ml;

        private Historic()
        {
            messages = new List<Message>() {
                new Message("ITALIQUE + BOLD SIMPLE : Bo[i]nj[/i]our, [b]je[/b] [i]m'appelle[/i] Titome", null),
                new Message("ITALIQUE + BOLD COMPLEXE : Bo[i]nj[/i]our, [b]je[/b] [i]m'appelle [b]Titome[/b] et je suis imberbe[/i]", null),
                new Message("LINK : [l='http://coucou.fr']test[/l]", null),
                new Message("COLOR : [c='#333']test[/c]", null)
            };

            Filters = new List<IMessageFilter>() {
                new ColorMessageFilter(),
                new FontMessageFilter(),
                new LinkMessageFilter()
            };

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Message> GetMessages()
        {
            if (ml == null)
                ml = new MessageLoader();
            
            messages = ml.GetMessages();
            FilterAllMessages();
            return messages;
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

            foreach(Message m in Messages)
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
            foreach(Message m in Messages)
            {
                foreach(IMessageFilter f in Filters)
                {
                    f.Filter(m.NodeContent);
                }
            }
        }

        public Message GetLastMessage()
        {
            return messages[messages.Count-1];
        }

        /// <summary>
        /// 
        /// </summary>
        public void Sauvegarder()
        {
            //hm.HistoricWatcher.addHistoricMemento();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Restaurer()
        {

        }
    }
}
