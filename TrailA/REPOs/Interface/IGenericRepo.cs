namespace TrailA.REPOs.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
    }
}
