﻿using System;
using System.Collections.Generic;
using System.Text;
using YoyoTest.Domain.Models;

namespace YoyoTest.Application.ViewModels
{
    public class BeepTestViewModel
    {
        public IEnumerable<BeepTestModel> BeepTestRatings { get; set; }
    }
}