namespace MoviesService.Repositories.IRepository
{
    public interface IAddSingleRepository<T>
    {
        public void Add(T entity);
    }
}
