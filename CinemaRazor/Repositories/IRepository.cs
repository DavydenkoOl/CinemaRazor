namespace CinemaRazor.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetList();
        Task<T> GetObject(int id);
        Task AddObject(T obj);
        void UpdateObject(T obj);
        Task DeleteObject(int id);
        Task Save();
    }
}
