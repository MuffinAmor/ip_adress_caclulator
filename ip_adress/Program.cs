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
            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();  
            Console.WriteLine("My IP Address is :"+myIP);  
            Console.ReadKey();  
        }  
    }  
}
 
   


