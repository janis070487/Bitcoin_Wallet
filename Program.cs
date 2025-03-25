using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Numerics;
using NBitcoin;


using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

//using NBitcoin;



namespace Wallet_test_1
{
    internal class Program
    {





        
        

        


        static void Main(string[] args)
        {


           // //BigInteger n = BigInteger.Parse("12423523432222288811111000");
           // //BigInteger n2 = BigInteger.Parse("744533838354488363736252748992922778392202722839930202038764637282");
           // //BigInteger result = n + n2;
           // //Console.WriteLine(result);

           // Sha256 sha = new Sha256();
           // //string sms = "Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis";
           // string sms = "Janis";

           // byte[] data = Encoding.UTF8.GetBytes(sms);

           // sha.SetData(data);

           //uint[] result = sha.GetHashSum();

           // Console.WriteLine();

           // for (int i = 0; i < result.Length; i++)
           // {
           //     Console.Write(result[i].ToString("x2"));
           // }


            //_________________________________________________________________


            string stra = "2";
           
            BigInteger a = BigInteger.Parse(stra);


            for (int i = 0; i < 10; i++)
            {
                a = a * 2 - 1;
                Console.WriteLine($"BigNumber: {a}");
            }
            // Iegūt un izdrukāt BigInteger vērtību  
            





            //Sha256 sha = new Sha256();
            ////string sms = "Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis Janis";
            //string sms = "Janis";

            //byte[] data = Encoding.UTF8.GetBytes(sms);

            //uint[] result;

            //sha.SetData(data);

            //Stopwatch stopwatch = new Stopwatch();  
            //stopwatch.Start();
            ////for (int i = 0; i < 2000000; i++)
            ////{
            ////    sha.GetHashSum();
            ////}

            //stopwatch.Stop();
            //Console.WriteLine("Izpildes laiks: {0} ms", stopwatch.Elapsed.TotalMilliseconds);

            //result = sha.GetHashSum();

            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.Write(result[i].ToString("x2"));
            //}

            Console.ReadLine();
        }
    }
}


/*
Console.WriteLine(num.ToString("x2")); // Izvadīs "ff" (mazie burti)  
Console.WriteLine(num.ToString("X2")); // Izvadīs "FF" (lielie burti)  
Console.WriteLine("0x" + num.ToString("X")); // Izvadīs "0xFF" (lielie burti, bez platuma)  
Console.WriteLine("0x" + num.ToString("x")); // Izvadīs "0xff" (mazie burti, bez platuma)  
Console.WriteLine("0x" + num.ToString("X8")); // Izvadīs "0x000000FF" (lielie burti, ar 8 zīmēm)  


uint skaitlis = 10;  
string binarais = Convert.ToString(skaitlis, 2);  
Console.WriteLine(binarais); // Izvada: 1010  


uint skaitlis = 10;  
string binarais = Convert.ToString(skaitlis, 2).PadLeft(8, '0'); // 8 ir vēlamais garums  
Console.WriteLine(binarais); // Izvada: 00001010  



*/



/*
 using System;  
using System.Diagnostics;  

class Program  
{  
    static void Main()  
    {  
        Stopwatch stopwatch = new Stopwatch();  

        // Sākt laika mērīšanu  
        stopwatch.Start();  

        // Kods, kura izpildes laiku vēlamies izmērīt  
        for (int i = 0; i < 1000000; i++)  
        {  
            // Šeit var būt kāda darbība  
        }  

        // Apturēt laika mērīšanu  
        stopwatch.Stop();  

        // Izvadīt izpildes laiku  
        Console.WriteLine("Izpildes laiks: {0} ms", stopwatch.Elapsed.TotalMilliseconds);  
    }  
}  
 */