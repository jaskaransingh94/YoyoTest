using System;
using System.Collections.Generic;
using System.Text;
using YoyoTest.Domain.Models;

namespace YoyoTest.Application.ViewModels
{
    public class BeepTestApplicationModel
    {
        public decimal AccumulatedShuttleDistance { get; set; }
        public int SpeedLevel { get; set; }
        public int ShuttleNo { get; set; }
        public decimal Speed { get; set; }
        public int LevelTime { get; set; }
        public string CommulativeTime { get; set; }
        public string StartTime { get; set; }
    }
}
