using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSpace
{
    public enum Type
    {
        Hostile,
        Friendly,
        Neutral
    }

    public class PLAYER_STATS
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
                LVLExp = 100 + Convert.ToInt32(100 * (Level*0.1));


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

            public int Level { get; private set; } 
            public int CurrentExp { get; private set; }
            public int RemainingExp { get; private set; }
            public int LVLExp { get; private set; }
    }

    public class NPC_STATS
    {
        //public void AddPlayer()
        //{
        //    ID.Add(0);

        //    Console.WriteLine("Enter Player stats");
        //    Console.Write("Str: ");
        //    Str.Add(Convert.ToInt32(Console.ReadLine()));
        //    Console.Write("Agi: ");
        //    Agi.Add(Convert.ToInt32(Console.ReadLine()));
        //    Console.Write("Int: ");
        //    Int.Add(Convert.ToInt32(Console.ReadLine()));
        //}

        public void AddEntity(int[] stats)
        {
            ID.Add(stats[0]);
            Str.Add(stats[1]);
            Agi.Add(stats[2]);
            Int.Add(stats[3]);

            switch (stats[4])
            {
                case 1: Behavior.Add(Type.Friendly); Friendlies.Add(stats[0]); break;

                case 2: Behavior.Add(Type.Hostile); Hostiles.Add(stats[0]); break;

                case 3: Behavior.Add(Type.Neutral); Neutrals.Add(stats[0]); break;

                default: Console.WriteLine("Error, defaulting to Neutral"); Behavior.Add(Type.Neutral); Neutrals.Add(stats[0]); break;
            }

        }

        public void RemoveEntity(int in_ID)
        {
            int index = ID.IndexOf(in_ID);

            ID.RemoveAt(index);
            Str.RemoveAt(index);
            Agi.RemoveAt(index);
            Int.RemoveAt(index);
            
            switch (Behavior[index])
            {
                case Type.Friendly: Friendlies.RemoveAt(Friendlies.IndexOf(in_ID)); break;
                case Type.Hostile: Hostiles.RemoveAt(Hostiles.IndexOf(in_ID)); break;
                case Type.Neutral: Neutrals.RemoveAt(Neutrals.IndexOf(in_ID)); break;
            }

            Behavior.RemoveAt(index);
        }

        public void ListEntities()
        {
            int number = ID.Count;
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Entity #{i} - {Behavior[i]}");
                Console.WriteLine($"ID {ID[i]} || Str {Str[i]} Agi {Agi[i]} Int {Int[i]}");
            }
        }

        void SetType(int in_ID, Type in_type)
        {
            Behavior[ID.IndexOf(in_ID)] = in_type;
        }

        public List<int> ID { get; private set; } = new List<int>();
        public List<Type> Behavior { get; private set; } = new List<Type>();
        public List<int> Str { get; private set; } = new List<int>();
        public List<int> Agi { get; private set; } = new List<int>();
        public List<int> Int { get; private set; } = new List<int>();


        public List<int> Friendlies { get; private set; } = new List<int>();
        public List<int> Hostiles { get; private set; } = new List<int>();
        public List<int> Neutrals { get; private set; } = new List<int>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            PLAYER_STATS PLayer = new PLAYER_STATS();
            NPC_STATS NPCstats = new NPC_STATS();

            PLayer.AddPlayer();

            Console.WriteLine();
            Console.Write("Number of entities to add: ");
            String input = Console.ReadLine();
            UInt32 number = Convert.ToUInt32(input);


            int[] stats = new int[5];
            for (int i = 0; i < number; i++)
            {
                stats[0] = random.Next(1, 1000);
                for (int j = 1; j < 4; j++)
                {
                    stats[j] = random.Next(1, 10);
                }
                stats[4] = random.Next(1, 4);
                NPCstats.AddEntity(stats);
            }

            Console.WriteLine();
            Console.WriteLine("Player");
            Console.WriteLine($"ID {PLayer.ID} || Str: {PLayer.Str} Agi {PLayer.Agi} Int {PLayer.Int}");

            NPCstats.ListEntities();


            Console.WriteLine();
            Console.WriteLine($"There are {NPCstats.Friendlies.Count} Friendly, {NPCstats.Hostiles.Count} Hostile and {NPCstats.Neutrals.Count} Neutral entities.");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Player level is {PLayer.Level}. {PLayer.RemainingExp} exp to the next level.");
            PLayer.AddExp(20);
            Console.WriteLine($"Adding 20 exp... Now {PLayer.RemainingExp} exp to the next level.");
            Console.WriteLine($"Adding 100 exp...");
            PLayer.AddExp(100);
            Console.WriteLine($"{PLayer.RemainingExp} exp to the next level. (out of {PLayer.LVLExp})");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Killing Entity #0. ");
            NPCstats.RemoveEntity(NPCstats.ID[0]);

            NPCstats.ListEntities();
            Console.WriteLine();
            Console.WriteLine($"There are {NPCstats.Friendlies.Count} Friendly, {NPCstats.Hostiles.Count} Hostile and {NPCstats.Neutrals.Count} Neutral entities.");

            Console.ReadLine();
        }
    }
}
