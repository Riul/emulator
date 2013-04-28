using System;
using Sniffer.Network;

namespace Sniffer
{
    class Program
    {
        public static MITM MITM { get; private set; }

        static void Main(string[] args)
        {
            MITM = new MITM();
            MITM.Start();

            while (true)
            {
                Console.ReadLine();
                }
        }
    }
}
