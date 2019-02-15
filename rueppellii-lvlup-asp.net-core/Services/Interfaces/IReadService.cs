﻿using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public interface IReadService<U> where U : class
    {
        IEnumerable<U> GetAll();
        U GetById(long id);
    }
}
