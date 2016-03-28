namespace Core.Data
{
    public class Sales : BaseEntity, IDashboard
    {
        public virtual Dashboard Dashboard { get; set; }
    }
}
