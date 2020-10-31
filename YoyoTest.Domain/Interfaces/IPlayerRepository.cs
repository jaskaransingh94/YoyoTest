using System;
using System.Collections.Generic;
using System.Text;
using YoyoTest.Domain.Models;

namespace YoyoTest.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<PlayerModel> GetPlayers();
    }
}
