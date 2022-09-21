using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ybi
{
    public class Config
    {
        private static string iniPath = Application.StartupPath + @"\config.ini";

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /*public string ybiFile { get; set; }
        public string ybiDECFile { get; set; }
        public string ybiENCFile { get; set; }
        public string spchFile { get; set; }
        public string spchDECFile { get; set; }
        public string spchENCFile { get; set; }

        public string ItemBytesOfSeparation { get; set; }
        public string ItemID_BytesOfSeparation { get; set; }
        public string ItemID_BytesLenght { get; set; }
        public string ItemName_BytesOfSeparation { get; set; }
        public string ItemName_BytesLenght { get; set; }
        public string ItemDesc_BytesOfSeparation { get; set; }
        public string ItemDesc_BytesLenght { get; set; }
        public string ItemLvl_BytesOfSeparation { get; set; }
        public string ItemLvl_BytesLenght { get; set; }
        public string ItemDef_BytesOfSeparation { get; set; }
        public string ItemDef_BytesLenght { get; set; }
        public string ItemMaxAtk_BytesOfSeparation { get; set; }
        public string ItemMaxAtk_BytesLenght { get; set; }
        public string ItemMinAtk_BytesOfSeparation { get; set; }
        public string ItemMinAtk_BytesLenght { get; set; }
        public string ItemGold_BytesOfSeparation { get; set; }
        public string ItemGold_BytesLenght { get; set; }

        public string MapBytesOfSeparation { get; set; }
        public string MapID_BytesOfSeparation { get; set; }
        public string MapID_BytesLenght { get; set; }
        public string MapName_BytesOfSeparation { get; set; }
        public string MapName_BytesLenght { get; set; }

        public string NpcBytesOfSeparation { get; set; }
        public string NpcID_BytesOfSeparation { get; set; }
        public string NpcID_BytesLenght { get; set; }
        public string NpcName_BytesOfSeparation { get; set; }
        public string NpcName_BytesLenght { get; set; }
        public string NpcDesc_BytesOfSeparation { get; set; }
        public string NpcDesc_BytesLenght { get; set; }

        public string SpeechBytesOfSeparation { get; set; }
        public string SpeechDesc_BytesOfSeparation { get; set; }
        public string SpeechDesc_BytesLenght { get; set; }

        public string AbBytesOfSeparation { get; set; }
        public string AbID_BytesOfSeparation { get; set; }
        public string AbID_BytesLenght { get; set; }
        public string AbName_BytesOfSeparation { get; set; }
        public string AbName_BytesLenght { get; set; }
        public string AbDesc_BytesOfSeparation { get; set; }
        public string AbDesc_BytesLenght { get; set; }
        public string AbDesc2_BytesOfSeparation { get; set; }
        public string AbDesc2_BytesLenght { get; set; }

        public static int BanBytesOfSeparation { get; set; }
        public static int BanName_BytesOfSeparation { get; set; }
        public static int BanName_BytesLenght { get; set; }
        public static int BanDesc_BytesOfSeparation { get; set; }
        public static int BanDesc_BytesLenght { get; set; }

        public void LoadMe()
        {
            ybiFile = IniReadValue("Files", "YBiName").Trim();
            ybiDECFile = IniReadValue("Files", "YBiDecryptedName").Trim();
            ybiENCFile = IniReadValue("Files", "YBiEncryptedName").Trim();
            spchFile = IniReadValue("Files", "SpeechInfoName").Trim();
            spchDECFile = IniReadValue("Files", "SpeechInfoDecryptedName").Trim();
            spchENCFile = IniReadValue("Files", "SpeechInfoEncryptedName").Trim();

            ItemBytesOfSeparation = IniReadValue("ItemsOffsets", "BytesOfSeparation").Trim();
            ItemID_BytesOfSeparation = IniReadValue("ItemsOffsets", "ID_BytesOfSeparation").Trim();
            ItemID_BytesLenght = IniReadValue("ItemsOffsets", "ID_BytesLenght").Trim();
            ItemName_BytesOfSeparation = IniReadValue("ItemsOffsets", "Name_BytesOfSeparation").Trim();
            ItemName_BytesLenght = IniReadValue("ItemsOffsets", "Name_BytesLenght").Trim();
            ItemDesc_BytesOfSeparation = IniReadValue("ItemsOffsets", "Desc_BytesOfSeparation").Trim();
            ItemDesc_BytesLenght = IniReadValue("ItemsOffsets", "Desc_BytesLenght").Trim();
            ItemLvl_BytesOfSeparation = IniReadValue("ItemsOffsets", "Lvl_BytesOfSeparation").Trim();
            ItemLvl_BytesLenght = IniReadValue("ItemsOffsets", "Lvl_BytesLenght").Trim();
            ItemDef_BytesOfSeparation = IniReadValue("ItemsOffsets", "Def_BytesOfSeparation").Trim();
            ItemDef_BytesLenght = IniReadValue("ItemsOffsets", "Def_BytesLenght").Trim();
            ItemMaxAtk_BytesOfSeparation = IniReadValue("ItemsOffsets", "MaxAtk_BytesOfSeparation").Trim();
            ItemMaxAtk_BytesLenght = IniReadValue("ItemsOffsets", "MaxAtk_BytesLenght").Trim();
            ItemMinAtk_BytesOfSeparation = IniReadValue("ItemsOffsets", "MinAtk_BytesOfSeparation").Trim();
            ItemMinAtk_BytesLenght = IniReadValue("ItemsOffsets", "MinAtk_BytesLenght").Trim();
            ItemGold_BytesOfSeparation = IniReadValue("ItemsOffsets", "Gold_BytesOfSeparation").Trim();
            ItemGold_BytesLenght = IniReadValue("ItemsOffsets", "Gold_BytesLenght").Trim();

            MapBytesOfSeparation = IniReadValue("MapsOffsets", "BytesOfSeparation").Trim();
            MapID_BytesOfSeparation = IniReadValue("MapsOffsets", "ID_BytesOfSeparation").Trim();
            MapID_BytesLenght = IniReadValue("MapsOffsets", "ID_BytesLenght").Trim();
            MapName_BytesOfSeparation = IniReadValue("MapsOffsets", "Name_BytesOfSeparation").Trim();
            MapName_BytesLenght = IniReadValue("MapsOffsets", "Name_BytesLenght").Trim();

            NpcBytesOfSeparation = IniReadValue("NPCOffsets", "BytesOfSeparation").Trim();
            NpcID_BytesOfSeparation = IniReadValue("NPCOffsets", "ID_BytesOfSeparation").Trim();
            NpcID_BytesLenght = IniReadValue("NPCOffsets", "ID_BytesLenght").Trim();
            NpcName_BytesOfSeparation = IniReadValue("NPCOffsets", "Name_BytesOfSeparation").Trim();
            NpcName_BytesLenght = IniReadValue("NPCOffsets", "Name_BytesLenght").Trim();
            NpcDesc_BytesOfSeparation = IniReadValue("NPCOffsets", "Desc_BytesOfSeparation").Trim();
            NpcDesc_BytesLenght = IniReadValue("NPCOffsets", "Desc_BytesLenght").Trim();

            SpeechBytesOfSeparation = IniReadValue("SpeechOffsets", "BytesOfSeparation").Trim();
            SpeechDesc_BytesOfSeparation = IniReadValue("SpeechOffsets", "Desc_BytesOfSeparation").Trim();
            SpeechDesc_BytesLenght = IniReadValue("SpeechOffsets", "Desc_BytesLenght").Trim();

            AbBytesOfSeparation = IniReadValue("AbOffsets", "BytesOfSeparation").Trim();
            AbID_BytesOfSeparation = IniReadValue("AbOffsets", "ID_BytesOfSeparation").Trim();
            AbID_BytesLenght = IniReadValue("AbOffsets", "ID_BytesLenght").Trim();
            AbName_BytesOfSeparation = IniReadValue("AbOffsets", "Name_BytesOfSeparation").Trim();
            AbName_BytesLenght = IniReadValue("AbOffsets", "Name_BytesLenght").Trim();
            AbDesc_BytesOfSeparation = IniReadValue("AbOffsets", "Desc_BytesOfSeparation").Trim();
            AbDesc_BytesLenght = IniReadValue("AbOffsets", "Desc_BytesLenght").Trim();
            AbDesc2_BytesOfSeparation = IniReadValue("AbOffsets", "Desc2_BytesOfSeparation").Trim();
            AbDesc2_BytesLenght = IniReadValue("AbOffsets", "Desc2_BytesLenght").Trim();

            BanBytesOfSeparation = Int32.Parse(IniReadValue("BadWordsOffsets", "BytesOfSeparation").Trim());
            BanName_BytesOfSeparation = Int32.Parse(IniReadValue("BadWordsOffsets", "Name_BytesOfSeparation").Trim().Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
            BanName_BytesLenght = Int32.Parse(IniReadValue("BadWordsOffsets", "Name_BytesLenght").Trim());
            BanDesc_BytesOfSeparation = Int32.Parse(IniReadValue("BadWordsOffsets", "Desc_BytesOfSeparation").Trim().Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
            BanDesc_BytesLenght = Int32.Parse(IniReadValue("BadWordsOffsets", "Desc_BytesLenght").Trim());
        }*/

        public static string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(1024);
            int i = GetPrivateProfileString(Section, Key, "", temp, 1024, iniPath);
            return temp.ToString();
        }
    }
}
