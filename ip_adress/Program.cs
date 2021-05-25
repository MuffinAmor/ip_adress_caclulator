using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net; //Include this namespace 



namespace ip_adress
{
    class Program
    {
        public static uint[] GetIpRange(string ip, IPAddress subnet)
        {
            uint ip2 = Utils.IPv4ToUInt(ip);
            uint sub = Utils.IPv4ToUInt(subnet);

            uint first = ip2 & sub;
            uint last = first | (0xffffffff & ~sub);

            return new uint[] { first, last };
        }
        static void Main(string[] args)
        {
            string strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            string ip = addr[1].ToString();
            Console.WriteLine(ip);
            Console.Write("Geben Sie ein IP-Adresse an: ");
            String ipadr = Console.ReadLine();
            Console.Write("Geben Sie ein Subnetzmaske ein: ");
            String subnet = Console.ReadLine();

            string[] words = subnet.Split('.');

            string binaer = "";

            foreach (var word in words)
            {
                Console.WriteLine(word);
                int dez;
                string bin;

                dez = Convert.ToInt32(word);
                bin = Convert.ToString(dez, 2);

                if (bin == "0")
                {
                    bin = String.Concat(Enumerable.Repeat("0", 8));
                }

                binaer += bin;
            }


            int count = binaer.Count(f => f == '0');
            double hosts = Math.Pow(2, count) - 2;


            string[] numbers = ipadr.Split('.'); //Zerlegung der IP Adresse
            string one = numbers[0];
            string two = numbers[1];
            string three = numbers[2];

            string firstIp = one + "." + two + "." + three + ".1";


            string binary_string = Convert.ToString(IPAddrToBinary(firstIp));
            Console.WriteLine(binary_string);

            string[] tokens = binary_string.Split('.'); //Zerlegung des Binary Strings
            int first = Convert.ToInt32(tokens[0]);
            int second = Convert.ToInt32(tokens[1]);
            int third = Convert.ToInt32(tokens[2]);

            int fourth = Convert.ToInt32(tokens[3]);
            for (int i = 0;
                i < hosts;
                i++)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine($"Erste IP Adresse: {firstIp}");

            //Console.WriteLine($"Letzte IP Adresse: {last_ip}");
            //Console.WriteLine($"Broadcast Adresse: {broadcast}");
            Console.WriteLine($"Anzahl Hosts: {hosts}");
        }

        static string IPAddrToBinary(string input)
        {
            return String.Join(".", ( // join segments
                input.Split('.').Select( // split segments into a string[]

                    // take each element of array, name it "x",
                    //   and return binary format string
                    x => Convert.ToString(Int32.Parse(x), 2).PadLeft(8, '0')

                    // convert the IEnumerable<string> to string[],
                    // which is 2nd parameter of String.Join
                )).ToArray());
        }
    }
}
//192.168.39.100