using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark
{
    public class Chest
    {
        public Item item;
        public bool isLocked = true;
        public bool isEmpty = false;
        public int ChestX = 2;
        public int ChestY = 14;

        public Chest(int X, int Y, Item _item) 
        {
            this.item = _item;
            this.ChestX = X;
            this.ChestY = Y;
        }

        public void FindChest(Inventaire inventory)
        {
            if (isEmpty)
            {
                Console.WriteLine("Ce koffre est vide....");
            }
            else
            {
                UnlockChest(inventory);
            }
        }
        public void UnlockChest(Inventaire inventory)
        {
            Console.WriteLine("Vous avez trouvé un koffre, utiliser une clef?");
            string reponse = Console.ReadLine();
            if (reponse == "ok")
            {
                inventory.RemoveItem("Clef");
                OpenChest(inventory);
            }
            else
            {
                Console.WriteLine("Tant Pis");
            }
        }
        public void OpenChest(Inventaire inventory)
        {
            isEmpty = true;
            Console.WriteLine("WOOOOOAW, vous avez trouvé " + item.name + "x" + item.quantity);
            inventory.AddItem(item.name, item.quantity);
        }
    }
}
