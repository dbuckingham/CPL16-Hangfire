using Core.Data;

namespace Core.Mapping
{
    public class BuildHouseMapping : BaseEntityMapping<BuildHouse>
    {
        public BuildHouseMapping()
        {
            HasRequired(p => p.Dashboard);
        }
    }
}
