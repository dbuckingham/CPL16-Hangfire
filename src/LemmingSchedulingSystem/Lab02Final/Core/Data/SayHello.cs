namespace Core.Data
{
    public class SayHello : BaseEntity, IDashboard
    {
        public virtual Dashboard Dashboard { get; set; }
    }
}
