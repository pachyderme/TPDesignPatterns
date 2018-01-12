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

        public MessageLoader MessageLoader { get; set; }

        private Historic()
        {
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
            if (MessageLoader == null)
                MessageLoader = new MessageLoader();

            Messages = MessageLoader.GetMessages();
            FilterAllMessages();
            return Messages;
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
            return Messages[Messages.Count-1];
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

        /// <summary>
        /// 
        /// </summary>
        public void DisplayAllMessages()
        {
            Console.WriteLine("================ ALL MESSAGES ==================");

            GetMessages().ForEach(m => Console.WriteLine(m.ToString()));

            Console.WriteLine("================ ALL MESSAGES ==================");
        }
    }
}
