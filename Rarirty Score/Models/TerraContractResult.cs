using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rarirty_Score.Models
{
    public class TerraContractResult
    {
        public string height { get; set; }
        public Result? result { get; set; }
    }

    public class Result
    {
        public string owner { get; set; }
        public string token_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public object uri { get; set; }
        public string metadata { get; set; }
        public string creator { get; set; }
        public object royalty_percent_fee { get; set; }
    }
}
