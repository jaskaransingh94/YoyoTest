using System;
using System.Collections.Generic;
using System.Text;

namespace YoyoTest.Domain.Models
{
    public class PlayerModel
    {
        public string PlayerId { get; set; }
        public string SpeedLevel { get; set; }
        public string ShuttleNo { get; set; }
        public string PlayerName { get; set; }
        public string IsWarned { get; set; }
        public string IsStopped { get; set; }
    }
}
