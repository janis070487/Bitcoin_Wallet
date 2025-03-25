using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet_test_1
{
    internal class Piezimes
    {
    }
}


//public void PrintDataToBin()
//{
//    Print_binary(this.data);
//}

//public void PrintWord64ToBin()
//{
//    Print_binary(this.word_64);
//}


//public void Print_binary(uint[] data)
//{
//    for (int i = 0; i < data.Length; i++)
//    {
//        int cnt = 0;
//        string str = "";

//        for (int j = 31; j > -1; j--)
//        {
//            uint value = (data[i] >> j) & 0b00000000_00000000_00000000_00000001;
//            str = (value == 1) ? str = str + '1' : str = str + '0';
//            cnt++;
//            if (cnt > 7)
//            {
//                str = str + " ";
//                cnt = 0;
//            }
//        }
//        Console.WriteLine(i + ": " + str);
//    }
//}
////___________________________________________________________________________
//public void Print_binary(uint data)
//{

//    int cnt = 0;
//    string str = "";

//    for (int j = 31; j > -1; j--)
//    {
//        uint value = (data >> j) & 0b00000000_00000000_00000000_00000001;
//        str = (value == 1) ? str = str + '1' : str = str + '0';
//        cnt++;
//        if (cnt > 7)
//        {
//            str = str + " ";
//            cnt = 0;
//        }
//    }
//    Console.WriteLine(str);

//}