using Binance.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomoroApi.Models
{
    public class eQuestionModel
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string groupType { get; set; }
        public int Code { get; set; }

    }
}
