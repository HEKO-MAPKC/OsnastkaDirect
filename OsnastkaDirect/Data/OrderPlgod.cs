using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsnastkaDirect.Data
{
    internal class OrderPlgod
    {
        public decimal order { get; set; }
        public decimal number { get; set; }
        public decimal? draft { get; set; }
        public string draftName { get; set; }
    }
}
