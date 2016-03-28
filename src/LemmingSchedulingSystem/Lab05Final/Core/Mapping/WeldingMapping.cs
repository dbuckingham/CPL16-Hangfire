using Core.Data;

namespace Core.Mapping
{
    public class WeldingMapping : BaseEntityMapping<Welding>
    {
        public WeldingMapping()
        {
            HasRequired(p => p.Dashboard);
        }
    }
}
