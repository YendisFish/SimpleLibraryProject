using System.Diagnostics;

namespace SimpleLibraryProject.Processing.Types
{
    public record ProcessOutput(string Output, ProcessInput ProcessInput, Guid ProcessGuid);
    public record ProcessInput(string Filename, string Args, bool RedirectStdout = false, bool ShellExecute = false, int timeout = 10000);
}