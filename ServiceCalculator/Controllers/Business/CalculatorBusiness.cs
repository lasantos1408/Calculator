using ServiceCalculator.Models.DataAccess;
using ServiceCalculator.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCalculator.Controllers.Business
{
    public class CalculatorBusiness
    {
        public static AdditionResult Add(AdditionRequest additionRequest, string trackingID)
        {
            return CalculatorDataAccess.Add(additionRequest, trackingID);
        }

        public static SubtractionResult Sub(SubtractionRequest subtractionRequest, string tracking_ID)
        {
            return CalculatorDataAccess.Sub(subtractionRequest, tracking_ID);
        }

        public static MultiplicationResult Mult(MultiplicationRequest multiplicationRequest, string tracking_ID)
        {
            return CalculatorDataAccess.Mult(multiplicationRequest, tracking_ID);
        }

        public static DivisionResult Div(DivisionRequest divisionRequest, string tracking_ID)
        {
            return CalculatorDataAccess.Div(divisionRequest, tracking_ID);
        }

        public static SqrtResult Sqrt(SqrtRequest sqrtRequest, string tracking_ID)
        {
            return CalculatorDataAccess.Sqrt(sqrtRequest, tracking_ID);
        }

        public static List<Operations> Query(string id)
        {
            return CalculatorDataAccess.Query(id);
        }
    }
}