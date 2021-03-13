using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCalculator.Models.Entity
{
    public class SqrtResult
    {
        public double Square { get; set; }
    }

    public class SqrtRequest
    {
        public int Number { get; set; }
    }
}