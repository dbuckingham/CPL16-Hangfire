namespace Core.Data
{
    public class Plumbing : BaseEntity, IDashboard
    {
        public virtual Dashboard Dashboard { get; set; }
    }
}
