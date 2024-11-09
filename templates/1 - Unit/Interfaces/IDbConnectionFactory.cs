using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTemplates._1___Unit.Interfaces
{
    interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();

    }
}
