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
    public class BaseTest
    {
        protected const string PathForTest = @"Test\bin\Debug\net6.0\";
        protected const string PathForPlain = @"PlainImplConsoleApp\bin\Debug\net6.0\PlainImplConsoleApp.exe";

        // commands
        protected const string CHelp = "help";
        protected const string CHallo = "hallo";
        protected const string CComment = "comment";

        protected string GetRootPath()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            Assert.Contains(PathForTest, baseDir);
            return baseDir.Replace(PathForTest, "");
        }

        protected string GetExePath(string pathAfterRoot)
        {
            var rootPath = GetRootPath();
            var exePath = Path.Combine(rootPath, pathAfterRoot);
            return exePath;
        }

        protected async Task<string> ExecuteAndReadOutput(string exePath, string args)
        {
            var startInfo = new ProcessStartInfo(exePath, args);
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            var process = Process.Start(startInfo)!;
            await process.WaitForExitAsync();
            var outputFromProcess = process.StandardOutput.ReadToEnd();
            return outputFromProcess;
        }
    }
}
