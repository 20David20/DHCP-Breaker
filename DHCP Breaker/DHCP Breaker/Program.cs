using System;
using System.Diagnostics;
using DHCP_Breaker.Properties;
using SharpPcap;

namespace DHCP_Breaker
{
    class Program
    {

        static int askAction()
        {
            string response;
            Console.WriteLine("\nVoulez-vous desactiver vos carte reseau? [O/N] ");
            response = Console.ReadLine();
            Console.WriteLine(response);
            if (response == "o" || response == "O")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static void RunCmd(string executeString)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(executeString);
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.Verb = "runas";
            processStartInfo.FileName = ("cmd.exe");

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            //process.WaitForExit();

            //if (process.ExitCode == -1) throw new Exception(process.StandardOutput.ReadToEnd());
        }

        static void desactivateNetwork()
        {
            RunCmd("wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable");
            //system("wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable");
            //Process.Start("cmd", "/K wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable"); // Start a new command prompt, execute command, but leave it open at the end.

            /*System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //*startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "echo hellooooooo";
            startInfo.Verb = "runas";
            startInfo.FileName = "desactivateNet";
            process.StartInfo = startInfo;
            Process.Start();
            
            Process p = new Process();*/



            /*System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();*/


            string strCmdText;
            strCmdText = "wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable";
            Process.Start("CMD.exe", strCmdText);

        }


        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            int action;

            action = askAction();
            switch (action)
            {
                case 1:
                    desactivateNetwork();
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }

            */

            Pcap pcap = new Pcap();
            CaptureDeviceList capture = new CaptureDeviceList();
            string test = Pcap.Version;

            Console.WriteLine(test);
        }
    }
}
