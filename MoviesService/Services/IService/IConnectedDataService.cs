namespace MoviesService.Services.IService
{
    public interface IConnectedDataService<T>
    {
        public void Add(T entity);
        public void Edit(T entity);
        void Delete(T entity);
    }
}
