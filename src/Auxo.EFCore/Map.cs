using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auxo.Data
{
    public class Map<T> : IMap
        where T: class
    {
        public Map(EntityTypeBuilder<T> map)
        {
        }
    }
}