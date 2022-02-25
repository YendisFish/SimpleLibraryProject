using System.Diagnostics;
using SimpleLibraryProject.Processing.Types;

namespace SimpleLibraryProject.Processing.Handlers
{
    public class ProcessHandler
    {
        public static async Task<ProcessOutput> Execute(ProcessInput Inf)
        {
            ProcessStartInfo procinf = new ProcessStartInfo()
            {
                FileName = Inf.Filename,
                Arguments = Inf.Args,
                RedirectStandardOutput = Inf.RedirectStdout,
                UseShellExecute = Inf.ShellExecute
            };

            Process? proc = Process.Start(procinf);

            CancellationTokenSource tsource = new();
            tsource.CancelAfter(Inf.timeout);

            await proc.WaitForExitAsync(tsource.Token);

            return new ProcessOutput(proc.StandardOutput.ReadToEnd(), Inf, Guid.NewGuid());
        }
    }    
}
