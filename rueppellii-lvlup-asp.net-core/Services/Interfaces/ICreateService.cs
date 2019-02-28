namespace rueppellii_lvlup_asp.net_core.Services.Interfaces
 
{
    /// <summary>
    /// U = dto
    /// Save & Update methods
    /// </summary>
    public interface ICreateService<U> where U : class
    {
        void Save(U dto);
    }
}
