using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wallet_test_1
{
    public class Sha256
    {
        private readonly uint[] K = new uint[64] {
            0x428A2F98, 0x71374491, 0xB5C0FBCF, 0xE9B5DBA5, 0x3956C25B, 0x59F111F1, 0x923F82A4, 0xAB1C5ED5,
            0xD807AA98, 0x12835B01, 0x243185BE, 0x550C7DC3, 0x72BE5D74, 0x80DEB1FE, 0x9BDC06A7, 0xC19BF174,
            0xE49B69C1, 0xEFBE4786, 0x0FC19DC6, 0x240CA1CC, 0x2DE92C6F, 0x4A7484AA, 0x5CB0A9DC, 0x76F988DA,
            0x983E5152, 0xA831C66D, 0xB00327C8, 0xBF597FC7, 0xC6E00BF3, 0xD5A79147, 0x06CA6351, 0x14292967,
            0x27B70A85, 0x2E1B2138, 0x4D2C6DFC, 0x53380D13, 0x650A7354, 0x766A0ABB, 0x81C2C92E, 0x92722C85,
            0xA2BFE8A1, 0xA81A664B, 0xC24B8B70, 0xC76C51A3, 0xD192E819, 0xD6990624, 0xF40E3585, 0x106AA070,
            0x19A4C116, 0x1E376C08, 0x2748774C, 0x34B0BCB5, 0x391C0CB3, 0x4ED8AA4A, 0x5B9CCA4F, 0x682E6FF3,
            0x748F82EE, 0x78A5636F, 0x84C87814, 0x8CC70208, 0x90BEFFFA, 0xA4506CEB, 0xBEF9A3F7, 0xC67178F2
        };

        private readonly uint[] K_H = new uint[8] {
            0x6A09E667, 0xBB67AE85, 0x3C6EF372, 0xA54FF53A, 0x510E527F, 0x9B05688C, 0x1F83D9AB, 0x5BE0CD19
        };
        private int how_block_need = 0;
        private uint[] data;
        private uint[] word_64;
        private uint[] H;
        private uint a, b, c, d, e, f, g, h;
        public Sha256()
        {
            this.word_64 = new uint[64];
            this.H = new uint[8];
            for (int i = 0; i < 8; i++)
            {
                H[i] = K_H[i];
            } 
        }
    
        public void SetData(byte[] data_)
        {
            byte[] data = new byte[data_.Length + 1];
            byte addElement = 0b10000000;
            Array.Copy(data_, data, data_.Length);
            data[data.Length - 1] = addElement;

            ulong data_Lenght = (ulong)(data_.Length * 8);
            uint start_Lenght = (uint)(data_Lenght & 0x00000000ffffffff);
            uint end_Lenght = (uint)(data_Lenght & 0xffffffff00000000);


            this.how_block_need = ((data.Length + 9) % 64) == 0 ? ((data.Length + 9) / 64) : (((data.Length + 9) / 64) + 1);
            this.data = new uint[this.how_block_need * 16];

            this.data[this.data.Length - 1] = start_Lenght;
            this.data[this.data.Length - 2] = end_Lenght;

            uint cnt = 0;
            uint cnt2 = 0;
            while(cnt < data.Length)
            {
                uint acumulator = 0;
                for(int i = 0; i < 4; i++)
                {
                    if (cnt < data.Length)
                    {   
                        acumulator = acumulator + ((uint)(data[cnt]) << (24 - (i * 8)));
                        cnt++;
                    }
                }
                this.data[cnt2] = acumulator;
                cnt2++;
            }
        }

        public uint[] GetHashSum()
        {
            for (int x = 0; x < this.how_block_need; x++)
            {

                this.a = H[0];
                this.b = H[1];
                this.c = H[2];
                this.d = H[3];
                this.e = H[4];
                this.f = H[5];
                this.g = H[6];
                this.h = H[7];

                //________________________________________________________________________________________

                for (int i = 0; i < 16; i++)
                {
                    this.word_64[i] = this.data[i + (x * 16)];
                }

                //________________________________________________________________________________________

                for (int i = 16; i < word_64.Length; i++)
                {
                    uint Ro0 = 0;
                    uint Ro1 = 0;
                    Ro0 = ((word_64[i - 15] >> 7) | (word_64[i - 15] << 25)) ^ ((word_64[i - 15] >> 18) | (word_64[i - 15] << 14)) ^ word_64[i - 15] >> 3;
                    Ro1 = ((word_64[i - 2] >> 17) | (word_64[i - 2] << 15)) ^ ((word_64[i - 2] >> 19) ^ (word_64[i - 2] << 13)) ^ word_64[i - 2] >> 10;
                    word_64[i] = word_64[i - 16] + Ro0 + word_64[i - 7] + Ro1;
                }

                for (int i = 0; i < word_64.Length; i++)
                {
                    uint E1 = ((this.e >> 6) | (this.e << 26)) ^ ((this.e >> 11) | (this.e << 21)) ^ ((this.e >> 25) | (this.e << 7));
                    uint Choise = (this.e & this.f) ^ ((~this.e) & this.g);
                    uint E0 = ((this.a >> 2) | (this.a << 30)) ^ ((this.a >> 13) | (this.a << 19)) ^ ((this.a >> 22) | (this.a << 10));
                    uint Majority = (this.a & this.b) ^ (this.a & this.c) ^ (this.b & this.c);
                    uint Temp1 = this.h + E1 + Choise + K[i] + word_64[i];
                    uint Temp2 = E0 + Majority;
                   
                    h = g;
                    g = f;
                    f = e;
                    e = d + Temp1;
                    d = c;
                    c = b;
                    b = a;
                    a = Temp1 + Temp2;
                }

                H[0] = H[0] + a;
                H[1] = H[1] + b;
                H[2] = H[2] + c;
                H[3] = H[3] + d;
                H[4] = H[4] + e;
                H[5] = H[5] + f;
                H[6] = H[6] + g;
                H[7] = H[7] + h;

            }
            return H;
        }

    }

}
