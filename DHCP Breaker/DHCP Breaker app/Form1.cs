﻿using SharpPcap;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DHCP_Breaker_app
{
    public partial class frmDHCPBreaker : Form
    {

        private const int MAXDECIMAL = 3;
        private const int MINDECIMAL = 0;
        private ICaptureDevice device;
        
        private int choice = 0;
        private CaptureDeviceList devices;
        private List<string> allAddresses = new List<string>();

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
            foreach (string item in lstServeurDHCP.Items)
            {
                if (item.Contains(" - "))
                {
                    string[] componnents = item.Split(' ', '.');

                    /*foreach(string part in componnents)
                    {
                        MessageBox.Show(part);
                    }*/

                    /*
                    MessageBox.Show(componnents[0]); premier octet
                    MessageBox.Show(componnents[1]); deuxième octet
                    MessageBox.Show(componnents[2]); troisième octet
                    MessageBox.Show(componnents[3]); quatrième octet

                    MessageBox.Show(componnents[4]); tiret

                    MessageBox.Show(componnents[5]); premier octet
                    MessageBox.Show(componnents[6]); deuxième octet
                    MessageBox.Show(componnents[7]); troisième octet
                    MessageBox.Show(componnents[8]); quatrième octet
                    */




                    if (Int32.Parse(componnents[0]) == Int32.Parse(componnents[5])) //Les premiers octets des deux adresses sont identiques.
                    {
                        if (Int32.Parse(componnents[1]) == Int32.Parse(componnents[6])) //Les deuxièmes octets des deux adresses sont identiques.
                        {
                            if (Int32.Parse(componnents[2]) == Int32.Parse(componnents[7])) //Les troisièmes octets des deux adresses sont identiques.
                            {
                                if (Int32.Parse(componnents[3]) == Int32.Parse(componnents[8])) //Les adresses de début et de fin sont les mêmes.
                                {
                                    string adresseFinal = componnents[0] + "." + componnents[1] + "." + componnents[2] + "." + componnents[3];
                                    allAddresses.Add(adresseFinal);
                                }
                                else
                                {
                                    for (int i = Int32.Parse(componnents[3]); i <= Int32.Parse(componnents[8]); i++)
                                    {
                                        string addressToAdd = componnents[0] + "." + componnents[1] + "." + componnents[2] + "." + i.ToString();
                                        allAddresses.Add(addressToAdd);
                                    }
                                    foreach (string part in allAddresses)
                                    {
                                        MessageBox.Show(part);
                                    }
                                }
                            }
                            else
                            {
                                bool hasLoop = false;
                                int begginingNumber;
                                int endingNumber;
                                for (int ii = Int32.Parse(componnents[2]); ii <= Int32.Parse(componnents[7]); ii++)
                                {
                                    if (hasLoop == false)
                                    {
                                        begginingNumber = Int32.Parse(componnents[3]);
                                    }
                                    else
                                    {
                                        begginingNumber = MINDECIMAL;
                                    }

                                    if (ii == Int32.Parse(componnents[7]))
                                    {
                                        endingNumber = Int32.Parse(componnents[8]);
                                    }
                                    else
                                    {
                                        endingNumber = MAXDECIMAL;
                                    }

                                    for (int i = begginingNumber; i <= endingNumber; i++)
                                    {
                                        string addressToAdd = componnents[0] + "." + componnents[1] + "." + ii.ToString() + "." + i.ToString();
                                        allAddresses.Add(addressToAdd);
                                    }
                                    hasLoop = true;
                                }
                                foreach (string part in allAddresses)
                                {
                                    MessageBox.Show(part);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("2ème octet différent");
                            
                            bool hasLoop2ndByte = false;
                            int begginingNumber2ndByte;
                            int endingNumber2ndByte;

                            bool hasLoop = false;
                            int begginingNumber;
                            int endingNumber;

                            for (int iii = Int32.Parse(componnents[1]); iii <= Int32.Parse(componnents[6]); iii++)
                            {
                                if (hasLoop2ndByte == false)
                                {
                                    begginingNumber2ndByte = Int32.Parse(componnents[2]);
                                }
                                else
                                {
                                    begginingNumber2ndByte = MINDECIMAL;
                                }

                                if (iii == Int32.Parse(componnents[6]))
                                {
                                    endingNumber2ndByte = Int32.Parse(componnents[7]);
                                }
                                else
                                {
                                    endingNumber2ndByte = MAXDECIMAL;
                                }


                                
                                for (int ii = begginingNumber2ndByte; ii <= endingNumber2ndByte; ii++)
                                {
                                    if (hasLoop == false)
                                    {
                                        begginingNumber = Int32.Parse(componnents[3]);
                                    }
                                    else
                                    {
                                        begginingNumber = MINDECIMAL;
                                    }

                                    if (ii == Int32.Parse(componnents[7]) && (iii == Int32.Parse(componnents[6])))
                                    {
                                        endingNumber = Int32.Parse(componnents[8]);
                                    }
                                    else
                                    {
                                        endingNumber = MAXDECIMAL;
                                    }

                                    for (int i = begginingNumber; i <= endingNumber; i++)
                                    {
                                        string addressToAdd = componnents[0] + "." + iii.ToString() + "." + ii.ToString() + "." + i.ToString();
                                        allAddresses.Add(addressToAdd);
                                    }
                                    hasLoop = true;
                                }
                                foreach (string part in allAddresses)
                                {
                                    MessageBox.Show(part);
                                }
                                hasLoop2ndByte = true;
                                hasLoop = true;

                                
                            }

                            foreach (string part in allAddresses)
                            {
                                MessageBox.Show(part);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("1er octet différent");
                        bool hasLoop1stByte = false;
                        int begginingNumber1stByte;
                        int endingNumber1stByte;


                        bool hasLoop2ndByte = false;
                        int begginingNumber2ndByte;
                        int endingNumber2ndByte;

                        bool hasLoop = false;
                        int begginingNumber;
                        int endingNumber;

                        for (int iiii = Int32.Parse(componnents[0]); iiii <= Int32.Parse(componnents[5]); iiii++)
                        {
                            if (hasLoop1stByte == false)
                            {
                                begginingNumber1stByte = Int32.Parse(componnents[1]);
                            }
                            else
                            {
                                begginingNumber1stByte = MINDECIMAL;
                            }

                            if (iiii == Int32.Parse(componnents[5]))
                            {
                                endingNumber1stByte = Int32.Parse(componnents[6]);
                            }
                            else
                            {
                                endingNumber1stByte = MAXDECIMAL;
                            }

                            for (int iii = begginingNumber1stByte; iii <= endingNumber1stByte; iii++)
                            {
                                if (hasLoop2ndByte == false)
                                {
                                    begginingNumber2ndByte = Int32.Parse(componnents[2]);
                                }
                                else
                                {
                                    begginingNumber2ndByte = MINDECIMAL;
                                }

                                if (iii == Int32.Parse(componnents[6]))
                                {
                                    endingNumber2ndByte = Int32.Parse(componnents[7]);
                                }
                                else
                                {
                                    endingNumber2ndByte = MAXDECIMAL;
                                }

                                for (int ii = begginingNumber2ndByte; ii <= endingNumber2ndByte; ii++)
                                {

                                    if (hasLoop == false)
                                    {
                                        begginingNumber = Int32.Parse(componnents[3]);
                                    }
                                    else
                                    {
                                        begginingNumber = MINDECIMAL;
                                    }

                                    if ((ii == Int32.Parse(componnents[7]))&&(iii == Int32.Parse(componnents[6]))&&(iiii == Int32.Parse(componnents[5])))
                                    {
                                        endingNumber = Int32.Parse(componnents[8]);
                                    }
                                    else
                                    {
                                        endingNumber = MAXDECIMAL;
                                    }

                                    for (int i = begginingNumber; i <= endingNumber; i++)
                                    {
                                        string addressToAdd = iiii.ToString() + "." + iii.ToString() + "." + ii.ToString() + "." + i.ToString();
                                        allAddresses.Add(addressToAdd);
                                        //MessageBox.Show(endingNumber.ToString());
                                    }
                                    hasLoop = true;
 
                                }
                                hasLoop2ndByte = true;
                                hasLoop = true;
                            }
                            hasLoop1stByte = true;
                            hasLoop2ndByte = true;
                            hasLoop = true;

                        }
                        foreach (string part in allAddresses)
                        {
                            MessageBox.Show(part);
                        }

                    }
                }
                else
                {
                    allAddresses.Add(item);
                    MessageBox.Show(item);
                }
            }

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

        private void cmdAddSpecific_Click(object sender, EventArgs e)
        {
            string newAdress = txtS1b.Text + "." + txtS2b.Text + "." + txtS3b.Text + "." + txtS4b.Text;
            lstServeurDHCP.Items.Add(newAdress);
        }

        private void cmdAddRange_Click(object sender, EventArgs e)
        {
            string newDeb = txtDeb1b.Text + "." + txtDeb2b.Text + "." + txtDeb3b.Text + "." + txtDeb4b.Text;
            string newFin = txtFin1b.Text + "." + txtFin2b.Text + "." + txtFin3b.Text + "." + txtFin4b.Text;
            string newRange = newDeb + " - " + newFin;
            lstServeurDHCP.Items.Add(newRange);
        }
    }
}
