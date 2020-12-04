using System;
using System.IO;
using System.Diagnostics;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Threading;

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
                

                var ip = packet.Extract<PacketDotNet.IPPacket>();
                if (ip != null)
                {
                    Console.WriteLine("Original IP packet: " + ip.ToString());

                    //manipulate IP parameters
                    /*ip.SourceAddress = System.Net.IPAddress.Parse("1.2.3.4");
                    ip.DestinationAddress = System.Net.IPAddress.Parse("44.33.22.11");
                    ip.TimeToLive = 11;*/

                    

                    var udp = packet.Extract<PacketDotNet.UdpPacket>();
                    if (udp != null)
                    {
                        Console.WriteLine("Original UDP packet: " + udp.ToString());

                        //manipulate UDP parameters

                        //DETECTION PACKET DHCP
                        if (udp.ToString().Contains("DHCPMsgType: DHCP Message Type: Ack"))
                        {
                            
                            if(udp.ToString().Contains("DHCPServerId: Server Id: 10.229.60.22"))
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("C'EST OK C'EST OK C'EST OK C'EST OK C'EST OK");
                                Console.WriteLine();
                                Console.WriteLine();


                                //Soundplayer player = new SoundPlayer();
                                // getting root path
                                string rootLocation = typeof(Program).Assembly.Location;
                                // appending sound location
                                string fullPathToSound = Path.Combine(rootLocation, @"Data\Sounds\car.wav");
                                //player.SoundLocation = fullPathToSound;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("HAHAHAAHAAHAHAHAHAHAHHAHHHAHAHAHAHAHAHAH");
                                Console.WriteLine();
                                Console.WriteLine();
                                desactivateNetwork();
                            }

                            
                            
                            Thread.Sleep(4000);

                            Console.WriteLine(udp.ToString());
                            
                            Environment.Exit(0);
                        }
                    }
                }

            }
        }
    }
}
