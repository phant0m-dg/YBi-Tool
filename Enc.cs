using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace ybi
{
    public class Enc
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

        // Read 4 bytes ONLY
        static int MoveBit(int src, int oldLoc, int newLoc)
        {
            return ((src >> oldLoc) & 0x1) << newLoc;
        }

        public static void Encrypt(string DecYbiFile)
        {
            byte[] data;
            using (Stream fs = File.OpenRead(DecYbiFile))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
            }

            for (int i = 0; i < data.Length; i += 4)
            {
                Int32 src = BitConverter.ToInt32(data, i);
                Int32 dst = 0;

                dst |= MoveBit(src, 0, 26);
                dst |= MoveBit(src, 1, 31);
                dst |= MoveBit(src, 2, 17);
                dst |= MoveBit(src, 3, 10);
                dst |= MoveBit(src, 4, 30);
                dst |= MoveBit(src, 5, 16);
                dst |= MoveBit(src, 6, 24);
                dst |= MoveBit(src, 7, 2);
                dst |= MoveBit(src, 8, 29);
                dst |= MoveBit(src, 9, 8);
                dst |= MoveBit(src, 10, 20);
                dst |= MoveBit(src, 11, 15);
                dst |= MoveBit(src, 12, 28);
                dst |= MoveBit(src, 13, 11);
                dst |= MoveBit(src, 14, 13);
                dst |= MoveBit(src, 15, 4);
                dst |= MoveBit(src, 16, 19);
                dst |= MoveBit(src, 17, 23);
                dst |= MoveBit(src, 18, 0);
                dst |= MoveBit(src, 19, 12);
                dst |= MoveBit(src, 20, 14);
                dst |= MoveBit(src, 21, 27);
                dst |= MoveBit(src, 22, 6);
                dst |= MoveBit(src, 23, 18);
                dst |= MoveBit(src, 24, 21);
                dst |= MoveBit(src, 25, 3);
                dst |= MoveBit(src, 26, 9);
                dst |= MoveBit(src, 27, 7);
                dst |= MoveBit(src, 28, 22);
                dst |= MoveBit(src, 29, 1);
                dst |= MoveBit(src, 30, 25);
                dst |= MoveBit(src, 31, 5);

                data[i + 0] = (byte)(dst & 0xFF);
                data[i + 1] = (byte)((dst >> 8) & 0xFF);
                data[i + 2] = (byte)((dst >> 16) & 0xFF);
                data[i + 3] = (byte)((dst >> 24) & 0xFF);
            }
            if (DecYbiFile == Form1.ybi_dec_file)
            {
                using (FileStream fs = File.OpenWrite(Form1.ybi_enc_file))
                {
                    fs.Write(data, 0, data.Length);
                }
            }
            else if (DecYbiFile == Form1.speech_dec_file)
            {
                using (FileStream fs = File.OpenWrite(Form1.speech_enc_file))
                {
                    fs.Write(data, 0, data.Length);
                }
            }
        }
    }
}
