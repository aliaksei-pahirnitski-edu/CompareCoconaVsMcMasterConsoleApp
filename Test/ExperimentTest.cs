using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class ExperimentTest
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, 2 + 2);
        }
    }
}