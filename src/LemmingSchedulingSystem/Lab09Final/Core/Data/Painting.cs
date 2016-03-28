namespace Core.Data
{
    public class Painting : BaseEntity, IDashboard
    {
        public virtual Dashboard Dashboard { get; set; }
    }
}
