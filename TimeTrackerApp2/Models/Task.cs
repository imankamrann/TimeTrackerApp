using System;
namespace TimeTrackerApp2.Models
{
    public class Task
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskDetails { get; set; }


        public Task()
        {
        }
    }
}

