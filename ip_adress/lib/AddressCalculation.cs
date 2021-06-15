﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ip_adress.lib
{
    public class AddressCalculation
    {
        public string ConvertToIp(string Address)
        {
            var bytes = Address
                .Split('.')
                .Select(@byte => Convert.ToInt32(@byte, 2));
            var address = IPAddress.Parse(string.Join(".", bytes));
            Console.WriteLine(address);
            return address.ToString();
        }

        public string IPAddrToBinary(string input)
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

        public string Calc_Work_String(string ip_address, string subnetz)
        {
            var binString = IPAddrToBinary(ip_address);
            var source = IPAddrToBinary(subnetz);
            var count = source.Count(f => f == '1');
            var net = binString.Replace(".", "").Substring(0, count);
            var counter = 0;
            var lastAddress = "";

            foreach (var i in net)
            {
                counter += 1;
                if (counter % 9 == 0 & i != 0)
                {
                    lastAddress += ".";
                }
                else
                {
                    lastAddress += i;
                }
            }

            return lastAddress;
        }

        public double Calc_Host(string subnet)
        {
            var words = subnet.Split('.');
            var binaer = "";

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

            var count = binaer.Count(f => f == '0');
            var hosts = Math.Pow(2, count) - 2;

            return hosts;
        }

        public string Calc_Last(string ip_address, string subnetz)
        {
            var workAddress = Calc_Work_String(ip_address, subnetz);
            var addressLength = workAddress.Length;
            var lastAddress = workAddress;

            for (var i = addressLength; i < 35; i++)
            {
                if (i % 9 == 0 & i != 0)
                {
                    lastAddress += ".";
                }

                if (i < 34)
                {
                    lastAddress += "1";
                }
                else
                {
                    lastAddress += "0";
                }
            }

            return lastAddress;
        }

        public string Calc_First(string ip_address, string subnetz)
        {
            var workAddress = Calc_Work_String(ip_address, subnetz);
            var addressLength = workAddress.Length;
            var firstAddress = workAddress;

            for (var i = addressLength; i < 35; i++)
            {
                if (i % 9 == 0 & i != 0)
                {
                    firstAddress += ".";
                }

                if (i < 34)
                {
                    firstAddress += "0";
                }
                else
                {
                    firstAddress += "1";
                }
            }

            return firstAddress;
        }

        public string Calc_Broad(string ip_address, string subnetz)
        {
            var workAddress = Calc_Work_String(ip_address, subnetz);
            var addressLength = workAddress.Length;
            var broadAddress = workAddress;

            for (var i = addressLength; i < 36; i++)
            {
                if (i % 9 == 0 & i != 0)
                {
                    broadAddress += ".";
                }
                else
                {
                    broadAddress += "1";
                }
            }

            return broadAddress;
        }

        public string Calc_Net(string ip_address, string subnetz)
        {
            var workAddress = Calc_Work_String(ip_address, subnetz);
            var addressLength = workAddress.Length;
            var netAddress = workAddress;

            for (var i = addressLength; i < 35; i++)
            {
                if (i % 9 == 0 & i != 0)
                {
                    netAddress += ".";
                }
                else
                {
                    netAddress += "0";
                }
            }

            return netAddress;
        }
    }
}