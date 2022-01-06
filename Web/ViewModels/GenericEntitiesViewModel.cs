namespace Web.ViewModels
{
    public class GenericEntitiesViewModel<T>
    {
        public T Entity { get; set; }
        public GenericEntitiesViewModel(T entity) => Entity = entity;
    }
}