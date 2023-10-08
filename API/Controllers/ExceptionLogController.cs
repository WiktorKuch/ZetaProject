using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataContext;
using Microsoft.AspNetCore.Mvc;
using API.Entities;

namespace API.Controllers
{
    [Route("api/exceptions")]
    [ApiController]
    public class ExceptionLogController : ControllerBase
    {
    private readonly YourDbContext _context;

    public ExceptionLogController(YourDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> LogException(ExceptionLog exceptionLog)
    {
        _context.ExceptionLogs.Add(exceptionLog);
        await _context.SaveChangesAsync();

        if (exceptionLog.ExceptionType == "SecureException")
        {
            return StatusCode(500, new
            {
                type = exceptionLog.ExceptionType,
                id = exceptionLog.EventId,
                data = new { message = exceptionLog.Message }
            });
        }
        else
        {
            return StatusCode(500, new
            {
                type = "Exception",
                id = exceptionLog.EventId,
                data = new { message = "Internal server error ID = " + exceptionLog.EventId }
            });
        }
    }
  }
}