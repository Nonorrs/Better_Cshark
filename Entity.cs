using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark
{

    public class Entity
    {
        public static Dictionary<String, Entity> ReadDataFromCSV(string filePath)
        {
            Dictionary<String, Entity> charactersData = new Dictionary<String, Entity>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    //string headers = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        string[] columns = line.Split(',');

                        Entity entry = new Entity
                        {
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

                        charactersData.Add(entry.Nom, entry);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier CSV: {ex.Message}");
            }
            return charactersData;
        }

        public string Nom { get; set; }
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
