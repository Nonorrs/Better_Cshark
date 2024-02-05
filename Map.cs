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
        public static char[,] GenererDonjon()
        {
            // Définir la taille du donjon
            int largeur = 30;
            int hauteur = 24;

            // Initialiser la carte du donjon en utilisant une matrice de caractères
            char[,] donjon = new char[hauteur, largeur];

            // Initialiser les contours du donjon avec des murs
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    if (i == 0 || i == hauteur - 1 || j == 0 || j == largeur - 1)
                    {
                        donjon[i, j] = '#'; // Utiliser '#' pour représenter les murs aux contours
                    }
                    else
                    {
                        donjon[i, j] = ' '; // À l'intérieur de la carte, il n'y a rien
                    }
                }
            }

            return donjon;
        }

        public static void AfficherDonjon(char[,] donjon)
        {
            // Afficher la carte du donjon en parcourant la matrice
            for (int i = 0; i < donjon.GetLength(0); i++)
            {
                for (int j = 0; j < donjon.GetLength(1); j++)
                {
                    Console.Write(donjon[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void AfficherMap1(int X, int Y)
        {
            string[] map1 = new string[]
            {
            "________________________________",
            "|                              |",
            "|                              |",
            "|                              |",
            "|                  ▒▒▒▒▒▒▒▒▒▒▒▒|",
            "|                  ▒▒▒▒▒▒▒▒▒▒▒▒|",
            "|                  ▒▒▒▒▒▒▒▒▒▒▒▒|",
            "|                  ▒▒▒▒▒▒▒▒▒▒▒▒|",
            "/-----------------/▒▒▒▒▒▒▒▒▒▒▒▒|",
            "|                  ▒▒▒▒▒▒▒▒▒▒▒▒|",
            "|                              |",
            "|                              |",
            "|                              |",
            "|                              |",
            "|______________________________|"
            };

            char[] rowArray = map1[X].ToCharArray();

            // Update the character at the specified position
            rowArray[Y] = '§';

            // Convert the char array back to a string and update the map
            map1[X] = new string(rowArray);

            foreach (string line in map1)
            {
                Console.WriteLine(line);
            }

        }

        public static int[,] GenererMap1()
        {
            int[,] map1data = new int[,]
            {
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            };

            return map1data;
        }
    }
}