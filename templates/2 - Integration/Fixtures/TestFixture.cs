using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace TestTemplates.Examples._2___Integration.Fixtures
{
    public class TestFixture : IDisposable
    {
        public TestFixture()
        {  
            // ... initialize test data...
        }

        public void Dispose()
        {
            // ... clean up test data...
        }

    }
}
