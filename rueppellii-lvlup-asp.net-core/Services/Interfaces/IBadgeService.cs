using rueppellii_lvlup_asp.net_core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Services.Interfaces
{
    public interface IBadgeService : ICreateService<BadgeDto>, IReadService<BadgeDto>
    {
    }
}
