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
        private Player player;
        private Mob mob;
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
            int[,] map1 = Map.GenererMap1();
            Input.MovePlayer(map1);
        }
        static void BattleUpdate()
        {
            while (!(Player.GetPv() <= 0 && Mob.GetPv() <= 0))
            {
                if (PlayerBegin = true)
                {
                    Input.BattleInput();
                    string battlefight = Console.ReadLine();

                    switch (battlefight)
                    {
                        case "default":
                            Console.Write("Nan nan nan mauvais bouton mon con");
                            break;
                        case "1":
                            int damage = (Player.GetAtt() + Player.GetCap1()) - Mob.GetDef();
                            break;

                        case "2":
                            break;

                        case "3":
                            break;
                            
                        case "4":
                            BattleEnd();
                            break;
                    }
                }
            }
        }
    }
}
