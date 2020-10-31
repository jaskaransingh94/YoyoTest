using System;
using System.Collections.Generic;
using System.Text;

namespace YoyoTest.Domain.Models
{
    public class PlayerApplicationModel
    {
        public int PlayerId { get; set; }
        public int SpeedLevel { get; set; }
        public int ShuttleNo { get; set; }
        public string PlayerName { get; set; }
        public bool IsWarned { get; set; }
        public bool IsStopped { get; set; }
    }
}
