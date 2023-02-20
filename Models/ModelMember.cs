using Binance.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomoroApi.Models
{
    public class eMemberModel
    {
        public string Id { get; set; }
        public string fullName { get; set; }
        public string image { get; set; }
        public string responsible { get; set; }
        public string body { get; set; }
        public string description { get; set; }
        public int Code { get; set; }

    }
}
