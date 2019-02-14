using rueppellii_lvlup_asp.net_core.Dtos.BaseDtos;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class LevelDto : BaseLevelDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
