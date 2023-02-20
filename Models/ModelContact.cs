using Binance.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomoroApi.Models
{
    public class eContactModel
    {
        public string Id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string description { get; set; }
        public int Code { get; set; }

    }
}
