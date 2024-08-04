namespace CoffeeStoreManagementApp.Repositories.Interface
{
    public interface IIntermediateModelRepository<k, l, T> where T : class
    {
        public Task<T> Add(T item);

      
    }
}
