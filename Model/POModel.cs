using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBLIslamiPOApi.Model
{
    public class POModel
    {
        public int id { get; set; }
        public string PONumber { get; set; }
        
        public string InFavorOf { get; set; }
        public string OnAccountOf { get; set; }
        public string Amount { get; set; }

        public string Date { get; set; }
        public string Month { get; set; }
        public string Rate { get; set; }

        public string Duration { get; set; }
        public string MatureDate { get; set; }
        public string MonthorYear { get; set; }
        
    }
}
