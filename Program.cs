using Better_Cshark;
using System;
class Program
{
    static void Main()
    {
        int largeur = 30;
        int hauteur = 24;
        char[,] donjon = new char[hauteur, largeur];
        // Afficher la carte du donjon avec contours


        //MapMake.AfficherDonjon(donjon);
        //Console.Write("Tu commence l aventure Savun low cost! \n");
        // Afficher la carte du donjon avec contours
        string playerAffichage = "Statistiques/Player_Affichage.csv";
        FileManager.LecteurFichier(playerAffichage);
        Input.InputController();

        Console.ReadKey();
    }


}
