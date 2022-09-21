using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ybi
{
    public class readValuePositions
    {
        #region Ybi to ByteArray
        private static byte[] getYbiByteArray(string filePath)
        {
            if (File.Exists(filePath))
            {
                byte[] ByteArray = File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\" + filePath);
                return ByteArray;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Hexadecimal to Decimal Conversion
        private static string hex2dec(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(long.Parse(hexString, System.Globalization.NumberStyles.HexNumber));
            return sb.ToString();
        }
        #endregion

        #region String to ByteArray
        public static byte[] _StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        #endregion

        #region Return Item Values by index
        public string getItemID(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemID = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + Form1.ItemID_Offset, Form1.ItemID_BytesLenght);
            string[] strArrayID = itemID.Split(new char[] { '-' });
            string reversedID = strArrayID[6] + strArrayID[5] + strArrayID[4] + strArrayID[3] + strArrayID[2] + strArrayID[1] + strArrayID[0];

            return hex2dec(reversedID);

        }

        public string getItemName(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemName = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + Form1.ItemName_Offset, Form1.ItemName_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(itemName);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }

        public static string getItemDesc(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemDesc = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + Form1.ItemDesc_Offset, Form1.ItemDesc_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(itemDesc);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }

        public string getItemLevel(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemLevel = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + Form1.ItemLvl_Offset, Form1.ItemLvl_BytesLenght);
            return hex2dec(itemLevel);
        }

        public string getItemDef(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemDef = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + Form1.ItemDef_Offset, Form1.ItemDef_BytesLenght);
            string[] strArrayDef = itemDef.Split(new char[] { '-' });
            string reversedDef = strArrayDef[1] + strArrayDef[0];

            return hex2dec(reversedDef);
        }

        public string getItemMaxAtk(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemMaxAtk = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + Form1.ItemMaxAtk_Offset, Form1.ItemMaxAtk_BytesLenght);
            string[] strArrayMaxAtk = itemMaxAtk.Split(new char[] { '-' });
            string reversedMaxAtk = strArrayMaxAtk[1] + strArrayMaxAtk[0];

            return hex2dec(reversedMaxAtk);
        }

        public string getItemMinAtk(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemMinAtk = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + Form1.ItemMinAtk_Offset, Form1.ItemMinAtk_BytesLenght);
            string[] strArrayMinAtk = itemMinAtk.Split(new char[] { '-' });
            string reversedMinAtk = strArrayMinAtk[1] + strArrayMinAtk[0];

            return hex2dec(reversedMinAtk);
        }

        public string getItemGold(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemGold = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + Form1.ItemGold_Offset, Form1.ItemGold_BytesLenght);
            string[] strArrayGold = itemGold.Split(new char[] { '-' });
            string reversedGold = strArrayGold[3] + strArrayGold[2] + strArrayGold[1] + strArrayGold[0];

            return hex2dec(reversedGold);
        }

        public string getItemRes1(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemRes1 = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + 82, 1);
            //string[] strArrayRes = itemRes1.Split(new char[] { '-' });
            //string reversedGold = strArrayRes[3] + strArrayRes[2] + strArrayRes[1] + strArrayRes[0];

            return hex2dec(itemRes1);
        }

        public string getItemRes2(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemRes2 = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + 88, 1);
            //string[] strArrayRes = itemRes2.Split(new char[] { '-' });
            //string reversedGold = strArrayRes[3] + strArrayRes[2] + strArrayRes[1] + strArrayRes[0];

            return hex2dec(itemRes2);
        }

        public string getItemWeight(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemWeight = BitConverter.ToString(YbiByteArray, Form1.ItemBytesOfSeparation * index + 90, 1);
            //string[] strArrayRes = itemRes2.Split(new char[] { '-' });
            //string reversedGold = strArrayRes[3] + strArrayRes[2] + strArrayRes[1] + strArrayRes[0];

            return hex2dec(itemWeight);
        }

        // Need to Fix
        /*public string getItemGender(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string itemGender = BitConverter.ToString(YbiByteArray, Form1.BytesOfSeparation * index + 82, 2);
            string[] strArrayGender = itemGender.Split(new char[] { '-' });
            string reversedGender = strArrayGender[1] + strArrayGender[0];

            return hex2dec(reversedGender);
        }*/
        #endregion

        #region Return Map Values by index
        public string getMapID(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string mapID = BitConverter.ToString(YbiByteArray, Form1.MapBytesOfSeparation * index + Form1.MapID_Offset, Form1.MapID_BytesLenght);
            string[] strArrayID = mapID.Split(new char[] { '-' });
            string reversedID = strArrayID[2] + strArrayID[1] + strArrayID[0];

            return hex2dec(reversedID);
        }

        public string getMapName(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string mapName = BitConverter.ToString(YbiByteArray, Form1.MapBytesOfSeparation * index + Form1.MapName_Offset, Form1.MapName_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(mapName);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }
        #endregion

        #region Return Npc Values by index
        public string getNpcID(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string npcID = BitConverter.ToString(YbiByteArray, Form1.NpcBytesOfSeparation * index + Form1.NpcID_Offset, Form1.NpcID_BytesLenght);
            string[] strArrayID = npcID.Split(new char[] { '-' });
            string reversedID = strArrayID[2] + strArrayID[1] + strArrayID[0];

            return hex2dec(reversedID);
        }

        public string getNpcName(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string npcName = BitConverter.ToString(YbiByteArray, Form1.NpcBytesOfSeparation * index + Form1.NpcName_Offset, Form1.NpcName_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(npcName);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }

        public string getNpcDesc(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string npcDesc = BitConverter.ToString(YbiByteArray, Form1.NpcBytesOfSeparation * index + Form1.NpcDesc_Offset, Form1.NpcDesc_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(npcDesc);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }
        #endregion

        #region Return Speech Values by index
        public string getSpeechDesc(int index)
        {
            byte[] SpeechByteArray = getYbiByteArray(Form1.speech_dec_file);

            string speechDesc = BitConverter.ToString(SpeechByteArray, Form1.SpeechBytesOfSeparation * index + Form1.SpeechDesc_Offset, Form1.SpeechDesc_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(speechDesc);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }
        #endregion

        #region Return Ab Values by index
        public string getAbID(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string abID = BitConverter.ToString(YbiByteArray, Form1.AbBytesOfSeparation * index + Form1.AbID_Offset, Form1.AbID_BytesLenght);
            string[] strArrayID = abID.Split(new char[] { '-' });
            string reversedID = strArrayID[2] + strArrayID[1] + strArrayID[0];

            return hex2dec(reversedID);
        }

        public string getAbName(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string abName = BitConverter.ToString(YbiByteArray, Form1.AbBytesOfSeparation * index + Form1.AbName_Offset, Form1.AbName_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(abName);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }

        public string getAbDesc(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string abDesc = BitConverter.ToString(YbiByteArray, Form1.AbBytesOfSeparation * index + Form1.AbDesc_Offset, Form1.AbDesc_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(abDesc);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }

        public string getAbDesc2(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string abDesc = BitConverter.ToString(YbiByteArray, Form1.AbBytesOfSeparation * index + Form1.AbDesc2_Offset, Form1.AbDesc2_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(abDesc);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }
        #endregion

        #region Return Skill Values by index
        public string getSkillID(int index)
        {
            return "";
        }

        public string getSkillName(int index)
        {
            return "";
        }

        public string getSkillDesc(int index)
        {
            return "";
        }
        #endregion

        #region Return ClassName Values by index
        public string getClassName(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string className = BitConverter.ToString(YbiByteArray, Form1.ClassBytesOfSeparation * index + Form1.ClassName_Offset, Form1.ClassName_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(className);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }
        #endregion

        #region Return Text Ban
        public string Ban_Name(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);


            string Ban_Name_Text = BitConverter.ToString(YbiByteArray, Form1.BanBytesOfSeparation * index + Form1.BanName_Offset, Form1.BanName_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(Ban_Name_Text);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }

        public string Ban_Desc(int index)
        {
            byte[] YbiByteArray = getYbiByteArray(Form1.ybi_dec_file);

            string Ban_Desc_text = BitConverter.ToString(YbiByteArray, Form1.BanBytesOfSeparation * index + Form1.BanDesc_Offset, Form1.BanDesc_BytesLenght).Replace("00", "").Replace("-", "");
            var hexArray = _StringToByteArray(Ban_Desc_text);
            string array2str = System.Text.Encoding.Default.GetString(hexArray);

            return array2str;
        }
        #endregion
    }
}
