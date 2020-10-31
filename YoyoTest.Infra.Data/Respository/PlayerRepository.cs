using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using YoyoTest.Domain.Interfaces;
using YoyoTest.Domain.Models;

namespace YoyoTest.Infra.Data.Respository
{
    public class PlayerRepository : IPlayerRepository
    {
        public IEnumerable<PlayerModel> GetPlayers()
        {
            string data = PlayerData.jsonData;
            IEnumerable<PlayerModel> playerCollection = JsonConvert.DeserializeObject<IEnumerable<PlayerModel>>(data);

            return playerCollection;
        }
    }
}
