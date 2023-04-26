using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MonitoringSuiteLibrary.Models;

namespace UnitTests
{
    public class ModelTests
    {
        [Fact]
        public void CreateFirstResponderTest()
        {
            new FirstResponder(123, "fname", "lname", 22, 'm', 19.3, 123, true, false, new Vitals(DateTime.Now, 123, 123, 123, 123, 123, (float)123.44), new Location(DateTime.Now, 12, 123, 13));
        }

        [Fact]
        public void CreateLocationTest()
        {
            new Location(DateTime.Now, (decimal)1.4123123, (decimal)2.4, (decimal)3.4);
        }

        [Fact]
        public void CreateVitalsTest()
        {
            new Vitals(DateTime.Now, 123, 123, 123, 123, 123, (float)123.1);
        }
    }
}
