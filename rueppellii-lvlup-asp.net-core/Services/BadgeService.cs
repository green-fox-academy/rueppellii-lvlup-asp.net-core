using System.Collections.Generic;
using AutoMapper;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class BadgeService : ICrudService<BadgeDto, Badge>
    {
        private readonly ICrudRepository<Badge> respository;
        private readonly IMapper mapper;

        public BadgeService(ICrudRepository<Badge> respository, IMapper mapper)
        {
            this.respository = respository;
            this.mapper = mapper;
        }

        public IEnumerable<BadgeDto> GetAll()
        {
            var badgeList = respository.GetAll();

            return mapper.Map<IEnumerable<BadgeDto>>(badgeList);
        }

        public void Save(BadgeDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
