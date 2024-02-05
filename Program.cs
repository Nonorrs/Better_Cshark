using Better_Cshark;
using System;
class Program
{
    static void Main(string[] args)
    {

        string playerAffichage = "Statistiques/Player_Affichage.csv";
        FileManager.LecteurFichier(playerAffichage);

        Console.Write("Bonjour tout le monde \n");
        Console.Write("Vous commencez l aventure Savun low cost! \n");

        char[,] donjon = Map.GenererDonjon();
        Map.AfficherDonjon(donjon);
        Input.MovePlayer(donjon);

        Console.ReadKey();
    }


}
