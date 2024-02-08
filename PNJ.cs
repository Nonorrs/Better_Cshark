using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark.Statistiques
{
    public class Quest
    {
        public string name;
        public string description;
        public string itemName;
        public string recompense;
        public int quantite;

        public bool questDone = false;
        public bool questAccepted = false;

        public Quest(string _name, string _description, string _itemName, string _recompense, int _quantite)
        {
            name = _name;
            description = _description;
            itemName = _itemName;
            recompense = _recompense;
            quantite = _quantite;
        }
    }
    public class PNJ
    {
        public string name;
        public string dialogue = "Je n'arrive pas à dormir, je voudrai un oreiller, peux-tu aller m'en chercher un?";
        public string dialogueQuestAccepted = "J'ai vraiment beasoin d'un oreiller.";
        public string dialogueQuestDone = "Je peux enfin dormir. Merci.";
        public Quest quest = new Quest("Dormir Tranquillement", "Ramène un oreiller au gus", "Oreiller", "Trophée", 1);
        
        public PNJ(string _name)
        {
            name = _name;
        }

        public void Talk(Inventaire inventory)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(name);
            Console.ForegroundColor = ConsoleColor.Gray;

            if (!quest.questDone)
            {
                if (!quest.questAccepted)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(dialogue);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    string reponse = Console.ReadLine();

                    if (reponse == "OK")
                    {
                        GiveQuest();
                        quest.questAccepted = true;
                    }
                    else
                    {
                        Console.WriteLine("Oh tant pis");
                    }
                }
                else
                {
                    if (inventory.ContainsItem(quest.itemName))
                    {
                        CompleteQuest();
                        inventory.AddItem(quest.recompense, 1);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(dialogueQuestAccepted);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
            else
            {
                Console.WriteLine(dialogueQuestDone);
            }
        }

        public void GiveQuest()
        {
            Console.Write("Nouvelle requete : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(quest.name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(quest.description);
        }

        public void CompleteQuest()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Oh, tu as un " + quest.itemName + ", tu me le donnes?");
            Console.ForegroundColor = ConsoleColor.Gray;

            string reponse = Console.ReadLine();

            if (reponse == "OK")
            {
                quest.questDone = true;
                Console.WriteLine("Requête " + quest.name + " terminée");
                Console.WriteLine("Vous gagner " + quest.recompense + ".");

            }
            else
            {
                Console.WriteLine("Oh tant pis");
            }
        }
    }
}
