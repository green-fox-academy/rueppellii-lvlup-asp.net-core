﻿namespace rueppellii_lvlup_asp.net_core.Services.Interfaces
{
    /// <summary>
    /// U = dto
    /// T = entity
    /// </summary>
    public interface ICrudService<U, T> : ICreateService<U>, IReadService<U, T> where U : class where T : class
    {
    }
}
