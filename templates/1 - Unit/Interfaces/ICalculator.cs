using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTemplates.Unit.Interfaces
{
    public interface ICalculator
    {
        (string operation, double result) Calcular(string operation, double a, double b);

    }
}
