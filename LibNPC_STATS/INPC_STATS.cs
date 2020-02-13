using System.Collections.Generic;

namespace LibNPC_STATS
{
    public interface INPC_STATS
    {
        List<int> Agi { get; }
        List<int> Alive { get; }
        List<int> AttackDamage { get; }
        List<string[]> Behaviour { get; }
        List<int> Dead { get; }
        List<int> Friendlies { get; }
        List<int> Hostiles { get; }
        List<int> ID { get; }
        List<int> Int { get; }
        List<int> Neutrals { get; }
        List<int> Str { get; }

        void AddEntity(int[] stats, string[] traits);
        void KillEntity(int in_ID);
        void ListAlive();
        void ListDead();
    }
}