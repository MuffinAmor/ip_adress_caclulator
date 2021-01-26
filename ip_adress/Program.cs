using System;
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Net; //Include this namespace 

namespace ip_adress
{
     class Program{  
        static void Main(string[] args)  
        {   
            //string hostName = Dns.GetHostName();
            //Console.WriteLine(hostName);  
            //string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();  
            //Console.WriteLine("My IP Address is :"+myIP);  
            //Console.ReadKey();  
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
                int dez;
                string bin;
                
                dez = Convert.ToInt32(word);
                bin = Convert.ToString(dez, 2);

                if(bin == "0"){
                    bin = String.Concat(Enumerable.Repeat("0", 8));
                }

                binaer += bin;
            }
            int count = binaer.Count(f => f == '0');
            double hosts = Math.Pow(2, count) -2;
            Console.WriteLine(hosts);
            







        }  
    }  
}
 
   


