using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    
    public class ExceptionLog
    {
        public int Id { get; set; }
        public string EventId { get; set; } = Guid.NewGuid().ToString();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? QueryParameters { get; set; }
        public string? BodyParameters { get; set; }
        public string? StackTrace { get; set; }
        public string? ExceptionType { get; set; }
         public string? Message { get; set; }
    }

        
}
