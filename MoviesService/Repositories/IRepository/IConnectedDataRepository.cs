namespace MoviesService.Repositories.IRepository
{
    public interface IConnectedDataRepository<T>
    {
        public void Add(T entity);
        public void Edit(T entity);
        void Delete(int id);
    }
}
