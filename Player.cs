using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Better_Cshark
{
    public class Player
    {
        public int playerX = 6;
        public int playerY = 6;

        private static Dictionary<String, Entity>? Characters;

        public Inventaire inventory = new Inventaire();
        public static Entity? Stockeur()
        {
            string filePath = "Statistiques/Stats_perso.csv";


            //init : charger fichier csv
            if (Characters is null)
            {
                Characters = Entity.ReadDataFromCSV(filePath);
            }


            Console.Write("\nTapez correctement le personnage que vous voulez jouer (Fabio ou Maskass ou Cho_Mantis)\n");
            string characterName = Console.ReadLine();

            //person non trouve
            if (!Characters.ContainsKey(characterName))
            {
                Console.WriteLine($"Personnage {characterName} non trouvé.\n");
                return null;
            }

            Entity selectedCharacters = Characters[characterName];

            Console.WriteLine($"\nNom: {selectedCharacters.Nom}, Type: {selectedCharacters.Type}, PV: {selectedCharacters.PV}, PM: {selectedCharacters.PM}, ATK: {selectedCharacters.ATK}, DEF: {selectedCharacters.DEF}, VIT: {selectedCharacters.VIT}");
            Console.WriteLine($"Nom Cap1: {selectedCharacters.Cap1}, \nPM Cap1: {selectedCharacters.CPM1}, Puissance Cap1: {selectedCharacters.PuiCap1}, Precision Cap1: {selectedCharacters.PrecCap1}");
            Console.WriteLine($"Nom Cap2: {selectedCharacters.Cap2}, \nPM Cap2: {selectedCharacters.CPM2}, Puissance Cap2: {selectedCharacters.PuiCap2}, Precision Cap2: {selectedCharacters.PrecCap2}\n");

            if (selectedCharacters.PV > 0)
            {
                return selectedCharacters;
            }

            return null;
        }


        static Perso GetPersoFromUserInput(string userInput)
        {
            foreach (Perso perso in Enum.GetValues(typeof(Perso)))
            {
                if (string.Equals(userInput, perso.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return perso;
                }
            }
            return Perso.Fabio;
        }
    }

    public enum Perso
    {
        Fabio,
        Maskass,
        Cho_Mantis
    }
    
}