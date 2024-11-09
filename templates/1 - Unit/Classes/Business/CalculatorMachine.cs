using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTemplates.Unit.Interfaces;

namespace TestTemplates.Unit.Classes
{
    class CalculatorMachine
    {
        private ICalculator calc;

        public CalculatorMachine(Calculator calculator)
        {
        }

        public CalculatorMachine() : this(new Calculator())
        { }
        public CalculatorMachine(ICalculator obj)
        {
            this.calc = obj;
        }

        public (string operation, double result) Calc(string operationType, double a, double b)
        {
            return calc.Calcular(operationType, a, b);
        }

    }
}
