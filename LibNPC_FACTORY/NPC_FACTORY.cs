using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNPC_FACTORY
{
    //Different types of NPCs
    public enum NPC_Type
    {
        Drunkard,
        Guard_Archer,
        Old_Dragon
    }





    //Handles the assignment of the Stats[] and Traits[]
    public class NPC_FACTORY : INPC_FACTORY
    {
        public const int NumberOfTypes = 3;
        public const int NumberOfTraits = 4;
        public const int NumberOfStats = 3;

        Random random = new Random();

        Dictionary<NPC_Type, int> Behavior = new Dictionary<NPC_Type, int>()
        {
            { NPC_Type.Drunkard, 0},
            { NPC_Type.Guard_Archer, 1},
            { NPC_Type.Old_Dragon, 2}
        };

        string[,] NPC_Traits = new string[NumberOfTypes, NumberOfTraits]
        {
            { "Drunkard", "Neutral", "Melee", "Common" },
            { "Castle Archer", "Friendly", "Ranged", "Strong" },
            { "Old Dragon", "Hostile", "Ranged", "Boss"}
        };

        int[,] NPC_StatsRange = new int[NumberOfTypes, NumberOfStats * 2]
        {
            { 1,5, 1,6, 1,3 },
            { 5,7, 6,9, 4,7},
            { 7,10, 7,8, 10,10}
        };


        public string[] LoadTraits(NPC_Type selection)
        {
            int target = Behavior[selection];

            string[] traits = new string[NumberOfTraits];

            for (int i = 0; i < NumberOfTraits; i++)
            {
                traits[i] = NPC_Traits[target, i];
            }
            return traits;
        }

        public int[] LoadStats(NPC_Type selection)
        {
            int target = Behavior[selection];

            int[] stats = new int[NumberOfStats];

            for (int i = 0; i < NumberOfStats * 2 - 1; i += 2)
            {
                stats[i / 2] = random.Next(NPC_StatsRange[target, i], NPC_StatsRange[target, i + 1]);
            }

            return stats;
        }
    }
}
