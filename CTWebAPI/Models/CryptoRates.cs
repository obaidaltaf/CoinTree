using System;
using System.Collections.Generic;

namespace CTWebAPI.Models
{
    public partial class CryptoRates
    {
        public int Id { get; set; }
        public string sell { get; set; }
        public string buy { get; set; }
        public decimal ask { get; set; }
        public decimal bid { get; set; }
        public decimal rate { get; set; }
        public string market { get; set; }
        public DateTimeOffset? timestamp { get; set; }
        public string rateType { get; set; }
        public string rateSteps { get; set; }
        public decimal changepercentage { get; set; }
        public decimal spotRate { get; set; }
    }
}
