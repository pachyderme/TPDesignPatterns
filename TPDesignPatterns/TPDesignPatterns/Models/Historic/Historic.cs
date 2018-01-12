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

        public Memento.HistoricMemento hm;

        public static List<IMessageFilter> filters;

        public List<Message> messages;

        public MessageLoader ml;

        private Historic()
        {


            filters = new List<IMessageFilter>() {
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
