using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibPLAYER_STATS
{
    public class PLAYER_STATS : IPLAYER_STATS
    {
        public void AddPlayer()
        {
            Console.Write("Enter Player name: ");
            Name = Console.ReadLine();

            Console.WriteLine("Enter player stats");
            Console.Write("Str: ");
            Str = Convert.ToInt32(Console.ReadLine());
            Console.Write("Agi: ");
            Agi = Convert.ToInt32(Console.ReadLine());
            Console.Write("Int: ");
            Int = Convert.ToInt32(Console.ReadLine());

            Level = 0;
            CurrentExp = 0;
            LVLExp = 100;

            RemainingExp = LVLExp - CurrentExp;
        }

        public void AddExp(int amount)
        {
            CurrentExp += amount;

            if (CurrentExp > LVLExp)
            {
                int over = CurrentExp - LVLExp;
                Level += 1;
                LVLExp = 100 + Convert.ToInt32(100 * (Level * 0.1));


                Console.WriteLine($"Level Up! Now level {Level}");

                CurrentExp = over;

            }

            RemainingExp = LVLExp - CurrentExp;
        }

        public string Name { get; private set; }
        public int ID { get; private set; } = 0;


        public int Str { get; private set; }
        public int Agi { get; private set; }
        public int Int { get; private set; }

        public int Health { get; private set; }

        public int Level { get; private set; }
        public int CurrentExp { get; private set; }
        public int RemainingExp { get; private set; }
        public int LVLExp { get; private set; }
    }
}
