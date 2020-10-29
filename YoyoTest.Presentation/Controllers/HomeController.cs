using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoyoTest.Application.Interfaces;
using YoyoTest.Application.ViewModels;
using YoyoTest.Presentation.Models;

namespace YoyoTest.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBeepTestService _beepTestService;
        public HomeController(IBeepTestService beepTestService)
        {
            _beepTestService = beepTestService;
        }

        public IActionResult Index()
        {
            BeepTestViewModel model = _beepTestService.GetBeepTestRatings();
            return View(model);
        }

    }
}
