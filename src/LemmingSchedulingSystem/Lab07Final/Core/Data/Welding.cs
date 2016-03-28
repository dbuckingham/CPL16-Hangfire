namespace Core.Data
{
    public class Welding : BaseEntity, IDashboard
    {
        public virtual Dashboard Dashboard { get; set; }
    }
}
