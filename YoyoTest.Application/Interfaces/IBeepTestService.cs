using System;
using System.Collections.Generic;
using System.Text;
using YoyoTest.Application.ViewModels;

namespace YoyoTest.Application.Interfaces
{
    public interface IBeepTestService
    {
        BeepTestViewModel GetBeepTestRatings();
    }
}
