using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Models
{
    public sealed class LogEntry
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }        
    }
}
