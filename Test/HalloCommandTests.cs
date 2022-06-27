using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class HalloCommandTests : BaseTest
    {
        [Fact]
        public async Task Plain_Hallo_Is_Printed_Test()
        {
            var exePath = GetExePath(PathForPlain);

            var outputFromCommand = await ExecuteAndReadOutput(exePath, "hallo -n Alex");

            Assert.NotEmpty(outputFromCommand);
            Assert.Contains("Alex", outputFromCommand);
        }

        [Fact]
        public async Task CoconaLight_Hallo_Is_Printed_Test()
        {
            var exePath = GetExePath(PathForCoconaLight);

            var outputFromCommand = await ExecuteAndReadOutput(exePath, "hallo -n Alex");

            Assert.NotEmpty(outputFromCommand);
            Assert.Contains("Alex", outputFromCommand);
        }
    }
}
