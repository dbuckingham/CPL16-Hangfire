using Core.Data;

namespace Core.Mapping
{
    public class PlumbingMapping : BaseEntityMapping<Plumbing>
    {
        public PlumbingMapping()
        {
            HasRequired(p => p.Dashboard);
        }
    }
}
