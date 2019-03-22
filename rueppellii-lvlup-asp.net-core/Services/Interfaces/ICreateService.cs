namespace rueppellii_lvlup_asp.net_core.Services.Interfaces
 
{
    public interface ICreateService<T> where T : class
    {
        void Save(T dto);
    }
}
