using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            var sortData = _beepTestRepository.GetBeepTestRatings().OrderBy(level => level.SpeedLevel).ThenBy(shuttle => shuttle.ShuttleNo).Select(data => new BeepTestApplicationModel
            {
                AccumulatedShuttleDistance = decimal.Parse(data.AccumulatedShuttleDistance),
                Speed = decimal.Parse(data.Speed),
                SpeedLevel = int.Parse(data.SpeedLevel),
                ShuttleNo = int.Parse(data.ShuttleNo),
                CommulativeTime = FormatTime(data.CommulativeTime),
                StartTime = FormatTime(data.StartTime),
                LevelTime = FormatTime(data.LevelTime, true)
                //CommulativeTime = TimeSpan.ParseExact(data.CommulativeTime, minSecFormat, CultureInfo.InvariantCulture),
            });

            string data = JsonConvert.SerializeObject(sortData);

            return new BeepTestViewModel()
            {
                BeepTestRatings = sortData
            };
        }

        private TimeSpan FormatTime(string time, bool onlySeconds = false)
        {
            if (onlySeconds)
            {
                string[] secData = time.Split('.');
                if (secData.Length > 1)
                    return new TimeSpan(0, 0, 0, int.Parse(secData[0]), int.Parse(secData[1]));
                return new TimeSpan(0, 0, 0, int.Parse(secData[0]));
            }
            string[] minSecData = time.Split(':');
            return new TimeSpan(0, 0, int.Parse(minSecData[0]), int.Parse(minSecData[1]));
        }
    }
}
