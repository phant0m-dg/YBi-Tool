using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ybi
{
    public class writeValuePositions
    {
        #region Hexadecimal to ASCII Convertion
        private static string hex2ascii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        #endregion

        #region Hexadecimal to Decimal Convertion
        private static string hex2dec(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(long.Parse(hexString, System.Globalization.NumberStyles.HexNumber));
            return sb.ToString();
        }
        #endregion

        #region String to ByteArray Convertion
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        #endregion

        #region Set Item Values by index
        public static bool setItemID(int index, string _FileName, string hexVals)
        {
            var bytes = BitConverter.GetBytes(int.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemID_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setItemName(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.ItemName_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemName_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setItemDesc(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.ItemDesc_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemDesc_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
            
        }

        public static bool setItemLevel(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(int.Parse(hexVals));
            byte neededBytes = bytes[0];

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemLvl_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(neededBytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setItemDef(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(int.Parse(hexVals));
            byte neededBytes = bytes[0];

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemDef_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(neededBytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setItemMaxAtk(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));
            byte neededBytes = bytes[0];
            byte neededBytes2 = bytes[1];

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemMaxAtk_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(neededBytes);
                bw.BaseStream.Seek(Form1.ItemMaxAtk_Offset + Form1.ItemBytesOfSeparation * index + 1, SeekOrigin.Begin);
                bw.Write(neededBytes2);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setItemMinAtk(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));
            byte neededBytes = bytes[0];
            byte neededBytes2 = bytes[1];

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemMinAtk_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(neededBytes);
                bw.BaseStream.Seek(Form1.ItemMinAtk_Offset + Form1.ItemBytesOfSeparation * index + 1, SeekOrigin.Begin);
                bw.Write(neededBytes2);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setItemGold(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemGold_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setItemRes1(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(0x00000052 + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes,0,1);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setItemRes2(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(0x00000058 + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setItemWeight(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(0x0000005a + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }
        #endregion

        #region Set Map Values by index
        public static bool setMapName(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.MapName_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.MapName_Offset + Form1.MapBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }
        #endregion

        #region Set Npc Values by index
        public static bool setNpcName(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.NpcName_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.NpcName_Offset + Form1.NpcBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setNpcDesc(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.NpcDesc_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.NpcDesc_Offset + Form1.NpcBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;

        }
        #endregion

        #region Set Speech Values by index
        public static bool setSpeechDesc(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.SpeechDesc_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.SpeechDesc_Offset + Form1.SpeechBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }
        #endregion

        #region Set Ability Values by index
        public static bool setAbName(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.AbName_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.AbName_Offset + Form1.AbBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool setAbDesc(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.AbDesc_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.AbDesc_Offset + Form1.AbBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;

        }

        public static bool setAbDesc2(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.AbDesc2_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.AbDesc2_Offset + Form1.AbBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;

        }
        #endregion

        #region Set ClassName Values by index
        public static bool setClassName(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.ClassName_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ClassName_Offset + Form1.ClassBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }
        #endregion

        #region Set Ban_Name Values by index
        public static bool setBan_Name(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.BanName_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.BanName_Offset + Form1.BanBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;

        }

        public static bool setBan_Desc(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.BanDesc_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.BanDesc_Offset + Form1.BanBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;

        }
        #endregion

        #region Set Item Merge Values by index
        public static bool mergeItemID(int index, string _FileName, string hexVals)
        {
            var bytes = BitConverter.GetBytes(int.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemID_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool mergeItemName(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.ItemName_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemName_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool mergeItemDesc(int index, string _FileName, string hexVals)
        {
            byte[] str2array = System.Text.Encoding.Default.GetBytes(hexVals);
            int varbt = Form1.ItemDesc_BytesLenght - str2array.Length;

            byte[] _newArray = new byte[str2array.Length + varbt];
            str2array.CopyTo(_newArray, 0);
            str2array = _newArray;

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemDesc_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(str2array);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;

        }

        public static bool mergeItemLevel(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(int.Parse(hexVals));
            byte neededBytes = bytes[0];

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemLvl_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(neededBytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool mergeItemDef(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(int.Parse(hexVals));
            byte neededBytes = bytes[0];

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemDef_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(neededBytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool mergeItemMaxAtk(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));
            byte neededBytes = bytes[0];
            byte neededBytes2 = bytes[1];

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemMaxAtk_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(neededBytes);
                bw.BaseStream.Seek(Form1.ItemMaxAtk_Offset + Form1.ItemBytesOfSeparation * index + 1, SeekOrigin.Begin);
                bw.Write(neededBytes2);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool mergeItemMinAtk(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));
            byte neededBytes = bytes[0];
            byte neededBytes2 = bytes[1];

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemMinAtk_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(neededBytes);
                bw.BaseStream.Seek(Form1.ItemMinAtk_Offset + Form1.ItemBytesOfSeparation * index + 1, SeekOrigin.Begin);
                bw.Write(neededBytes2);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool mergeItemGold(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(Form1.ItemGold_Offset + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool mergeItemRes1(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(0x00000052 + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes, 0, 1);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool mergeItemRes2(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(0x00000058 + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }

        public static bool mergeItemWeight(int index, string _FileName, string hexVals)
        {
            byte[] bytes = BitConverter.GetBytes(Int32.Parse(hexVals));

            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(_FileName, FileMode.Open));
                bw.BaseStream.Seek(0x0000005a + Form1.ItemBytesOfSeparation * index, SeekOrigin.Begin);
                bw.Write(bytes);
                bw.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString());
            }
            return false;
        }
        #endregion

    }
}
