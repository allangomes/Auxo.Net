using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auxo.Data
{
    internal interface IMap
    {
    }

    public class Map<T> : IMap
        where T: class
    {
        public Map(EntityTypeBuilder<T> map)
        {
        }
    }
}