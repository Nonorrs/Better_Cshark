using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Better_Cshark
{
    class Player
    {
        /*char name;
        int PV;
        int PM;
        int ATK;
        int DEF;
        int VIT;

        char []Cap;*/
        //char NameCap;
        //int PMCap;
        //int PuiCap;
        //int PreCap;

        public static void Stockeur()
        {
            string filePath = "Statistiques/Stats_perso.csv";

            Dictionary<Perso, MyDataClass> charactersData = ReadDataFromCSV(filePath);

            Console.Write("Tapez correctement le personnage que vous voulez jouer (Fabio ou Maskass ou Cho_Mantis)\n");
            string userInput = Console.ReadLine();

            Perso selectedCharacter = GetPersoFromUserInput(userInput);


            if (charactersData.ContainsKey(selectedCharacter))
            {
                MyDataClass selectedCharactersData = charactersData[selectedCharacter];
                Console.WriteLine($"Nom: {selectedCharactersData.Nom}, Type: {selectedCharactersData.Type}, PV: {selectedCharactersData.PV}, PM: {selectedCharactersData.PM}, ATK: {selectedCharactersData.ATK}, DEF: {selectedCharactersData.DEF}, VIT: {selectedCharactersData.VIT}");
                Console.WriteLine($"Nom Cap1: {selectedCharactersData.Cap1}, \nPM Cap1: {selectedCharactersData.CPM1}, Puissance Cap1: {selectedCharactersData.PuiCap1}, Precision Cap1: {selectedCharactersData.PrecCap1}");
                Console.WriteLine($"Nom Cap2: {selectedCharactersData.Cap2}, \nPM Cap2: {selectedCharactersData.CPM2}, Puissance Cap2: {selectedCharactersData.PuiCap2}, Precision Cap2: {selectedCharactersData.PrecCap2}\n");

            }
            else
            {
                Console.WriteLine($"Personnage {selectedCharacter} non trouvé.");
            }



        }

        static Dictionary<Perso, MyDataClass> ReadDataFromCSV(string filePath)
        {
            Dictionary<Perso, MyDataClass> charactersData = new Dictionary<Perso, MyDataClass>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    //string headers = reader.ReadLine();
                    
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        string[] columns = line.Split(',');

                        MyDataClass entry = new MyDataClass
                        {
                            Perso = GetPersoFromUserInput(columns[0]),
                            Nom = columns[0],
                            Type = columns[1],
                            PV = int.Parse(columns[2]),
                            PM = int.Parse(columns[3]),
                            ATK = int.Parse(columns[4]),
                            DEF = int.Parse(columns[5]),
                            VIT = int.Parse(columns[6]),
                            Cap1 = columns[7],
                            CPM1 = int.Parse(columns[8]),
                            PuiCap1 = int.Parse(columns[9]),
                            PrecCap1 = int.Parse(columns[10]),
                            Cap2 = columns[11],
                            CPM2 = int.Parse(columns[12]),
                            PuiCap2 = int.Parse(columns[13]),
                            PrecCap2 = int.Parse(columns[14])
                        };

                        charactersData.Add(entry.Perso, entry);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier CSV: {ex.Message}");
            }
            return charactersData;
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

    enum Perso
    {
        Fabio,
        Maskass,
        Cho_Mantis
    }
    class MyDataClass
    {
        public Perso Perso {  get; set; }
        public string Nom {  get; set; }
        public string Type { get; set; }
        public int PV { get; set; }
        public int PM { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int VIT { get; set; }
        public string Cap1 { get; set; }
        public int CPM1 { get; set; }
        public int PuiCap1 { get; set; }
        public int PrecCap1 { get; set; }
        public string Cap2 { get; set; }
        public int CPM2 { get; set; }
        public int PuiCap2 { get; set; }
        public int PrecCap2 { get; set; }

    }

}