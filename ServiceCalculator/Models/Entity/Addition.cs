using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCalculator.Models.Entity
{
    public class AdditionResult
    {
        public int Sum { get; set; }
    }

    public class AdditionRequest
    {
        public int[] Addends { get; set; }
    }
}