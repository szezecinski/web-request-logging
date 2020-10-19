using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_request_logging.Models;

namespace web_request_logging.Controllers
{
    [Controller]
    [Route("Logging")]
    public class LoggingController : Controller
    {
        private WebRequestLoggingDbContext _context;

        public LoggingController(WebRequestLoggingDbContext context)
        {
            _context = context;
        }

        [HttpGet("Home")]
        public IActionResult Home()
        {
            return Ok("ʅʕ•ᴥ•ʔʃ - I'm ready.");
        }

        [HttpDelete("DeleteAll")]
        public async Task<ActionResult<LogEvent>> DeleteAll()
        {
            var logEvent = _context.LogEvent.ToList();
            if (logEvent == null)
            {
                return Ok();
            }

            _context.LogEvent.RemoveRange(logEvent);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Post")]
        public async Task<ActionResult<LogEvent>> Post()
        {
            var logEvent = new LogEvent();
            string rawContent = null;

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                rawContent = reader.ReadToEndAsync().Result;

                if (!String.IsNullOrEmpty(rawContent))
                {
                    logEvent.Content = rawContent;
                }
            }

            _context.LogEvent.Add(logEvent);
            await _context.SaveChangesAsync();

            return Ok(JsonConvert.SerializeObject(logEvent));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<LogEvent>>> GetAll()
        {
            return await _context.LogEvent.ToListAsync();
        }

    }
}
