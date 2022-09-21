using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ybiLoader
{
    public class byteWriter
    {
        public byteData byteData;
        public byteWriter(ref byteData b)
        {
            byteData = b;
        }
        public void PatchString(int offset, int len, string str)
        {
            byte[] toCopy = new byte[len];
            byte[] tmpArr2 = Encoding.Default.GetBytes(str);
            Buffer.BlockCopy(tmpArr2, 0, toCopy, 0, tmpArr2.Length);
            Buffer.BlockCopy(toCopy, 0, byteData.ybiData, offset, toCopy.Length);
        }
        public void PatchInt32(int offset, int num)
        {
            byte[] toCopy = BitConverter.GetBytes(num);
            Buffer.BlockCopy(toCopy, 0, byteData.ybiData, offset, toCopy.Length);
        }
        public void PatchInt16(int offset, int num)
        {
            byte[] toCopy = BitConverter.GetBytes(Convert.ToInt16(num));
            Buffer.BlockCopy(toCopy, 0, byteData.ybiData, offset, toCopy.Length);
        }
    }
}
