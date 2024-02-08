using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark
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

        public static void AddQuest(Quest quest)
        {
            quests.Add(quest);
        }

        public static void DisplayQuests()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("                QUETES                ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("║");
            Console.WriteLine("╠══════════════════════════════════════╣");

            foreach (var quest in Quest.quests)
            {
                Console.Write($"║ {quest.name,-24} : ");
                if (quest.questDone)
                {
                    Console.WriteLine(" Terminé  ║");
                }
                else
                {
                    Console.WriteLine("En Cours  ║");
                }
            }
            Console.WriteLine("╚══════════════════════════════════════╝");
        }

        public static void SaveQuests(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var quest in Quest.quests)
                    {
                        sw.WriteLine($"Quest: {quest.name}, Description: {quest.description}, " +
                                     $"Item Name: {quest.itemName}, Recompense: {quest.recompense}, " +
                                     $"Quantity: {quest.quantite}, Done: {quest.questDone}, Accepted: {quest.questAccepted}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Impossible de sauvegarder.");
            }
        }

        public static void LoadQuests(string filePath)
        {
            try
            {
                Quest.quests.Clear();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 7)
                        {
                            Quest quest = new Quest("NomQuete", "DescriptionQuete", "ItemQuete", "RecompenseQuete", 10); 
                            quest.name = parts[0].Split(':')[1].Trim();
                            quest.description = parts[1].Split(':')[1].Trim();
                            quest.itemName = parts[2].Split(':')[1].Trim();
                            quest.recompense = parts[3].Split(':')[1].Trim();
                            quest.quantite = int.Parse(parts[4].Split(':')[1].Trim());
                            quest.questDone = bool.Parse(parts[5].Split(':')[1].Trim());
                            quest.questAccepted = bool.Parse(parts[6].Split(':')[1].Trim());

                            // Ajouter la quête à la liste
                            Quest.quests.Add(quest);
                        }
                    }
                }

                Console.WriteLine("Quêtes chargées avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Impossible de charger les quêtes : {ex.Message}");
            }
        }

        public static List<Quest> quests;
    }
    public class PNJ
    {
        public int pnjX;
        public int pnjY;
        public string name;
        public string dialogue = "Je n'arrive pas à dormir, je voudrai un oreiller, peux-tu aller m'en chercher un?";
        public string dialogueQuestAccepted = "J'ai vraiment beasoin d'un oreiller.";
        public string dialogueQuestDone = "Je peux enfin dormir. Merci.";
        public Quest quest = new Quest("Dormir Tranquillement", "Ramène un oreiller au gus", "Oreiller", "Trophée", 1);

        public PNJ(string _name, int pnjX, int pnjY)
        {
            name = _name;
            this.pnjX = pnjX;
            this.pnjY = pnjY;
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

                    if (reponse == "OK" || reponse == "ok")
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
            Quest.AddQuest(quest);
        }

        public void CompleteQuest()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Oh, tu as un " + quest.itemName + ", tu me le donnes?");
            Console.ForegroundColor = ConsoleColor.Gray;

            string reponse = Console.ReadLine();

            if (reponse == "OK" || reponse == "ok")
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
