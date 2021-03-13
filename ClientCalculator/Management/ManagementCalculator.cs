using RestSharp;
using ServiceCalculator.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ClientCalculator.Management
{
    public class ManagementCalculator
    {
        public static string urlWebAPI = ConfigurationManager.AppSettings["urlWebAPI"].ToString();

        /// <summary>
        /// Method that connects to the Web API service to perform the addition operation.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="logAdd"></param>
        public static void Addition(AdditionRequest values, string logAdd)
        {
            try
            {
                var clientRest = new RestClient(urlWebAPI);
                var requestRest = new RestRequest("Add", Method.POST);

                if (logAdd == "")
                {
                    logAdd = "0";
                }

                requestRest.AddHeader("x-evi-tracking-id", logAdd);

                requestRest.AddParameter("application/json", new JavaScriptSerializer().Serialize(values), ParameterType.RequestBody);
                IRestResponse responseRest = clientRest.Execute(requestRest);
                Console.WriteLine();

                if (responseRest.StatusCode == HttpStatusCode.OK)
                {
                    AdditionResult resultAdd = (new JavaScriptSerializer()).Deserialize<AdditionResult>(responseRest.Content);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nRESULTADO, SUMATORIA: " + resultAdd.Sum + ". " + (logAdd != "" ? " La operacion fue registrada en el log." : ""));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al realizar la operación: " + responseRest.ErrorMessage);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Operación finalizada.");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nError al conectarse con el servicio que realiza la operacion de suma. ");
                throw;
            }
        }

        /// <summary>
        /// Method that connects to the Web API service to perform the substraction operation.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="logSub"></param>
        public static void Substraction(SubtractionRequest values, string logSub)
        {
            try
            {
                var clientRest = new RestClient(urlWebAPI);
                var requestRest = new RestRequest("Sub", Method.POST);

                if (logSub == "")
                {
                    logSub = "0";
                }
                requestRest.AddHeader("x-evi-tracking-id", logSub);
                                
                requestRest.AddParameter("application/json", new JavaScriptSerializer().Serialize(values), ParameterType.RequestBody);
                IRestResponse responseRest = clientRest.Execute(requestRest);
                Console.WriteLine();

                if (responseRest.StatusCode == HttpStatusCode.OK)
                {
                    SubtractionResult resultSubs = (new JavaScriptSerializer()).Deserialize<SubtractionResult>(responseRest.Content);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nRESULTADO, DIFERENCIA: " + resultSubs.Difference + ". " + (logSub != "" ? " La operacion fue registrada en el log. " : ""));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al realizar la operación: " + responseRest.ErrorMessage);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Operación finalizada.");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nError al conectarse con el servicio que realiza la operacion de resta. ");
                throw;
            }
        }

        /// <summary>
        /// Method that connects to the Web API service to perform the multiplication operation.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="logMultiplication"></param>
        public static void Multiplication(MultiplicationRequest values, string logMultiplication)
        {
            try
            {
                var clientRest = new RestClient(urlWebAPI);
                var requestRest = new RestRequest("Mult", Method.POST);

                if (logMultiplication == "")
                {
                    logMultiplication = "0";
                }
                requestRest.AddHeader("x-evi-tracking-id", logMultiplication);

                requestRest.AddParameter("application/json", new JavaScriptSerializer().Serialize(values), ParameterType.RequestBody);
                IRestResponse responseRest = clientRest.Execute(requestRest);
                Console.WriteLine();
                if (responseRest.StatusCode == HttpStatusCode.OK)
                {
                    MultiplicationResult resultRest = (new JavaScriptSerializer()).Deserialize<MultiplicationResult>(responseRest.Content);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nRESULTADO, MULTIPLICACION: " + resultRest.Product + ". " + (logMultiplication != "" ? " La operacion fue registrada en el log." : ""));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al realizar la operación: " + responseRest.ErrorMessage);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Operación finalizada.");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nError al conectarse con el servicio que realiza la operacion de multiplicación. ");
                throw;
            }
        }

        /// <summary>
        /// Method that connects to the Web API service to perform the division operation.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="logDiv"></param>
        internal static void Division(DivisionRequest values, string logDiv)
        {
            try
            {
                var clientRest = new RestClient(urlWebAPI);
                var requestRest = new RestRequest("Div", Method.POST);

                if (logDiv == "")
                {
                    logDiv = "0";
                }
                requestRest.AddHeader("x-evi-tracking-id", logDiv);

                requestRest.AddParameter("application/json", new JavaScriptSerializer().Serialize(values), ParameterType.RequestBody);
                IRestResponse responseRest = clientRest.Execute(requestRest);
                Console.WriteLine();

                if (responseRest.StatusCode == HttpStatusCode.OK)
                {
                    DivisionResult result = (new JavaScriptSerializer()).Deserialize<DivisionResult>(responseRest.Content);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nRESULTADO, COCIENTE: " + result.Quotient + " - RESTO: " + result.Remainder + "." + (logDiv != "" ? " La operacion fue registrada en el log." : ""));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al realizar la operación: " + responseRest.ErrorMessage);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Operación finalizada.");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nError al conectarse con el servicio que realiza la operacion de división. ");
                throw;
            }
        }

        /// <summary>
        /// Method that connects to the Web API service to perform the Sqrt operation.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="logDiv"></param>
        internal static void Sqrt(SqrtRequest sqrtRequest, string logSqrt)
        {
            try
            {
                var clientRest = new RestClient(urlWebAPI);
                var requestRest = new RestRequest("Sqrt", Method.POST);

                if (logSqrt == "")
                {
                    logSqrt = "0";
                }
                requestRest.AddHeader("x-evi-tracking-id", logSqrt);

                requestRest.AddParameter("application/json", new JavaScriptSerializer().Serialize(sqrtRequest), ParameterType.RequestBody);
                IRestResponse responseRest = clientRest.Execute(requestRest);
                Console.WriteLine();

                if (responseRest.StatusCode == HttpStatusCode.OK)
                {
                    SqrtResult resultJava = (new JavaScriptSerializer()).Deserialize<SqrtResult>(responseRest.Content);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nRESULTADO, CUADRADO: " + resultJava.Square + ". " + (logSqrt != "" ? " La operacion fue registrada en el log." : ""));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al realizar la operación: " + responseRest.ErrorMessage);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Operación finalizada.");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nError al conectarse con el servicio que realiza la operacion de raíz cuadrada. ");
                throw;
            }
        }

        /// <summary>
        /// Method that connects to the Web API service to perform the Query operation.
        /// </summary>
        /// <param name="id"></param>
        public static void Query(int id)
        {
            try
            {
                var clientRest = new RestClient(urlWebAPI);
                var requestRest = new RestRequest("Query", Method.POST);
                requestRest.AddParameter("application/json", id, ParameterType.RequestBody);
                IRestResponse responseRest = clientRest.Execute(requestRest);
                Console.WriteLine();

                if (responseRest.StatusCode == HttpStatusCode.OK)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    List<Operations> resultJava = (new JavaScriptSerializer()).Deserialize<List<Operations>>(responseRest.Content);
                    if (resultJava.Count > 0)
                    {
                        foreach (var item in resultJava)
                        {
                            Console.WriteLine("Id:" + item.Id + "- Operación: " + item.Operation + "- Calculo: " + item.Calculation + " Fecha: " + item.Date);
                        }
                    }
                    else if (resultJava.Count == 0)
                    {
                        Console.WriteLine("No existen Logs guardados asociados al identificador ingresado");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al realizar la operación: " + responseRest.ErrorMessage);
                }


                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Operación finalizada.");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nError al serializar la información que se guarda en el log. ");
                throw;
            }
        }
    }
}
