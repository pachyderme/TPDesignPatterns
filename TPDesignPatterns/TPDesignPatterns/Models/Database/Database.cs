using System;
using System.Collections.Generic;
using System.Text;
using TPDesignPatterns.Models.Messages;
using System.Linq;
using TPDesignPatterns.Models.Clients;

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

        public Database() {
            Messages = new List<Message>() {
                new Message("Bo[i]nj[/i]our, [b]je[/b] [i]m'appelle[/i] Titome", new Client("Titome")),
                new Message("[i]Il fait trop chaud au brésil je trouve ça trop chouette !!! [b]vive le [l='https://bresil.com']brésil[/l][/b] !![/i]", new Client("Brésil")),
                new Message("Merci toto [i]tu sers vraiment à [b]rien[/b].[/i]", new Client("Michel")),
                new Message("[b]0[/b] + [c='#333']0[/c] = la tête à [l='http://toto.fr']toto[/l]", new Client("Toto"))
            };
        }

        /// <summary>
        /// Get all messages
        /// </summary>
        /// <param name="index">Nombre de résultats retournés</param>
        /// <param name="page">Numéro de la page à récupérer</param>
        /// <returns></returns>
        public List<Message> GetMessages(int index, int page)
        {
            return Messages.OrderBy(m => m.SendDate).Take(index).ToList();
        }

        public void SaveMessage(Message m)
        {
            Messages.Add(m);
            Console.WriteLine("Message Saved");
        }
    }
}
