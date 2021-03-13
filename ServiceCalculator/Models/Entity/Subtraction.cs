using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCalculator.Models.Entity
{
    public class SubtractionResult
    {
        public int Difference { get; set; }
    }

    public class SubtractionRequest
    {
        public int Minuend { get; set; }
        public int Subtrahend { get; set; }
    }
}