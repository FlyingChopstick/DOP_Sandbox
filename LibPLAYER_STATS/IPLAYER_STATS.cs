namespace LibPLAYER_STATS
{
    public interface IPLAYER_STATS
    {
        int Agi { get; }
        int CurrentExp { get; }
        int ID { get; }
        int Int { get; }
        int Level { get; }
        int LVLExp { get; }
        string Name { get; }
        int RemainingExp { get; }
        int Str { get; }

        void AddExp(int amount);
        void AddPlayer();
    }
}