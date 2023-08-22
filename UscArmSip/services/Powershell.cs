using System.Diagnostics;

namespace UscArmSip
{
    public static class Powershell
    {
        public static string Run(string arguments, bool readOutput = false)
        {
            var process = Process.Start(new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = "powershell",
                Arguments = $"/command {arguments}"
            });

            if (readOutput)
            {
                var output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                return output;
            }

            return string.Empty;          
        }
    }
}