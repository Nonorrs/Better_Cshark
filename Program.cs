using Better_Cshark;
using System;
class Program
{
    static void Main(string[] args)
    {

        /*string playerAffichage = "Statistiques/Player_Affichage.csv";
        FileManager.LecteurFichier(playerAffichage);*/

<<<<<<< HEAD
        MapMake.AfficherDonjon(donjon);
        Console.Write("Tu commence l aventure Savun low cost! \n");
        // Afficher la carte du donjon avec contours
        //FileManager.LecteurFichier();
        Input.InputController();
=======
<<<<<<< HEAD
        Console.Write("Bonjour tout le monde !\n");
=======
        /*Console.Write("Bonjour tout le monde \n");
>>>>>>> 4d599e9f09338806fd555abc462eac777b90f41b
        Console.Write("Vous commencez l aventure Savun low cost! \n");

        int[,] map1 = Map.GenererMap1();
        Input.MovePlayer(map1);*/

        Player.Stockeur();
>>>>>>> 9cb92d4bdd1d71cbbfb5160b15ee87c7d0a43589

        Console.ReadKey();
    }
}
