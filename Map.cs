using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark
{
    public class MapMake
    {
        public static void AfficherDonjon(char[,] donjon)
        {
            // Définir la taille du donjon
            int largeur = 30;
            int hauteur = 24;

            // Créer la carte du donjon en utilisant une matrice de caractères
            donjon = new char[hauteur, largeur];

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
    }
}