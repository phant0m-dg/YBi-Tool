using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace ybi
{
    public class Dec
    {
        public static BitArray ByteArraytoBitArray(byte[] bytes)
        {
            BitArray bits = new BitArray(bytes);
            return bits;
        }

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] bytes = new byte[bits.Length / 8];
            bits.CopyTo(bytes, 0);
            return bytes;
        }

        static int MoveBit(int src, int oldLoc, int newLoc)
        {
            return ((src >> oldLoc) & 0x1) << newLoc;
        }

        public static void Decrypt(string EncYbiFile)
        {
            byte[] data;
            using (Stream fs = File.OpenRead(EncYbiFile))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
            }

            for (int i = 0; i < data.Length; i += 4)
            {
                Int32 src = BitConverter.ToInt32(data, i);
                Int32 dst = 0;

                dst |= MoveBit(src, 26, 0);
                dst |= MoveBit(src, 31, 1);
                dst |= MoveBit(src, 17, 2);
                dst |= MoveBit(src, 10, 3);
                dst |= MoveBit(src, 30, 4);
                dst |= MoveBit(src, 16, 5);
                dst |= MoveBit(src, 24, 6);
                dst |= MoveBit(src, 2, 7);
                dst |= MoveBit(src, 29, 8);
                dst |= MoveBit(src, 8, 9);
                dst |= MoveBit(src, 20, 10);
                dst |= MoveBit(src, 15, 11);
                dst |= MoveBit(src, 28, 12);
                dst |= MoveBit(src, 11, 13);
                dst |= MoveBit(src, 13, 14);
                dst |= MoveBit(src, 4, 15);
                dst |= MoveBit(src, 19, 16);
                dst |= MoveBit(src, 23, 17);
                dst |= MoveBit(src, 0, 18);
                dst |= MoveBit(src, 12, 19);
                dst |= MoveBit(src, 14, 20);
                dst |= MoveBit(src, 27, 21);
                dst |= MoveBit(src, 6, 22);
                dst |= MoveBit(src, 18, 23);
                dst |= MoveBit(src, 21, 24);
                dst |= MoveBit(src, 3, 25);
                dst |= MoveBit(src, 9, 26);
                dst |= MoveBit(src, 7, 27);
                dst |= MoveBit(src, 22, 28);
                dst |= MoveBit(src, 1, 29);
                dst |= MoveBit(src, 25, 30);
                dst |= MoveBit(src, 5, 31);

                data[i + 0] = (byte)(dst & 0xFF);
                data[i + 1] = (byte)((dst >> 8) & 0xFF);
                data[i + 2] = (byte)((dst >> 16) & 0xFF);
                data[i + 3] = (byte)((dst >> 24) & 0xFF);
            }

            if (EncYbiFile == Form1.ybi_enc_file || EncYbiFile == Form1.ybi_file)
            {
                using (FileStream fs = File.OpenWrite(Form1.ybi_dec_file))
                {
                    fs.Write(data, 0, data.Length);
                }
            }
            else if (EncYbiFile == Form1.speech_enc_file || EncYbiFile == Form1.speech_file)
            {
                using (FileStream fs = File.OpenWrite(Form1.speech_dec_file))
                {
                    fs.Write(data, 0, data.Length);
                }
            }
        }
    }
}
