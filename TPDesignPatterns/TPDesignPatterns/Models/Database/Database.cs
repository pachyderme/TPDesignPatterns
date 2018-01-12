using System;
using System.Collections.Generic;
using System.Text;
using TPDesignPatterns.Models.Messages;
using System.Linq;

namespace TPDesignPatterns.Models.Database
{
    public class Database
    {
        private static Database _instance;
        public List<Message> Messages { get; set; }

        public static Database GetInstance()
        {
            if (_instance == null)
                _instance = new Database();

            return _instance;
        }

        public Database()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Nombre de résultats retournés</param>
        /// <param name="page">Numéro de la page à récupérer</param>
        /// <returns></returns>
        public List<Message> GetMessages(int index, int page)
        {
            Messages = new List<Message>() {
                new Message("Hey ! coucou ! saaalluuuttt !! #545454 http://coucou.fr", null),
                new Message("Chouette ! Youyouuu!! #FFF https://coucou.fr/chouette", null),
                new Message("Bo[i]nj[/i]our, [b]je[/b] [i]m'appelle[/i] Titome", null),
                new Message("Bo[i]nj[/i]our, [b]je[/b] [i]m'appelle[/i] Titome", null)
            };
            return Messages.OrderByDescending(m => m.sendDate).Take(index).ToList();
        }
    }
}
