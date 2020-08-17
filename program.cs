using Microsoft.VisualBasic;
using System;
using System.Security.Cryptography.X509Certificates;

namespace calculator
{
    class Program
    {

        static void Main(string[] args)
            *hello 

        {


            do
            {
               
                try
                {
                    
                    // Lese ein und erstelle die Operation
                    Console.WriteLine("Bitte Rechenoperation eingeben: ");

                    string myInputString = Console.ReadLine();
                    Operation myOperation = new Operation(myInputString);

                    // Validiere und ermittle den Operator und die Operanten
                    myOperation.DetermineOperator();
                    myOperation.DetermineOperants();

                    // Berechne das Ergebnis
                    decimal result = myOperation.CalculateResult();
                    Console.WriteLine("Ergebnis: " + result);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Bei der Verarbeitung ist ein Fehler aufgetreten. Details: " + e.Message);
                }
//
            } while (Console.ReadLine() != "exit");
        }
    }
}
