using Better_Cshark;
using System;

class Program
{
    static void Main()
    {
        // Définir la taille du donjon
        int largeur = 40;
        int hauteur = 35;

        // Créer la carte du donjon en utilisant une matrice de caractères
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

        // Afficher la carte du donjon avec contours
        AfficherDonjon(donjon);

        FileManager.LecteurFichier();

        Console.ReadKey();
    }

    static void AfficherDonjon(char[,] donjon)
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
}
