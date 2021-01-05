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

        private ICaptureDevice device;
        private int choice = 0;
        private CaptureDeviceList devices;


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
            devices = CaptureDeviceList.Instance;
            foreach (var dev in devices)
            {
                cmbNet.Items.Add(dev.Description);
            }
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

                    var udp = packet.Extract<PacketDotNet.UdpPacket>();
                    if (udp != null)
                    {
                        //rtxtPackets.Text += "Original UDP packet: " + udp.ToString();

                        //manipulate UDP parameters

                        //DETECTION PACKET DHCP
                        if (udp.ToString().Contains("DHCPMsgType: DHCP Message Type: Ack"))
                        {

                            if (udp.ToString().Contains("DHCPServerId: Server Id: 10.229.60.22"))
                            {
                                //Console.WriteLine();
                                //Console.WriteLine();
                                MessageBox.Show("Serveur DHCP autorisé");
                                //Console.WriteLine();
                                //Console.WriteLine();


                              
                            }
                            else
                            {
                                try
                                {
                                    MessageBox.Show("ATTENTION, SERVEUR DHCP NON AUTORISÉ DETECTÉ \n Extinction des cartes réseaux");
                                    desactivateNetwork();
                                }
                                catch (ThreadAbortException)
                                {
                                    // exit
                                }
                            }
                        }
                    }
                }

            }
        }


        private void desactivateNetwork()
        {
            Process.Start("cmd", "/K wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable");
            cmdNetRestart.Visible = true;
            cmdNetRestart.Enabled = true;
        }



        private void cmbNet_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            choice = cmbNet.SelectedIndex;
            device = devices[choice];
            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
            device.Open();
            device.StartCapture();      
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            device.StopCapture();
        }

        private void cmdNetRestartClick(object sender, EventArgs e)
        {
            Process.Start("cmd", "/K wmic path win32_networkadapter where \"NetEnabled='FALSE'\" call enable");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
