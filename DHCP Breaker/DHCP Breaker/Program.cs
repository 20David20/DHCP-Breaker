using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using SharpPcap;
using SharpPcap.LibPcap;

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
            //RunCmd("wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable");
            //system("wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable");
            Process.Start("cmd", "/K wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable"); // Start a new command prompt, execute command, but leave it open at the end.

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


            /*string strCmdText;
            strCmdText = "wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable";
            Process.Start("CMD.exe", strCmdText);*/

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

            /*Pcap pcap = new Pcap();
            //CaptureDeviceList capture = new CaptureDeviceList();
            string test = Pcap.Version;

            Console.WriteLine(test);*/





            //=======================================================================================================


            // Print SharpPcap version
            string ver = SharpPcap.Version.VersionString;
            Console.WriteLine("SharpPcap {0}, Example12.PacketManipulation.cs", ver);
            Console.WriteLine();

            // Retrieve the device list
            var devices = CaptureDeviceList.Instance;

            // If no devices were found print an error
            if (devices.Count < 1)
            {
                Console.WriteLine("No devices were found on this machine");
                return;
            }

            Console.WriteLine("The following devices are available on this machine:");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

            int i = 0;

            // Print out the available devices
            foreach (var dev in devices)
            {
                Console.WriteLine("{0}) {1}", i, dev.Description);
                i++;
            }
            Console.WriteLine("{0}) {1}", i, "Read packets from offline pcap file");

            Console.WriteLine();
            Console.Write("-- Please choose a device to capture: ");
            var choice = int.Parse(Console.ReadLine());

            ICaptureDevice device = null;
            if (choice == i)
            {
                Console.Write("-- Please enter an input capture file name: ");
                string capFile = Console.ReadLine();
                device = new CaptureFileReaderDevice(capFile);
            }
            else
            {
                device = devices[choice];
            }

            //Register our handler function to the 'packet arrival' event
            device.OnPacketArrival +=
                new PacketArrivalEventHandler(device_OnPacketArrival);

            // Open the device for capturing
            device.Open();

            Console.WriteLine();
            Console.WriteLine
                ("-- Listening on {0}, hit 'Ctrl-C' to exit...",
                device.Description);

            // Start capture 'INFINTE' number of packets
            device.Capture();

            // Close the pcap device
            // (Note: this line will never be called since
            //  we're capturing infinite number of packets
            device.Close();
        }

        private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            if (packet is PacketDotNet.EthernetPacket)
            {
                var eth = ((PacketDotNet.EthernetPacket)packet);
                Console.WriteLine("Original Eth packet: " + eth.ToString());

                //Manipulate ethernet parameters
                eth.SourceHardwareAddress = PhysicalAddress.Parse("00-11-22-33-44-55");
                eth.DestinationHardwareAddress = PhysicalAddress.Parse("00-99-88-77-66-55");

                var ip = packet.Extract<PacketDotNet.IPPacket>();
                if (ip != null)
                {
                    Console.WriteLine("Original IP packet: " + ip.ToString());

                    //manipulate IP parameters
                    ip.SourceAddress = System.Net.IPAddress.Parse("1.2.3.4");
                    ip.DestinationAddress = System.Net.IPAddress.Parse("44.33.22.11");
                    ip.TimeToLive = 11;

                    var tcp = packet.Extract<PacketDotNet.TcpPacket>();
                    if (tcp != null)
                    {
                        Console.WriteLine("Original TCP packet: " + tcp.ToString());

                        //manipulate TCP parameters
                        tcp.SourcePort = 9999;
                        tcp.DestinationPort = 8888;
                        tcp.Synchronize = !tcp.Synchronize;
                        tcp.Finished = !tcp.Finished;
                        tcp.Acknowledgment = !tcp.Acknowledgment;
                        tcp.WindowSize = 500;
                        tcp.AcknowledgmentNumber = 800;
                        tcp.SequenceNumber = 800;
                    }

                    var udp = packet.Extract<PacketDotNet.UdpPacket>();
                    if (udp != null)
                    {
                        Console.WriteLine("Original UDP packet: " + udp.ToString());

                        //manipulate UDP parameters
                        udp.SourcePort = 9999;
                        udp.DestinationPort = 8888;
                    }
                }

                Console.WriteLine("Manipulated Eth packet: " + eth.ToString());
                
                
                //DETECTION PACKET DHCP
                if (eth.ToString().Contains("DHCP"))
                {
                    desactivateNetwork();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("HAHAHAAHAAHAHAHAHAHAHHAHHHAHAHAHAHAHAHAH");
                    Console.WriteLine();
                    Console.WriteLine();

                    Environment.Exit(0);
                }
            }
        }
    }
}
