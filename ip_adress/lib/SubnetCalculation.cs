using System;

namespace ip_adress.lib
{
    public class SubnetCalculation
    {
        public string CalcSubNetIp(string ip_address_bin)
        {
            var numOne = 00000001;
            
            
            
            var stringOne = Convert.ToInt32(ip_address_bin.Replace(".", "").Substring(1, 8));
            var stringTwo = Convert.ToInt32(ip_address_bin.Replace(".", "").Substring(9, 8));
            var stringThree = Convert.ToInt32(ip_address_bin.Replace(".", "").Substring(17, 8));
            var stringFour = Convert.ToInt32(ip_address_bin.Replace(".", "").Substring(24, 8));
            
            var sumOne = CalcBin(numOne, stringFour);
            var sumTwo = CalcBin(numOne, stringThree);
            
            
            if (Convert.ToInt32(sumOne) < 255)
            {
                stringFour = Convert.ToInt32(sumOne);
            }

            else if (Convert.ToInt32(sumOne) > 255)
            {
                var outPut = Convert.ToInt32(CalcBin(numOne, stringThree));
                stringThree = outPut;
            }


            return $"{stringOne}.{stringTwo}.{stringThree}.{stringFour}";
        }

        private string CalcBin(int num1, int num2)
        {
            var i = 0;
            var rem = 0;
            var str = "";

            while (num1 != 0 || num2 != 0)
            {
                str += (num1 % 10 + num2 % 10 + rem) % 2;
                rem = (num1 % 10 + num2 % 10 + rem) / 2;

                num1 = num1 / 10;
                num2 = num2 / 10;
            }

            if (rem != 0)
                str += rem;

            var outputString = "";
            for (i = str.Length - 1; i >= 0; i--)
            {
                outputString += str[i];
            }

            return outputString;
        }
    }
}