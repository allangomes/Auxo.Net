using System;
using System.Linq;
using System.Reflection;
using Auxo.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Auxo.Data
{
    public class DataContext : DbContext, IDataContext
    {
        protected DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;

            var method = modelBuilder.GetType().GetMethods().Single(m => m.Name == nameof(modelBuilder.Entity)
                            && m.ContainsGenericParameters && m.GetParameters().Count() == 0);
            var maps = assembly.GetTypes().Where(t => typeof(IMap).IsAssignableFrom(t));
            maps.Each(t => {
                var entityType = t.GetTypeInfo().BaseType.GenericTypeArguments[0];
                var entityMethod = method.MakeGenericMethod(entityType);
                Activator.CreateInstance(t, entityMethod.Invoke(modelBuilder, null));
            });
        }
    }
}