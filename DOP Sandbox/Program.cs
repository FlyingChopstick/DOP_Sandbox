using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibNPC_FACTORY;
using LibNPC_STATS;
using LibPLAYER_STATS;


namespace MainSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            IPLAYER_STATS PLayer = new PLAYER_STATS();

            PLayer.AddPlayer();

            Console.WriteLine();
            Console.Write("Number of entities to add: ");
            String input = Console.ReadLine();
            UInt32 number = Convert.ToUInt32(input);
            Console.Write("Entity name: ");
            string NPCType = Console.ReadLine();


            //Contains NPC values
            INPC_STATS NPCstats = new NPC_STATS();
            //Contains stats and traits for all entitites
            INPC_FACTORY factory = new NPC_FACTORY();


            int[] stats = new int[NPC_FACTORY.NumberOfStats];
            string[] traits = new string[NPC_FACTORY.NumberOfTraits];

            //creates stats[] for the entity
            stats = factory.LoadStats(NPC_Type.Old_Dragon);
            //creates traits[] for the entity
            traits = factory.LoadTraits(NPC_Type.Old_Dragon);
            //Adds a new entity
            NPCstats.AddEntity(stats, traits);


            switch (NPCType)
            {
                case "Drunkard":
                    for (int i = 0; i < number; i++)
                    {
                        stats = factory.LoadStats(NPC_Type.Drunkard);
                        traits = factory.LoadTraits(NPC_Type.Drunkard);
                        NPCstats.AddEntity(stats, traits);
                    }
                    break;

                case "Guard_Archer":
                    for (int i = 0; i < number; i++)
                    {
                        stats = factory.LoadStats(NPC_Type.Guard_Archer);
                        traits = factory.LoadTraits(NPC_Type.Guard_Archer);
                        NPCstats.AddEntity(stats, traits);
                    }
                    break;

                case "Old_Dragon":
                    for (int i = 0; i < number; i++)
                    {
                        stats = factory.LoadStats(NPC_Type.Old_Dragon);
                        traits = factory.LoadTraits(NPC_Type.Old_Dragon);
                        NPCstats.AddEntity(stats, traits);
                    }
                    break;

                default: Console.WriteLine("NPC type not found"); break;
            }




            Console.WriteLine();
            Console.WriteLine("Player");
            Console.WriteLine($"ID {PLayer.ID} || Str: {PLayer.Str} Agi {PLayer.Agi} Int {PLayer.Int}");

            NPCstats.ListAlive();

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
            NPCstats.KillEntity(NPCstats.ID[0]);

            NPCstats.ListAlive();
            Console.WriteLine();
            Console.WriteLine($"There are {NPCstats.Friendlies.Count} Friendly, {NPCstats.Hostiles.Count} Hostile and {NPCstats.Neutrals.Count} Neutral entities.");

            Console.WriteLine();
            NPCstats.ListDead();

            Console.ReadLine();
        }
    }
}
