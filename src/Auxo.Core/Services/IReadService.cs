using System.Threading.Tasks;
using Auxo.Data;

namespace Auxo.Services
{
    public interface IReadService<T>
    {
        IQuery<T> Query();

        Task<T> this[object value] { get; }
    }
}