using System.Collections.Generic;

namespace Croco.Mental.Domain.Models
{
    public sealed class User
    {
        public User() => this.UserHumorData = new List<HumorData>();
        
        public int Id { get; set; }
        public string Name { get; set; }
        List<HumorData> UserHumorData { get; set; }
    }
}
