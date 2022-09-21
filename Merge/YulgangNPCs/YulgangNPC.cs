using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ybiLoader
{
    public class ybNPC
    {
        public byteData byteData;
        public byteWriter byteWriter;
        public ybNPC(int sPos, byteData b)
        {
            this.startPosition = sPos;
            this.byteData = b;
            this.byteWriter = new byteWriter(ref byteData);
        }
        
        private int startPosition { get; set; }
        public bool isValid { get { return !(npcID == 0); } }
        public int npcID
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
        public string npcName
        {
            get
            {
                return Encoding.Default.GetString(byteData.ybiData, startPosition + 4, 24);
            }
            set
            {
                byteWriter.PatchString(startPosition + 4, 24, value);
            }
        }
        public string npcDesc
        {
            get
            {
                return Encoding.Default.GetString(byteData.ybiData, startPosition + 76, 200);
            }
            set
            {
                byteWriter.PatchString(startPosition + 76, 200, value);
            }
        }
        public int npcLevel
        {
            get
            {
                return (int)BitConverter.ToInt16(byteData.ybiData, startPosition + 70);
            }
            set
            {
                byteWriter.PatchInt32(startPosition + 70, value);
            }
        }

  

        public static void LoadNPCs(byteData b)
        {
            int pos = 17282120;
            while (true)
            {
                ybNPC npc = new ybNPC(pos,b);
                if (npc.isValid)
                    b.ybNPCList.Add(npc);
                else
                    break;
                pos += 7860;
            }
        }
    }
}
