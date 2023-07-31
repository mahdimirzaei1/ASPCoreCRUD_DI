namespace ASPCoreCRUD_DI.Interfaces
{
    public interface IGeneric<T>
    {
        public Task<List<T>> Get();
        public Task<T> Get(int id);
        public void Create(T model);
        public void Update(T model);
        public T Delete(int id);
        public bool CheckExists(int id);
    }
}
