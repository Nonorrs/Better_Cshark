using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace Better_Cshark
{
    class Item
    {
        public string name;
        public int quantity;
        public Item(string _name, int _quantity)
        {
            name = _name;
            quantity = _quantity;
        }
    }

    public class Inventaire
    {
        private List<Item> items = new List<Item>();

        public void AddItem(string name, int quantity)
        {
            var existingItem = items.FirstOrDefault(item => item.name == name);

            if (existingItem != null)
            {
                // Mettre à jour la quantité si l'article existe déjà
                existingItem.quantity += quantity;
            }
            else
            {
                // Ajouter un nouvel article s'il n'existe pas
                Item newItem = new Item(name, quantity);
                items.Add(newItem);
            }
        }

        public void RemoveItem(string name) 
        {
            var itemToRemove = items.FirstOrDefault(item => item.name == name);
            if (itemToRemove != null)
            {
                if (itemToRemove.quantity > 1)
                {
                    // Si la quantité est supérieure à 1, décrémenter la quantité
                    itemToRemove.quantity--;
                }
                else
                {
                    // Si la quantité est égale à 1, supprimer l'article de l'inventaire
                    items.Remove(itemToRemove);
                }
            }
        }

        public bool ContainsItem(string itemName)
        {
            return items.Exists(item => item.name == itemName);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("╔════════════════════════════╗");
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("         INVENTAIRE         ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("║");
            Console.WriteLine("╠════════════════════════════╣");
            foreach (var item in items)
            {
                Console.WriteLine($"║ {item.name,-20} x{item.quantity,-5}║");
            }
            Console.WriteLine("╚════════════════════════════╝");
        }

        public void SaveInventory(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var item in items)
                    {
                        sw.WriteLine(item.name);
                        sw.WriteLine(item.quantity);
                    }
                }
            }
            catch 
            { 
                Console.WriteLine("Impossible de sauvegarder.");
            }
        }

        public void LoadInventory(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string itemName = sr.ReadLine();
                        int itemQuantity;

                        // Essayez de convertir la quantité en entier
                        if (int.TryParse(sr.ReadLine(), out itemQuantity))
                        {
                            // Ajoutez l'article à la liste d'articles de l'inventaire
                            AddItem(itemName, itemQuantity); 
                        }
                    }
                }
                Console.WriteLine("Inventaire chargé avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail de charger");
            }
        }
    }
}
