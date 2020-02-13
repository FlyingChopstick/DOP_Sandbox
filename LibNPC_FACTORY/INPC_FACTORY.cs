namespace LibNPC_FACTORY
{
    public interface INPC_FACTORY
    {
        int[] LoadStats(NPC_FACTORY.NPC_Type selection);
        string[] LoadTraits(NPC_FACTORY.NPC_Type selection);
    }
}