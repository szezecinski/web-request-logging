using System;

namespace web_request_logging.Models
{
    public class LogEvent
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }


        public LogEvent()
        {
            Id = new Guid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
