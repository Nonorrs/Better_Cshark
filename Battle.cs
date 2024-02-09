using System;

namespace Better_Cshark
{
    public class Battle
    {
        public static void StartBattle()
        {
            Console.WriteLine("Un combat débute !");

            // Sélection des personnages
            Console.WriteLine("Choisissez votre personnage :");
            Entity? playerData = Player.Stockeur();
            Console.WriteLine("Choisissez votre adversaire :");
            Entity mobData = Mob.MStockeur();

            // Déterminer qui commence en fonction de la vitesse
            bool playerFirst = playerData.VIT >= mobData.VIT;

            // Déroulement du combat
            while (playerData.PV > 0 && mobData.PV > 0)
            {
                if (playerFirst)
                {
                    // Tour du joueur
                    Console.WriteLine("\nTour du joueur :");
                    PlayerTurn(playerData, mobData);
                    if (mobData.PV <= 0) break;

                    // Tour de l'adversaire
                    Console.WriteLine("\nTour de l'adversaire :");
                    EnemyTurn(mobData, playerData);
                }
                else
                {
                    // Tour de l'adversaire
                    Console.WriteLine("\nTour de l'adversaire :");
                    EnemyTurn(mobData, playerData);
                    if (playerData.PV <= 0) break;

                    // Tour du joueur
                    Console.WriteLine("\nTour du joueur :");
                    PlayerTurn(playerData, mobData);
                }
            }

            // Résultat du combat
            if (playerData.PV <= 0)
            {
                Console.WriteLine("\nVous avez perdu !");
            }
            else
            {
                Console.WriteLine("\nVous avez gagné !");
            }
        }

        public static void PlayerTurn(Entity player, Entity enemy)
        {
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine("1. Attaquer");
            Console.WriteLine("2. Utiliser un objet");
            Console.WriteLine("3. Changer de joueur");
            Console.WriteLine("4. Fuir");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AttackAndApplyDamage(player, enemy);
                    break;
                case "2":
                    Console.WriteLine("Fonctionnalité non implémentée.");
                    break;
                case "3":
                    Console.WriteLine("Vous changez de joueur !");
                    player = Player.Stockeur();
                    break;
                case "4":
                    Console.WriteLine("Vous avez fui le combat !");
                    player.PV = 0; // Mettre les PV du joueur à 0 pour indiquer qu'il a fui le combat
                    break;
                default:
                    Console.WriteLine("Choix invalide, votre personnage attaque par défaut.");
                    AttackAndApplyDamage(player, enemy);
                    break;
            }
        }

        public static void EnemyTurn(Entity enemy, Entity player)
        {
            // Logique pour le tour de l'ennemi
            AttackAndApplyDamage(enemy, player);
        }

        public static void AttackAndApplyDamage(Entity attacker, Entity target)
        {
            Random rnd = new Random();
            int damage = (attacker.ATK + rnd.Next(1, 11)) - target.DEF;

            Console.WriteLine($"{attacker.Nom} attaque {target.Nom} et lui inflige {damage} points de dégâts.");

            if (damage > 0)
            {
                target.PV -= damage;
                if (target.PV < 0)
                    target.PV = 0;
            }
            else
            {
                Console.WriteLine($"{target.Nom} a bloqué l'attaque !");
            }
        }
    }
}
