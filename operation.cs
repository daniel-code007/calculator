using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace calculator
{
    public class Operation
    {
        private readonly string _operation;
        private char _operator;
        private List<decimal> _numbersToCalculate = new List<decimal>();

        public Operation(string operation)
        {
            if (string.IsNullOrEmpty(operation))
            {
                throw new Exception("Operation ist null oder leer.");
            }

            _operation = operation;
        }

        public void DetermineOperator()
        {
            int counterOfOperators = 0;

            if (_operation.Contains("+"))
            {
                counterOfOperators++;
                _operator = '+';
            }

            if (_operation.Contains("-"))
            {
                counterOfOperators++;
                _operator = '-';
            }

            if (_operation.Contains("*"))
            {
                counterOfOperators++;
                _operator = '*';
            }

            if (_operation.Contains("/"))
            {
                counterOfOperators++;
                _operator = '/';
            }

            if (counterOfOperators > 1)
            {
                throw new Exception("Es wurde mehr als ein Operator gefunden.");
            }

            if (counterOfOperators == 0)
            {
                throw new Exception("Es wurde kein valider Operator gefunden.");
            }
        }

        public void DetermineOperants()
        {
            if (_operator == 0)
            {
                throw new Exception("Bitte zuerst den Operator ermitteln.");
            }

            string[] _operants = _operation.Split(_operator);

            foreach (string number in _operants)
            {
                try
                {
                    decimal operant = Convert.ToDecimal(number);
                    _numbersToCalculate.Add(operant);
                }
                catch (Exception e)
                {
                    throw new Exception("Der Operant ist ungültig: " + number);
                }
            }
        }

        public decimal CalculateResult()
        {
            decimal result = _numbersToCalculate[0];

            switch (_operator)
            {
                case '+':

                    return _numbersToCalculate.Sum();

                case '-':

                    for (int i = 1; i < _numbersToCalculate.Count; i++)
                    {
                        result -= _numbersToCalculate[i];
                    }

                    return result;

                case '*':

                    for (int i = 1; i < _numbersToCalculate.Count; i++)
                    {
                        result *= _numbersToCalculate[i];
                    }

                    return result;

                case '/':

                    for (int i = 1; i < _numbersToCalculate.Count; i++)
                    {
                        result /= _numbersToCalculate[i];
                    }

                    return result;

                default:
                    throw new Exception("Der Operator ist unbekannt: " + _operator);
            }
        }
    }
}
