using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCalculator.Models.Entity
{
    public class MultiplicationResult
    {
        public int Product { get; set; }
    }

    public class MultiplicationRequest
    {
        public int[] Factors { get; set; }
    }
}