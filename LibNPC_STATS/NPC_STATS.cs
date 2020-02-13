using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNPC_STATS
{
    //NPC Attack Type
    public enum AttackType
    {
        Melee,
        Ranged
    }

    //Contains information about all NPCs
    public class NPC_STATS : INPC_STATS
    {
        //Adds stats of the new Entity to the Lists
        public void AddEntity(int[] stats, string[] traits)
        {
            ID.Add(next_ID);
            Alive.Add(next_ID);
            

            Str.Add(stats[0]);
            Agi.Add(stats[1]);
            Int.Add(stats[2]);

            //Behaviour.Add(traits);
            Behaviour.Add(traits);

            ////selects the corresponding Behaviour
            switch (traits[1])
            {
                case "Friendly": Friendlies.Add(next_ID); break;

                case "Hostile": Hostiles.Add(next_ID); break;

                case "Neutral": Neutrals.Add(next_ID); break;

                default: Console.WriteLine("Error, assuming Neutral"); Neutrals.Add(next_ID); break;
            }

            switch (traits[2])
            {
                case "Melee": AttackDamage.Add(stats[0] + stats[1]); break;
                case "Ranged": AttackDamage.Add(stats[1] + stats[2]); break;
            }

            next_ID++;
        }

        //Kills an Entity, moving it to the Dead list and removing from it's Alignment list
        public void KillEntity(int in_ID)
        {
            int index = ID.IndexOf(in_ID);

            switch (Behaviour[index][1])
            {
                case "Friendly": Friendlies.RemoveAt(Friendlies.IndexOf(in_ID)); break;
                case "Hostile": Hostiles.RemoveAt(Hostiles.IndexOf(in_ID)); break;
                case "Neutral": Neutrals.RemoveAt(Neutrals.IndexOf(in_ID)); break;
            }

            Alive.Remove(in_ID);
            Dead.Add(in_ID);
        }

        //Prints all Alive entities
        public void ListAlive()
        {
            int number = Alive.Count;

            Console.WriteLine("=====ALIVE=====");
            for (int i = 0; i < number; i++)
            {
                var damageType = Behaviour[i][2];
                int position = ID.IndexOf(Alive[i]);
                Console.WriteLine($"Entity #{i} - {Behaviour[position][0]} - {Behaviour[position][1]}");
                Console.WriteLine($"ID {Alive[i]} || Str {Str[position]} Agi {Agi[position]} Int {Int[position]}");
                Console.WriteLine($"It's damage type is {damageType} and it deals {AttackDamage[i]} damage.");
                Console.WriteLine();
            }

            Console.WriteLine("===============");
        }
        //Prints all Dead entities
        public void ListDead()
        {
            int number = Dead.Count;

            Console.WriteLine("====DECEASED====");
            for (int i = 0; i < number; i++)
            {
                int position = ID.IndexOf(Dead[i]);
                Console.WriteLine($"Entity #{i} - {Behaviour[position][0]} - {Behaviour[position][1]}");
                Console.WriteLine($"ID {Dead[i]} || Str {Str[position]} Agi {Agi[position]} Int {Int[position]}");
                Console.WriteLine();
            }
            Console.WriteLine("================");
        }

        int next_ID = 1;
        //Entity ID, unique (hopefully)
        public List<int> ID { get; private set; } = new List<int>();
        //Entity Behaviour - list of traits
        public List<string[]> Behaviour { get; private set; } = new List<string[]>();

        public List<int> AttackDamage { get; private set; } = new List<int>();
        //Main stats
        public List<int> Str { get; private set; } = new List<int>();
        public List<int> Agi { get; private set; } = new List<int>();
        public List<int> Int { get; private set; } = new List<int>();


        //List of IDs of Friendly NPCs
        public List<int> Friendlies { get; private set; } = new List<int>();
        //List of IDs of Hostile NPCs
        public List<int> Hostiles { get; private set; } = new List<int>();
        //List of IDs of Neutral NPCs
        public List<int> Neutrals { get; private set; } = new List<int>();


        //List of IDs of Alive NPCs
        public List<int> Alive { get; private set; } = new List<int>();
        //List of IDs of Dead NPCs
        public List<int> Dead { get; private set; } = new List<int>();
    }
}
