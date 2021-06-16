using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net; //Include this namespace 
using ip_adress.lib;


namespace ip_adress
{
    class main
    {
        static void Main(string[] args)
        {
            Console.Write("Geben Sie ein IP-Adresse an: ");
            String ipadr = Console.ReadLine();

            Console.Write("Geben Sie ein Subnetzmaske ein: ");
            String subnet = Console.ReadLine();

            //////////////////////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////////////////

            var outputIp = new AddressCalculation().IPAddrToBinary(ipadr);
            var outputSubnet = new AddressCalculation().IPAddrToBinary(subnet);
            
            var outputNetMaskBin = new AddressCalculation().Calc_Net(ipadr, subnet);
            var outputNetBroadBin = new AddressCalculation().Calc_Broad(ipadr, subnet);
            var outputNetFirstBin = new AddressCalculation().Calc_First(ipadr, subnet);
            var outputNetLastBin = new AddressCalculation().Calc_Last(ipadr, subnet);

            //var outputNetMaskIp = new AddressCalculation().ConvertToIp(outputNetBroadBin);

            
            var outputHosts = new AddressCalculation().Calc_Host(subnet);

            Console.WriteLine($"IP Adresse: {outputIp} - {ipadr}");
            Console.WriteLine($"Subnetzmaske: {outputSubnet} - {subnet}");
            //Console.WriteLine($"Netzwerk: {outputNetMaskBin} - {outputNetMaskIp}");
            Console.WriteLine($"Erste IP: {outputNetFirstBin} - ");
            Console.WriteLine($"Letzte IP: {outputNetLastBin} - ");
            Console.WriteLine($"Broadcast: {outputNetBroadBin} - ");
            Console.WriteLine($"Anzahl mögliche Hosts: {outputHosts}");
        }
    }
}