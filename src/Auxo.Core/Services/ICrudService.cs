namespace Auxo.Services
{
    public interface ICrudService<T> : IReadService<T>
    {
        bool Validate(T model);

        T New();

        void Insert(T model);

        void Update(T model);

        void Delete(T model);
    }
}