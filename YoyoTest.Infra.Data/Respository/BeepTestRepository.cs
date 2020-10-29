using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using YoyoTest.Domain.Interfaces;
using YoyoTest.Domain.Models;

namespace YoyoTest.Infra.Data.Respository
{
    public class BeepTestRepository : IBeepTestRepository
    {
        public IEnumerable<BeepTestModel> GetBeepTestRatings()
        {
            string data = BeepTestData.jsonData;
            IEnumerable<BeepTestModel> beepTestCollection = JsonConvert.DeserializeObject<IEnumerable<BeepTestModel>>(data);

            return beepTestCollection;
        }
    }
}
