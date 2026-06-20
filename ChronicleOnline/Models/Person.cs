using System;
using System.Collections.Generic;
using System.Text;

namespace ChronicleOnline.Models
{
    public class Person
    {
        public string? Name { get; set; }
        public string? Initials { get; set; }
        public DateTime Date { get; set; }
        public StatusType Status { get; set; }
        public bool HasException => Status == StatusType.Exception;
        public bool IsNotClockedIn => Status == StatusType.NotClockedIn;
        public bool IsClockedIn => Status == StatusType.ClockedIn;
    }
}
