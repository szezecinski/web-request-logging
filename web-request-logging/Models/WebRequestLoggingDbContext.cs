using Microsoft.EntityFrameworkCore;

namespace web_request_logging.Models
{
    public class WebRequestLoggingDbContext : DbContext
    {
        public DbSet<LogEvent> LogEvent { get; set; }

        public WebRequestLoggingDbContext(DbContextOptions<WebRequestLoggingDbContext> options)
            : base(options)
        {
        }
    }
}
