using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCalculator.Models.Entity
{
    public class DivisionResult
    {
        public int Quotient { get; set; }
        public int Remainder { get; set; }
    }

    public class DivisionRequest
    {
        public int Dividend { get; set; }
        public int Divisor { get; set; }
    }
}