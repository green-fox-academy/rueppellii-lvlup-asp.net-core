namespace rueppellii_lvlup_asp.net_core.Models
{
    public class ArchetypeLevel
    {
        public long ArchetypeId { get; set; }
        public Archetype Archetype { get; set; }

        public long LevelId { get; set; }
        public Level Level { get; set; }
    }
}
