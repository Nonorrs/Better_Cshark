using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark
{
    public class Mob
    {


        public static MyDataClassMob MStockeur()
        {
            string filePath = "Statistiques/C_Shark_Mob.csv";

            Dictionary<MPerso, MyDataClassMob> charactersData = ReadDataFromCSV(filePath);

            Console.Write("\nTapez correctement le personnage que vous voulez jouer (Fabio ou Maskass ou Cho_Mantis)\n");
            string userInput = Console.ReadLine();

            MPerso selectedCharacter = GetPersoFromUserInput(userInput);



            if (charactersData.ContainsKey(selectedCharacter))
            {
                MyDataClassMob selectedCharactersData = charactersData[selectedCharacter];

                Console.WriteLine($"\nNom: {selectedCharactersData.MNom}, Type: {selectedCharactersData.MType}, PV: {selectedCharactersData.MPV}, PM: {selectedCharactersData.MPM}, ATK: {selectedCharactersData.MATK}, DEF: {selectedCharactersData.MDEF}, VIT: {selectedCharactersData.MVIT}");
                Console.WriteLine($"Nom Cap1: {selectedCharactersData.MCap1}, \nPM Cap1: {selectedCharactersData.MCPM1}, Puissance Cap1: {selectedCharactersData.MPuiCap1}, Precision Cap1: {selectedCharactersData.MPrecCap1}");
                Console.WriteLine($"Nom Cap2: {selectedCharactersData.MCap2}, \nPM Cap2: {selectedCharactersData.MCPM2}, Puissance Cap2: {selectedCharactersData.MPuiCap2}, Precision Cap2: {selectedCharactersData.MPrecCap2}\n");

                return selectedCharactersData;
            }
            else
            {
                Console.WriteLine($"Personnage {selectedCharacter} non trouvé.\n");
                return null;
            }
        }

        static Dictionary<MPerso, MyDataClassMob> ReadDataFromCSV(string filePath)
        {
            Dictionary<MPerso, MyDataClassMob> charactersData = new Dictionary<MPerso, MyDataClassMob>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    //string headers = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        string[] columns = line.Split(',');

                        MyDataClassMob entry = new MyDataClassMob
                        {
                            Mob = GetPersoFromUserInput(columns[0]),
                            MNom = columns[0],
                            MType = columns[1],
                            MPV = int.Parse(columns[2]),
                            MPM = int.Parse(columns[3]),
                            MATK = int.Parse(columns[4]),
                            MDEF = int.Parse(columns[5]),
                            MVIT = int.Parse(columns[6]),
                            MCap1 = columns[7],
                            MCPM1 = int.Parse(columns[8]),
                            MPuiCap1 = int.Parse(columns[9]),
                            MPrecCap1 = int.Parse(columns[10]),
                            MCap2 = columns[11],
                            MCPM2 = int.Parse(columns[12]),
                            MPuiCap2 = int.Parse(columns[13]),
                            MPrecCap2 = int.Parse(columns[14])
                        };

                        charactersData.Add(entry.Mob, entry);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier CSV: {ex.Message}");
            }
            return charactersData;
        }

        static MPerso GetPersoFromUserInput(string userInput)
        {
            foreach (MPerso perso in Enum.GetValues(typeof(MPerso)))
            {
                if (string.Equals(userInput, perso.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return perso;
                }
            }
            return MPerso.Thwomp;
        }
        public static int GetPv()
        {
            MyDataClassMob selectedCharactersData = MStockeur();
            if (selectedCharactersData != null)
            {
                return selectedCharactersData.MPV;
            }
            return 0;
        }
        public static int GetVit()
        {
            MyDataClassMob selectedCharactersData = MStockeur();
            if (selectedCharactersData != null)
            {
                return selectedCharactersData.MVIT;
            }
            return 0;
        }
        public static int GetAtt()
        {
            MyDataClassMob selectedCharactersData = MStockeur();
            if (selectedCharactersData != null)
            {
                return selectedCharactersData.MATK;
            }
            return 0;
        }
        public static int GetDef()
        {
            MyDataClassMob selectedCharactersData = MStockeur();
            if (selectedCharactersData != null)
            {
                return selectedCharactersData.MDEF;
            }
            return 0;
        }
        public static int GetCap1()
        {
            MyDataClassMob selectedCharactersData = MStockeur();
            if (selectedCharactersData != null)
            {
                return selectedCharactersData.MPuiCap1;
            }
            return 0;
        }

        public static int GetCap2()
        {
            MyDataClassMob selectedCharactersData = MStockeur();
            if (selectedCharactersData != null)
            {
                return selectedCharactersData.MPuiCap2;
            }
            return 0;
        }

    }

    public enum MPerso
    {
       Thwomp,
       Detective_Pillow,
       LeConduit,
       Boogie,
       ChoPathe,

    }
    public class MyDataClassMob
    {
        public MPerso Mob { get; set; }
        public string MNom { get; set; }
        public string MType { get; set; }
        public int MPV { get; set; }
        public int MPM { get; set; }
        public int MATK { get; set; }
        public int MDEF { get; set; }
        public int MVIT { get; set; }
        public string MCap1 { get; set; }
        public int MCPM1 { get; set; }
        public int MPuiCap1 { get; set; }
        public int MPrecCap1 { get; set; }
        public string MCap2 { get; set; }
        public int MCPM2 { get; set; }
        public int MPuiCap2 { get; set; }
        public int MPrecCap2 { get; set; }
    }



}