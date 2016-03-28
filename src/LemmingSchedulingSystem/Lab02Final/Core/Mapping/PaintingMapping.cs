using Core.Data;

namespace Core.Mapping
{
    public class PaintingMapping : BaseEntityMapping<Painting>
    {
        public PaintingMapping()
        {
            HasRequired(p => p.Dashboard);
        }
    }
}
