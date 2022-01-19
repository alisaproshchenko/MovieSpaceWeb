namespace MoviesService.Repositories.IRepository
{
    public interface IEditSingleRepository<T>
    {
        public void Edit(T entity);
    }
}
