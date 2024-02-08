using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Better_Cshark
{
    public class Mob
    {
        private static Dictionary<String, Entity>? Mobs;
        public static Entity? MStockeur()
        {
            string filePath = "Statistiques/C_Shark_Mob.csv";
            if (Mobs is null)
            {
                Mobs = Entity.ReadDataFromCSV(filePath);
            }

            Random r = new Random();

            // retrive all names
            List<String> lMobsName = Mobs.Keys.ToList();

            //pickup a random nanme into this list 
            int iTheMob = r.Next(0, lMobsName.Count);
            String modNameToFight = lMobsName[iTheMob];

            //return the Mob entity for this Name
            return Mobs[modNameToFight];
        }
    }

}