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
            IEnumerable<BeepTestApplicationModel> formattedData = _beepTestRepository.GetBeepTestRatings().Select(data => new BeepTestApplicationModel
            {
                AccumulatedShuttleDistance = decimal.Parse(data.AccumulatedShuttleDistance),
                Speed = decimal.Parse(data.Speed),
                SpeedLevel = int.Parse(data.SpeedLevel),
                ShuttleNo = int.Parse(data.ShuttleNo),
                CommulativeTime = FormatTime(data.CommulativeTime),
                StartTime = FormatTime(data.StartTime),
                LevelTime = FormatTime(data.LevelTime, true)
            });

            //sort data by speed level and shuttle
            IEnumerable<BeepTestApplicationModel> sotedData = formattedData.OrderBy(item => item.SpeedLevel).ThenBy(item => item.ShuttleNo);
            //string data = JsonConvert.SerializeObject(sotedData);

            return new BeepTestViewModel()
            {
                BeepTestRatings = sotedData
            };
        }

        // format to datetime for comparison on client side
        private DateTime FormatTime(string time, bool onlySeconds = false)
        {
            if (onlySeconds) // format using seconds
            {
                string[] secData = time.Split('.');
                return new DateTime(1, 1, 1, 0, 0, int.Parse(secData[0]));
            }
            // format using minutes and seconds
            string[] minSecData = time.Split(':');
            return new DateTime(1, 1, 1, 0, int.Parse(minSecData[0]), int.Parse(minSecData[1]));
        }
    }
}
