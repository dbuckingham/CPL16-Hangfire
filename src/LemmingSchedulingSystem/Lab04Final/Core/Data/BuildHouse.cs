namespace Core.Data
{
    public class BuildHouse : BaseEntity, IDashboard
    {
        public virtual Dashboard Dashboard { get; set; }
    }
}
