using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTemplates.Unit.Interfaces;

namespace TestTemplates.Unit.Classes
{
    class Calculator
    {
        public (string operation, double result) Calc(string operation, double a, double b)
        {
            (string operation, double result) OperationResult;
            double c;
            switch (operation)
            {
                case "sum":
                    c = a + b;
                    break;
                case "subtract":
                    c = a - b;
                    break;
                case "multiply":
                    c = a * b;
                    break;
                case "divide":
                    c = Math.Round(a / b, 2);
                    break;
                default:
                    c = a + b;
                    break;
            }
            OperationResult = (operation, c);
            return OperationResult;
        }
    }
}
