using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Threading;

namespace DHCP_Breaker_app
{
    public partial class frmDHCPBreaker : Form
    {

        private ICaptureDevice device = null;
        private int choice = 0;

        public frmDHCPBreaker()
        {
            InitializeComponent();
            InitializeSoft();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeSoft()
        {

            lstServeurDHCP.Items.Add("10.229.60.22");
            // Print SharpPcap version
            
            
            string ver = SharpPcap.Version.VersionString;
            //Console.WriteLine("SharpPcap {0}, Example12.PacketManipulation.cs", ver);
            //Console.WriteLine();

            // Retrieve the device list
            var devices = CaptureDeviceList.Instance;

            // If no devices were found print an error
            if (devices.Count < 1)
            {
                //Console.WriteLine("No devices were found on this machine");
                return;
            }

            int i = 0;

            // Print out the available devices
            foreach (var dev in devices)
            {
                cmbNet.Items.Add(dev.Description);
            }

            
            device = devices[choice];


            //Register our handler function to the 'packet arrival' event
            

            // Open the device for capturing
            //device.Open();

            //Console.WriteLine();
            //Console.WriteLine("-- Listening on {0}, hit 'Ctrl-C' to exit...",device.Description);

            // Start capture 'INFINTE' number of packets
            //device.Capture();

            // Close the pcap device
            // (Note: this line will never be called since
            //  we're capturing infinite number of packets
            //device.Close();
        }

        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
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
                        MessageBox.Show("Original UDP packet: " + udp.ToString());

                        //manipulate UDP parameters

                        //DETECTION PACKET DHCP
                        if (udp.ToString().Contains("DHCPMsgType: DHCP Message Type: Ack"))
                        {

                            if (udp.ToString().Contains("DHCPServerId: Server Id: 10.229.60.22"))
                            {
                                //Console.WriteLine();
                                //Console.WriteLine();
                                label1.Text = "C'EST OK C'EST OK C'EST OK C'EST OK C'EST OK";
                                //Console.WriteLine();
                                //Console.WriteLine();


                              
                            }
                            else
                            {
                                //Console.WriteLine();
                                //Console.WriteLine();
                                label1.Text = "HAHAHAAHAAHAHAHAHAHAHHAHHHAHAHAHAHAHAHAH";
                                //Console.WriteLine();
                                //Console.WriteLine();
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


        static void desactivateNetwork()
        {
            Process.Start("cmd", "/K wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable"); // Start a new command prompt, execute command, but leave it open at the end.
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void cmbNet_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            label1.Text = cmbNet.SelectedItem.ToString();
            choice = cmbNet.SelectedIndex;
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
        }
    }
}
