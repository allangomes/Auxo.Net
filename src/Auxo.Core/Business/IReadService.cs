using System.Threading.Tasks;
using Auxo.Data;

namespace Auxo.Business
{
    public interface IReadService<T>
    {
        int Count();
        IQuery<T> Query();

        Task<T> this[object value] { get; }
    }
}