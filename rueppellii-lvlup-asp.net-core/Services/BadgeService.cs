using AutoMapper;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using rueppellii_lvlup_asp.net_core.Services.Interfaces;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class BadgeService : ICrudService<BadgeDto, Badge>
    {
        private readonly ICrudRepository<Badge> repository;
        private readonly IMapper mapper;

        public BadgeService(ICrudRepository<Badge> respository, IMapper mapper)
        {
            this.repository = respository;
            this.mapper = mapper;
        }

        public IEnumerable<BadgeDto> GetAll()
        {
            var badgeList = repository.GetAll();

            return mapper.Map<IEnumerable<BadgeDto>>(badgeList);
        }

        public void Save(BadgeDto dto)
        {
            var badgeModel = mapper.Map<Badge>(dto);
            repository.Save(badgeModel);
        }
    }
}
