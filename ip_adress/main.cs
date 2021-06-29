using System;
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
            var ipAddress = "";
            ipAddress = ipadr;

            for (var i = 0; i < 4; i++)
            {
                var outputIp = new AddressCalculation().IPAddrToBinary(ipAddress);
                var outputSubnet = new AddressCalculation().IPAddrToBinary(subnet);

                var outputNetMaskBin = new AddressCalculation().Calc_Net(ipadr, subnet);
                var outputNetBroadBin = new AddressCalculation().Calc_Broad(ipadr, subnet);
                var outputNetFirstBin = new AddressCalculation().Calc_First(ipadr, subnet);
                var outputNetLastBin = new AddressCalculation().Calc_Last(ipadr, subnet);

                var outputNetMaskIp = new AddressCalculation().ConvertToIp(outputNetMaskBin);
                var outputNetBroadIp = new AddressCalculation().ConvertToIp(outputNetBroadBin);
                var outputNetFirstIp = new AddressCalculation().ConvertToIp(outputNetFirstBin);
                var outputNetLastIp = new AddressCalculation().ConvertToIp(outputNetLastBin);


                var outputHosts = new AddressCalculation().Calc_Host(subnet);

                Console.WriteLine($"IP Adresse: {outputIp} - {ipadr}");
                Console.WriteLine($"Subnetzmaske: {outputSubnet} - {subnet}");
                Console.WriteLine($"Netzwerk: {outputNetMaskBin} - {outputNetMaskIp}");
                Console.WriteLine($"Erste IP: {outputNetFirstBin} - {outputNetFirstIp}");
                Console.WriteLine($"Letzte IP: {outputNetLastBin} - {outputNetLastIp}");
                Console.WriteLine($"Broadcast: {outputNetBroadBin} - {outputNetBroadIp}");
                Console.WriteLine($"Anzahl mögliche Hosts: {outputHosts}");

                
                var nextAddressBin = new SubnetCalculation().CalcSubNetIp(outputNetBroadBin);
                var nextAddressIp = new AddressCalculation().ConvertToIp(nextAddressBin);
                Console.WriteLine($"Nächste Adresse: {nextAddressBin} - {nextAddressIp}");
                ipAddress = outputNetBroadIp;
            }
        }
    }
}