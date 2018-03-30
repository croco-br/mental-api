using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Models
{
    public sealed class HumorData
    {
        public HumorData() => this.Owner = new User();
       
        public User Owner { get; set; }
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public double? Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
