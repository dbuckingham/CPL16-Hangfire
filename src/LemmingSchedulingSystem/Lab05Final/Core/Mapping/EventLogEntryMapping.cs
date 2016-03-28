using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Data;

namespace Core.Mapping
{
    public class EventLogEntryMapping : EntityTypeConfiguration<EventLogEntry>
    {
        public EventLogEntryMapping()
        {
            ToTable("EventLog");

            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Logger).HasMaxLength(50);
            Property(p => p.Level).HasMaxLength(10);
            Property(p => p.Message).HasMaxLength(4000);
            Property(p => p.Exception).HasMaxLength(4000);
            Property(p => p.StackTrace).HasMaxLength(4000);
            Property(p => p.ServiceInstanceId).HasMaxLength(32);
            Property(p => p.JobId).HasMaxLength(32);
        }
    }
}