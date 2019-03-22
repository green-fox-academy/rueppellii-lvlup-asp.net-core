using System.Collections.Generic;
using AutoMapper;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using rueppellii_lvlup_asp.net_core.Services.Interfaces;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class BadgeService : IBadgeService
    {
        private readonly ICrudRepository<Badge> repository;
        private readonly IMapper mapper;

        public BadgeService(ICrudRepository<Badge> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<BadgeDto> GetAll()
        {
            return mapper.Map<IEnumerable<BadgeDto>>(repository.GetAll());
        }

        public void Save(BadgeDto dto)
        {
            var badgeModel = mapper.Map<Badge>(dto);
            repository.Save(badgeModel);
        }
    }
}
