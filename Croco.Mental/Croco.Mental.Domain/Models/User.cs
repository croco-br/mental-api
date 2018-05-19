using Croco.Mental.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Croco.Mental.Domain.Models
{
    public sealed class User
    {
        public User() { } 

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public MoodQuestionnaire HumorData { get; set; }
    }
}
