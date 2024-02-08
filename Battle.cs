using Better_Cshark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark
{
    public class Battle
    {
        static Random random = new Random();
        static bool PlayerBegin = false;
        static bool MobBegin = false;
        public static void BattleBegin()
        {
            if (Player.GetVit() > Mob.GetVit())
            {
                PlayerBegin = true;
                MobBegin = false;
            }
            else if(Player.GetVit() < Mob.GetVit())
            {
                MobBegin = true;
                PlayerBegin = false;
            }
            else if(Player.GetVit() == Mob.GetVit())
            {

                int resultat = random.Next(2);

                if (resultat == 0)
                {
                    PlayerBegin = true;
                    MobBegin = false;
                    BattleUpdate();
                }
                else
                {
                    MobBegin = true;
                    PlayerBegin = false;
                    BattleUpdate();
                }
            }
        }
        static void BattleEnd()
        {
            GameLoop gameLoop = new GameLoop();
            gameLoop.Loop();

        }
        static void BattleUpdate()
        {
            while (!(Player.GetPv() <= 0 && Mob.GetPv() <= 0))
            {
                if (PlayerBegin = true)
                {
                    Input.BattleInput();
                    string battlefight = Console.ReadLine();
                    string KappaChoice = Console.ReadLine();

                    switch (battlefight)
                    {
                        case "default":
                            Console.Write("Nan nan nan mauvais bouton mon con");
                            break;
                        case "1":

                            Console.Write("Tu choisis quel attaque ?");
                            switch (KappaChoice)
                            {
                                case "1": 
                                    int damage1 = (Player.GetAtt() + Player.GetCap1()) - Mob.GetDef();
                                    break;
                                    case "2":
                                    int damage2 = (Player.GetAtt() + Player.GetCap2()) - Mob.GetDef();
                                    break;
                            }

                            break;

                        case "2":
                            Console.WriteLine("Quel objet sacré veux-tu ?");
                            break;

                        case "3":
                            Console.WriteLine("Quel meme veux tu utilisé ?");
                            break;
                            
                        case "4":
                            Console.WriteLine("Caval Kenny ! Caval !");
                            int Aled = random.Next(3);
                            if (Aled > 2)
                            BattleEnd();
                            else
                            {
                                Console.WriteLine("Je vais t'atacher dans mon camion! j'ai de la corde");
                            }
                            break;
                    }
                    PlayerBegin = false;
                    MobBegin = true;
                }
                if (MobBegin = true)
                {
                    int Kappa = random.Next(2);

                    if(Kappa == 0) 
                    {
                    int damageMob = (Mob.GetAtt() + Mob.GetCap1()) - Player.GetDef();
                    }
                    else
                    {
                    int damageMob = (Mob.GetAtt() + Mob.GetCap2()) - Player.GetDef();
                    }
                    PlayerBegin = true;
                    MobBegin = false;
                }
            }
        }
    }
}
