using rueppellii_lvlup_asp.net_core.Dtos.BaseDtos;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class GetLevelsDto : BaseLevelDto
    {
        public List<LevelDto> Badges { get; set; }
    }
}
