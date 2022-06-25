using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class HelpTests : BaseTest
    {
        [Fact]
        public async Task Plain_Help_Is_Printed_Test()
        {
            var exePath = GetExePath(PathForPlain);

            var outputFromHelpCommand = await ExecuteAndReadOutput(exePath, "help");

            Assert.NotEmpty(outputFromHelpCommand);
            Assert.Contains(CHelp, outputFromHelpCommand);
            Assert.Contains(CHallo, outputFromHelpCommand);
            Assert.Contains(CComment, outputFromHelpCommand);
        }

        [Fact]
        public async Task Plain_When_No_Args_Help_Is_Printed_Test()
        {
            var exePath = GetExePath(PathForPlain);

            var outputFromNoArgs = await ExecuteAndReadOutput(exePath, null);

            var outputFromHelpCommand = await ExecuteAndReadOutput(exePath, "help");

            Assert.NotEmpty(outputFromNoArgs);
            Assert.Equal(outputFromHelpCommand, outputFromNoArgs);
        }
    }
}
