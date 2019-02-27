namespace rueppellii_lvlup_asp.net_core.Services.Interfaces
{
    public interface ICrudService<U> : ICreateService<U>, IReadService<U> where U : class
    {
    }
}
