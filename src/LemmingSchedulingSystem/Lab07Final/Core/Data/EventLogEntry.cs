using System;

namespace Core.Data
{
    public class EventLogEntry
    {
        public int Id { get; set; }
        public string Logger { get; set; }
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public string ServiceInstanceId { get; set; }
        public string JobId { get; set; }
    }
}