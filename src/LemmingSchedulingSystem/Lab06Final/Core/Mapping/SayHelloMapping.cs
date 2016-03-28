using Core.Data;

namespace Core.Mapping
{
    public class SayHelloMapping : BaseEntityMapping<SayHello>
    {
        public SayHelloMapping()
        {
            HasRequired(p => p.Dashboard);
        }
    }
}
