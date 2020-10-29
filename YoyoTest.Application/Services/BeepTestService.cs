using System;
using System.Collections.Generic;
using System.Text;
using YoyoTest.Application.Interfaces;
using YoyoTest.Application.ViewModels;
using YoyoTest.Domain.Interfaces;

namespace YoyoTest.Application.Respository
{
    public class BeepTestService : IBeepTestService
    {
        private IBeepTestRepository _beepTestRepository;
        public BeepTestService(IBeepTestRepository beepTestRepository)
        {
            _beepTestRepository = beepTestRepository;
        }

        BeepTestViewModel IBeepTestService.GetBeepTestRatings()
        {
            return new BeepTestViewModel()
            {
                BeepTestRatings = _beepTestRepository.GetBeepTestRatings()
            };
        }
    }
}
