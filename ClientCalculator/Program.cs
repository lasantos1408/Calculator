using ClientCalculator.Management;
using ServiceCalculator.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ClientCalculator
{
    class Program
    {
        /// <summary>
        /// Main method, initiates the application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                int insertedValue = 0;

                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    insertedValue = Menu();

                    switch (insertedValue)
                    {
                        case 1:
                            AdditionMethod();
                            break;
                        case 2:
                            SubtractionMethod();
                            break;
                        case 3:
                            MultiplicationMethod();
                            break;
                        case 4:
                            DivisionMethod();
                            break;
                        case 5:
                            SqrtMethod();
                            break;
                        case 6:
                            Log();
                            break;
                        default:
                            break;
                    }

                    Console.ForegroundColor = ConsoleColor.White;

                    if (insertedValue > 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nEl valor ingresado no es válido. \n");
                    }

                } while (insertedValue != 7);

                EndMessage();
            }
            catch (Exception)
            {
                Console.WriteLine("\n\nEl valor ingresado no es válido. ");
                throw;
            }

        }

        /// <summary>
        /// Log Method.
        /// </summary>
        static public void Log()
        {
            Console.WriteLine("\nConsultar Logs");
            int id = int.Parse(ValidarNumero("Ingrese el identificador del log a mostrar."));
            ManagementCalculator.Query(id);
        }

        /// <summary>
        /// Group the Sqrt operations.
        /// </summary>
        static public void SqrtMethod()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RAIZ CUADRADA");
            Console.ForegroundColor = ConsoleColor.White;
            int number = int.Parse(ValidarNumero("Ingrese el número:"));

            string logSqrt = ValidarNumeroEspacio("\nIngrese el identificador del Log OPCIONAL:");
            SqrtRequest sqrtRequest = new SqrtRequest();
            sqrtRequest.Number = number;
            ManagementCalculator.Sqrt(sqrtRequest, logSqrt);
        }

        /// <summary>
        /// Group the addition operations.
        /// </summary>
        static public void AdditionMethod()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSUMA ");
            Console.ForegroundColor = ConsoleColor.White;

            bool valor;
            string[] numbersAdd;
            do
            {
                valor = true;
                Console.WriteLine("Ingrese los números que intervienen en la sumatoria separados por espacio.");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Ejemplo 9 5 4 7 7.\n");
                Console.ForegroundColor = ConsoleColor.White;
                numbersAdd = Console.ReadLine().ToString().Trim().Split(' ');

                foreach (var item in numbersAdd)
                {
                    if (ValidarNumeroCadena(item.ToString()) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nLos números ingresados deben ser enteros y separados por espacio:\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        valor = false;
                        break;
                    }
                }
            } while (valor == false);

            string logAdd = ValidarNumeroEspacio("\nIngrese el identificador del Log OPCIONAL:");
            AdditionRequest addRequest = new AdditionRequest();

            addRequest.Addends = Array.ConvertAll(numbersAdd, s => int.Parse(s));
            ManagementCalculator.Addition(addRequest, logAdd);
        }

        /// <summary>
        /// Group the subtraction operations.
        /// </summary>
        static public void SubtractionMethod()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RESTA ");
            Console.ForegroundColor = ConsoleColor.White;

            int minuend = int.Parse(ValidarNumero("Ingrese el minuendo:"));
            int subtracting = int.Parse(ValidarNumero("Ingrese sustraendo:"));

            string logSub = ValidarNumeroEspacio("\nIngrese el identificador del Log OPCIONAL:");
            SubtractionRequest subRequest = new SubtractionRequest();
            subRequest.Minuend = minuend;
            subRequest.Subtrahend = subtracting;
            ManagementCalculator.Substraction(subRequest, logSub);
        }

        /// <summary>
        /// Group the multiplication operations.
        /// </summary>
        static public void MultiplicationMethod()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MULTIPLICACION ");
            Console.ForegroundColor = ConsoleColor.White;

            bool valor;
            string[] numbersAdd;
            do
            {
                valor = true;
                Console.WriteLine("Ingrese los números que intervienen en la multiplicación separados por espacio.");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Ejemplo 9 5 4 7 7\n");
                Console.ForegroundColor = ConsoleColor.White;
                numbersAdd = Console.ReadLine().ToString().Trim().Split(' ');

                foreach (var item in numbersAdd)
                {
                    if (ValidarNumeroCadena(item.ToString()) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nLos números ingresados deben ser enteros y separados por espacio:\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        valor = false;
                        break;
                    }
                }
            } while (valor == false);

            string logMult = ValidarNumeroEspacio("\nIngrese el identificador del Log OPCIONAL:");
            MultiplicationRequest MultRequest = new MultiplicationRequest();

            MultRequest.Factors = Array.ConvertAll(numbersAdd, s => int.Parse(s));
            ManagementCalculator.Multiplication(MultRequest, logMult);
        }

        /// <summary>
        /// Group the Division operations.
        /// </summary>
        static public void DivisionMethod()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("DIVISION");
            Console.ForegroundColor = ConsoleColor.White;

            int Dividendo = int.Parse(ValidarNumero("Ingrese el  dividendo:"));
            int Divisor = int.Parse(ValidarNumero("Ingrese divisor:"));

            string logDiv = ValidarNumeroEspacio("\nIngrese el identificador del Log OPCIONAL:");
            DivisionRequest divtRequest = new DivisionRequest();
            divtRequest.Dividend = Dividendo;
            divtRequest.Divisor = Divisor;
            ManagementCalculator.Division(divtRequest, logDiv);
        }

        /// <summary>
        /// Validate that a number is an integer.
        /// </summary>
        /// <param name="message"></param>
        static public string ValidarNumero(string message)
        {
            string valueInsert;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
                valueInsert = Console.ReadLine();
                if (!Regex.IsMatch(valueInsert, @"^\d+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nEl valor ingresado no es un número entero:");
                }
            }
            while (!Regex.IsMatch(valueInsert, @"^\d+$"));

            return valueInsert;
        }

        /// <summary>
        /// Validate that a number is an integer.
        /// </summary>
        /// <param name="message"></param>
        static public bool ValidarNumeroCadena(string valueInsert)
        {
            if (!Regex.IsMatch(valueInsert, @"^\d+$"))
            {
                return false;         
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validate that a number is an integer and space.
        /// </summary>
        /// <param name="message"></param>
        static public string ValidarNumeroEspacio(string message)
        {
            string valueInsert;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
                valueInsert = Console.ReadLine();
                if (valueInsert != "")
                {
                    if (!Regex.IsMatch(valueInsert, @"^\d+$"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nEl ID debe ser vacío o ingresar número entero:");
                    }
                }
            }
            while (!Regex.IsMatch(valueInsert, @"^\d+$") && valueInsert != "");

            return valueInsert;
        }


        /// <summary>
        /// Implement the application menu.
        /// </summary>
        static public int Menu()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("CALCULADORA\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Seleccione el número asociado a la operacion a realizar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1 SUMA ");
                Console.WriteLine("2 RESTA ");
                Console.WriteLine("3 MULTIPLICACION ");
                Console.WriteLine("4 DIVISION ");
                Console.WriteLine("5 RAIZ CUADRADA");
                Console.WriteLine("6 LOGS");
                Console.WriteLine("7 SALIR");
                Console.ForegroundColor = ConsoleColor.White;
                int insertedValue = int.Parse(ValidarNumero("\nPor favor seleccione una operación."));

                return insertedValue;

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nIngrese una opción del menú que sea válida. ");
                throw;
            }

        }

        /// <summary>
        /// Goodbye message.
        /// </summary>
        private static void EndMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n GRACIAS POR UTILIZAR LA CALCULADORA");
            Console.WriteLine("              HASTA LUEGO\n\n");
            Thread.Sleep(3000);
        }
    }
}
