using System.Data.Entity.ModelConfiguration;
using Core.Data;

namespace Core.Mapping
{
    public abstract class BaseEntityMapping<TEntity>  : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        protected BaseEntityMapping()
        {
            HasKey(p => p.Id);
            Property(p => p.Created).IsRequired();
        }
    }
}
