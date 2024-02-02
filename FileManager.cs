using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace Better_Cshark
{
    class FileManager
    {
        public static void LecteurFichier()
        {
            string nomFichierCsv = "Statistiques/Perso.csv";
            string cheminFichierCsv = Path.Combine(Directory.GetCurrentDirectory(), nomFichierCsv);

            if (File.Exists(cheminFichierCsv))
            {
                LireFichierCsv(cheminFichierCsv);
            }
            else
            {
                Console.WriteLine("Le fichier CSV n'existe pas.");
            }
        }

        static void LireFichierCsv(string cheminFichier)
        {
            using (TextFieldParser parser = new TextFieldParser(cheminFichier))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] champs = parser.ReadFields();

                    foreach (string champ in champs)
                    {
                        Console.Write(champ + "\t");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}