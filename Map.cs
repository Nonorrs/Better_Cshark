using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Better_Cshark;
using System;

namespace Better_Cshark
{
    public class Map
    {
        public void AfficherMap1(int X, int Y)
        {
            string[] map1 = new string[]
            {
            "________________________________",
            "|                              |",
            "|                              |",
            "|  N                           |",
            "|                  XXXXXXXXXXXX|",
            "|                  XXXXXXXXXXXX|",
            "|                  XXXXXXXXXXXX|",
            "|                  XXXXXXXXXXXX|",
            "/-----------------/XXXXXXXXXXXX|",
            "|                  XXXXXXXXXXXX|",
            "|                              |",
            "|                              |",
            "| K                     K      |",
            "|                              |",
            "|______________________________|"
            };

            char[] rowArray = map1[Y].ToCharArray();

            // Update the character at the specified position
            rowArray[X] = '§';

            // Convert the char array back to a string and update the map
            map1[Y] = new string(rowArray);

            foreach (string line in map1)
            {
                Console.WriteLine(line);
            }
        }

        public bool isBush(int X, int Y)
        {
            int[,] the_map = GenererMap1();

            if (X < 0 || X >= the_map.GetLength(1))
                return false;
            if (Y < 0 || Y >= the_map.GetLength(0))
                return false;

            return the_map[Y, X] == 2;
        }

        public int[,] GenererMap1()
        {
            int[,] map1data = new int[,]
            {
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            };

            return map1data;
        }
    }
}