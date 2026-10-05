namespace Library_System.Repo.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        void Delete(T entity);

    }
}
