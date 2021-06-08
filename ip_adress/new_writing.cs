using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace calculation
{
    public class new_writing
    {
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

        public string Calc_NetMask(string ip_adress)
        {
            return "";
        }

        public double Calc_Host(string subnet)
        {
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

            return hosts;
        }
    }
}