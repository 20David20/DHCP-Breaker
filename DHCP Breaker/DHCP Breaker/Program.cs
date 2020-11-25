using System;
using System.Diagnostics;

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

        static void desactivateNetwork()
        {
            //system("wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable");
            Process.Start("cmd", "/K wmic path win32_networkadapter where \"NetEnabled='TRUE'\" call disable"); // Start a new command prompt, execute command, but leave it open at the end.
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int decision = 0;

            decision = askAction();
            switch (decision)
            {
                case 1:
                    desactivateNetwork();
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
