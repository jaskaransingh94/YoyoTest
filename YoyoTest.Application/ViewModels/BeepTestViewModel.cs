using System;
using System.Collections.Generic;
using System.Text;
using YoyoTest.Domain.Models;

namespace YoyoTest.Application.ViewModels
{
    public class BeepTestViewModel
    {
        public IEnumerable<BeepTestApplicationModel> BeepTestRatings { get; set; }
        public IEnumerable<PlayerApplicationModel> Players { get; set; }
    }
}
