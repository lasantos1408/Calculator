using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCalculator.Models.Entity
{
    public class Operations
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string Calculation { get; set; }
        public DateTime Date { get; set; }
    }
}