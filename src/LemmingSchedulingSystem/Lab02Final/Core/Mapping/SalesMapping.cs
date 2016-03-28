using Core.Data;

namespace Core.Mapping
{
    public class SalesMapping : BaseEntityMapping<Sales>
    {
        public SalesMapping()
        {
            HasRequired(p => p.Dashboard);
        }
    }
}
