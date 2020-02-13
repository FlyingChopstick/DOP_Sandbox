namespace LibNPC_FACTORY
{
    public interface INPC_FACTORY
    {
        int[] LoadStats(NPC_Type selection);
        string[] LoadTraits(NPC_Type selection);
    }
}