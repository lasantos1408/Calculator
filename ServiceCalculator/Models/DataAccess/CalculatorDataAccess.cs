using ServiceCalculator.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ServiceCalculator.Models.DataAccess
{
    public class CalculatorDataAccess
    {
        /// <summary>
        /// Implementation of addition method.
        /// </summary>
        /// <param name="additionRequest"></param>
        /// <param name="logAdd"></param>
        /// <returns></returns>
        public static AdditionResult Add(AdditionRequest additionRequest, string logAdd)
        {
            try
            {
                AdditionResult additionResult = new AdditionResult();
                int counter = 0;
                string calculation = "";

                foreach (int number in additionRequest.Addends)
                {
                    counter += 1;
                    additionResult.Sum += number;
                    calculation += number.ToString() + (counter == additionRequest.Addends.Length ? "" : "+");
                }

                if (int.Parse(logAdd) != 0)
                {
                    SaveLog(int.Parse(logAdd), "Suma ", calculation, additionResult.Sum);
                }


                return additionResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Implementation of subtraction method.
        /// </summary>
        /// <param name="subtractionRequest"></param>
        /// <param name="logSub"></param>
        /// <returns></returns>
        public static SubtractionResult Sub(SubtractionRequest subtractionRequest, string logSub)
        {
            try
            {
                SubtractionResult subtractionResult = new SubtractionResult();
           
                subtractionResult.Difference = subtractionRequest.Minuend - subtractionRequest.Subtrahend;
                string calculation = subtractionRequest.Minuend.ToString() + "-" + subtractionRequest.Subtrahend.ToString();

                if (int.Parse(logSub) != 0)
                {
                    SaveLog(int.Parse(logSub), "Resta ", calculation, subtractionResult.Difference);
                }
            
                return subtractionResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Implementation of Sqrt method.
        /// </summary>
        /// <param name="sqrtRequest"></param>
        /// <param name="logSqrt"></param>
        /// <returns></returns>
        public static SqrtResult Sqrt(SqrtRequest sqrtRequest, string logSqrt)
        {
            try
            {
                SqrtResult sqrtResult = new SqrtResult();
            
                double numberDou = Convert.ToDouble(sqrtRequest.Number);
                sqrtResult.Square = Math.Sqrt(numberDou);
                string calculation = "√" + numberDou.ToString();

                if (int.Parse(logSqrt) != 0)
                {
                    SaveLog(int.Parse(logSqrt), "Sqrt ", calculation, int.Parse(sqrtResult.Square.ToString()));
                }
           
                return sqrtResult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Implementation of multiplication method.
        /// </summary>
        /// <param name="multiplicationRequest"></param>
        /// <param name="logMult"></param>
        /// <returns></returns>
        public static MultiplicationResult Mult(MultiplicationRequest multiplicationRequest, string logMult)
        {
            try
            {
                MultiplicationResult multiplicationResult = new MultiplicationResult();
           
                int counter = 0;
                string calculation = "";
                multiplicationResult.Product = 1;

                foreach (int number in multiplicationRequest.Factors)
                {
                    counter += 1;
                    multiplicationResult.Product *= number;
                    calculation += number.ToString() + (counter == multiplicationRequest.Factors.Length ? "" : "*");
                }

                if (int.Parse(logMult) != 0)
                {
                    SaveLog(int.Parse(logMult), "Multiplicación ", calculation, multiplicationResult.Product);
                }

                return multiplicationResult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Implementation of division method.
        /// </summary>
        /// <param name="divisionRequest"></param>
        /// <param name="logDiv"></param>
        /// <returns></returns>
        public static DivisionResult Div(DivisionRequest divisionRequest, string logDiv)
        {
            try
            {
                DivisionResult divisionResult = new DivisionResult();
           
                divisionResult.Quotient = divisionRequest.Dividend / divisionRequest.Divisor;
                divisionResult.Remainder = divisionRequest.Dividend % divisionRequest.Divisor;
                string calculation = divisionRequest.Dividend + "%" + divisionRequest.Divisor.ToString();

                if (int.Parse(logDiv) != 0)
                {
                    SaveLog(int.Parse(logDiv), "División ", calculation, divisionResult.Quotient);
                }
            
                return divisionResult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Implementation of log method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Operations> Query(string id)
        {
            string content = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/jsondata.json"));
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Operations> listOperations = js.Deserialize<List<Operations>>(content);
            List<Operations> resultingOperations = listOperations.Where(x => x.Id == int.Parse(id)).ToList();
            
            return resultingOperations;
        }

        /// <summary>
        /// Implementation of save log.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static void SaveLog(int id, string typeOperation, string calculation, int resultCalculation)
        {
            try
            {
                string content = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/jsondata.json"));
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Operations> listOperations = js.Deserialize<List<Operations>>(content);
                listOperations.Add(new Operations()
                {
                    Id = id,
                    Operation = typeOperation,
                    Calculation = calculation + "=" + resultCalculation,
                    Date = DateTime.Now,
                });
                string json = js.Serialize(listOperations);
                System.IO.File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath("~/jsondata.json"), json);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}