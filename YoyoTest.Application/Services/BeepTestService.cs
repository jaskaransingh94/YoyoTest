using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using YoyoTest.Application.Interfaces;
using YoyoTest.Application.ViewModels;
using YoyoTest.Domain.Interfaces;
using YoyoTest.Domain.Models;

namespace YoyoTest.Application.Respository
{
    public class BeepTestService : IBeepTestService
    {
        private IBeepTestRepository _beepTestRepository;
        private IPlayerRepository _playerRepository;

        public BeepTestService(IBeepTestRepository beepTestRepository, IPlayerRepository playerRepository)
        {
            _beepTestRepository = beepTestRepository;
            _playerRepository = playerRepository;
        }

        BeepTestViewModel IBeepTestService.GetBeepTestRatings()
        {
            //test data
            IEnumerable<BeepTestApplicationModel> formattedTestData = _beepTestRepository.GetBeepTestRatings().Select(data => new BeepTestApplicationModel
            {
                AccumulatedShuttleDistance = decimal.Parse(data.AccumulatedShuttleDistance),
                Speed = decimal.Parse(data.Speed),
                SpeedLevel = int.Parse(data.SpeedLevel),
                ShuttleNo = int.Parse(data.ShuttleNo),
                CommulativeTime = data.CommulativeTime,
                StartTime = data.StartTime,
                LevelTime = int.Parse(Math.Round(decimal.Parse(data.LevelTime)).ToString())
            });

            //sort data by speed level and shuttle
            IEnumerable<BeepTestApplicationModel> sortedTestData = formattedTestData.OrderBy(item => item.SpeedLevel).ThenBy(item => item.ShuttleNo);
            string data = JsonConvert.SerializeObject(sortedTestData);

            //player data
            IEnumerable<PlayerApplicationModel> formattedPlayerData = _playerRepository.GetPlayers().Select(data => new PlayerApplicationModel
            {
                PlayerId = int.Parse(data.PlayerId),
                SpeedLevel = int.Parse(data.SpeedLevel),
                ShuttleNo = int.Parse(data.ShuttleNo),
                IsWarned = bool.Parse(data.IsWarned),
                PlayerName = data.PlayerName,
                IsStopped = bool.Parse(data.IsStopped),
            });

            IEnumerable<PlayerApplicationModel> sotedPlayerData = formattedPlayerData.OrderBy(item => item.PlayerId);

            return new BeepTestViewModel()
            {
                BeepTestRatings = sortedTestData,
                Players = sotedPlayerData
            };
        }
    }
}
