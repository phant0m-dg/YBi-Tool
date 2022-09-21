using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ybiLoader
{
    public class ybItem
    {

        public byteData byteData;
        public byteWriter byteWriter;
        public ybItem(int sp, byteData b)
        {
            this.startPosition = sp;
            this.byteData = b;
            this.byteWriter = new byteWriter(ref byteData);
        }

        private int startPosition { get; set; }
        public bool isValid { get { return !(ItemID == 0); } }
        public int ItemID
        {
            get
            {
                return BitConverter.ToInt32(byteData.ybiData, startPosition);
            }
            //set
            //{
            //    byteWriter.PatchInt32(startPosition, value);
            //}
        }
        public string ItemName 
        {
            get
            {
                return Encoding.Default.GetString(byteData.ybiData, startPosition + 8, 52).Replace("\0", "");
            }
            set
            {
                byteWriter.PatchString(startPosition + 8, 52, value);
            }
        }
        public string ItemDesc
        {
            get
            {
                return Encoding.Default.GetString(byteData.ybiData, startPosition + 156, 164).Replace("\0", "");
            }
            set
            {
                byteWriter.PatchString(startPosition + 156, 164, value);
            }
        }
        public int ItemBuyValue
        {
            get
            {
                return BitConverter.ToInt32(byteData.ybiData, startPosition + 100);
            }
            set
            {
                byteWriter.PatchInt32(startPosition + 100, value);
            }
        }
        public int ItemSellValue
        {
            get
            {
                return BitConverter.ToInt32(byteData.ybiData, startPosition + 108);
            }
            set
            {
                byteWriter.PatchInt32(startPosition + 108, value);
            }
        }
        public int ItemLevel
        {
            get
            {
                return byteData.ybiData[startPosition + 76];
            }
            set
            {
                byteWriter.PatchInt32(startPosition + 76, value);
            }
        }
        public ybClass ItemJob
        {
            get
            {
                 return (ybClass)((int)byteData.ybiData[startPosition + 74]);
            }
            set
            {
                byteWriter.PatchInt16(startPosition + 76, (int)value);
            }
        }
        public ybGender ItemGender
        {
            get
            {
                return (ybGender)((int)byteData.ybiData[startPosition + 79]);
            }
            set
            {
                byteData.ybiData[startPosition + 79] = (byte)value;
            }
        }
        public ybFaction ItemFaction
        {
            get
            {
                return (ybFaction)((int)byteData.ybiData[startPosition + 120]);
            }
            set
            {
                byteData.ybiData[startPosition + 120] = (byte)value;
            }
        }
        public ybType ItemType
        {
            get
            {
                return (ybType)((int)byteData.ybiData[startPosition + 80]);
            }
            set
            {
                byteData.ybiData[startPosition + 80] = (byte)value;
            }
        }
        public int ItemAttackMin
        {
            get
            {
                return byteData.ybiData[startPosition + 86];
            }
            set
            {
                byteWriter.PatchInt16(startPosition + 86, value);
            }
        }
        public int ItemAttackMax
        {
            get
            {
                return byteData.ybiData[startPosition + 84];
            }
            set
            {
                byteWriter.PatchInt16(startPosition + 84, value);
            }
        }
        public int ItemDefense
        {
            get
            {
                return byteData.ybiData[startPosition + 88];
            }
            set
            {
                byteWriter.PatchInt16(startPosition + 88, value);
            }
        }

        public static void LoadItems(byteData b)
        {
            b.ybItemList.Clear();
            int pos = 8;
            while (true)
            {
                var Item = new ybItem(pos,b);
                if (Item.isValid)
                    b.ybItemList.Add(Item);
                else
                    break;
                pos += 848;
            }
        }
    }
}
