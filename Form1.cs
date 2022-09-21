using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Specialized;
using MetroFramework.Forms;

namespace ybi
{
    public partial class Form1 : MetroForm
    {
        ListBox ItemIDBox = new ListBox();
        ListBox MapIDBox = new ListBox();
        ListBox NpcIDBox = new ListBox();
        ListBox SkillIDBox = new ListBox();
        ListBox AbIDBox = new ListBox();

        ListBox M_ItemIDBox = new ListBox();
        ListBox M_ItemNameBox = new ListBox();
        ListBox M_ItemDescBox = new ListBox();

        readValuePositions readValuePositions = new readValuePositions();

        public Form1()
        {
            InitializeComponent();
        }

        #region Configs
        public static string ybi_file = Config.IniReadValue("Files", "YBiName");
        public static string ybi_dec_file = Config.IniReadValue("Files", "YBiDecryptedName");
        public static string ybi_enc_file = Config.IniReadValue("Files", "YBiEncryptedName");
        public static string merge_dec_file = Config.IniReadValue("Files", "MergeYBiDecryptedName");
        public static string speech_file = Config.IniReadValue("Files", "SpeechInfoName");
        public static string speech_dec_file = Config.IniReadValue("Files", "SpeechInfoDecryptedName");
        public static string speech_enc_file = Config.IniReadValue("Files", "SpeechInfoEncryptedName");

        public static int ItemBytesOfSeparation = Int32.Parse(Config.IniReadValue("ItemsOffsets", "BytesOfSeparation"));
        public static int ItemID_Offset = Int32.Parse(Config.IniReadValue("ItemsOffsets", "ID_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int ItemID_BytesLenght = Int32.Parse(Config.IniReadValue("ItemsOffsets", "ID_BytesLenght"));
        public static int ItemName_Offset = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Name_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int ItemName_BytesLenght = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Name_BytesLenght"));
        public static int ItemNameToID_BytesLenght = Int32.Parse(Config.IniReadValue("ItemsOffsets", "NameToID_BytesLenght"));
        public static int ItemDesc_Offset = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Desc_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int ItemDesc_BytesLenght = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Desc_BytesLenght"));
        public static int ItemLvl_Offset = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Lvl_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int ItemLvl_BytesLenght = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Lvl_BytesLenght"));
        public static int ItemDef_Offset = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Def_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int ItemDef_BytesLenght = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Def_BytesLenght"));
        public static int ItemMaxAtk_Offset = Int32.Parse(Config.IniReadValue("ItemsOffsets", "MaxAtk_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int ItemMaxAtk_BytesLenght = Int32.Parse(Config.IniReadValue("ItemsOffsets", "MaxAtk_BytesLenght"));
        public static int ItemMinAtk_Offset = Int32.Parse(Config.IniReadValue("ItemsOffsets", "MinAtk_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int ItemMinAtk_BytesLenght = Int32.Parse(Config.IniReadValue("ItemsOffsets", "MinAtk_BytesLenght"));
        public static int ItemGold_Offset = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Gold_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int ItemGold_BytesLenght = Int32.Parse(Config.IniReadValue("ItemsOffsets", "Gold_BytesLenght"));

        public static int MapBytesOfSeparation = Int32.Parse(Config.IniReadValue("MapsOffsets", "BytesOfSeparation"));
        public static int MapID_Offset = Int32.Parse(Config.IniReadValue("MapsOffsets", "ID_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int MapID_BytesLenght = Int32.Parse(Config.IniReadValue("MapsOffsets", "ID_BytesLenght"));
        public static int MapName_Offset = Int32.Parse(Config.IniReadValue("MapsOffsets", "Name_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int MapName_BytesLenght = Int32.Parse(Config.IniReadValue("MapsOffsets", "Name_BytesLenght"));
        public static int MapNameToID_BytesLenght = Int32.Parse(Config.IniReadValue("MapsOffsets", "NameToID_BytesLenght"));

        public static int NpcBytesOfSeparation = Int32.Parse(Config.IniReadValue("NPCOffsets", "BytesOfSeparation"));
        public static int NpcID_Offset = Int32.Parse(Config.IniReadValue("NPCOffsets", "ID_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int NpcID_BytesLenght = Int32.Parse(Config.IniReadValue("NPCOffsets", "ID_BytesLenght"));
        public static int NpcName_Offset = Int32.Parse(Config.IniReadValue("NPCOffsets", "Name_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int NpcName_BytesLenght = Int32.Parse(Config.IniReadValue("NPCOffsets", "Name_BytesLenght"));
        public static int NpcNameToID_BytesLenght = Int32.Parse(Config.IniReadValue("NPCOffsets", "NameToID_BytesLenght"));
        public static int NpcDesc_Offset = Int32.Parse(Config.IniReadValue("NPCOffsets", "Desc_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int NpcDesc_BytesLenght = Int32.Parse(Config.IniReadValue("NPCOffsets", "Desc_BytesLenght"));

        public static int SpeechBytesOfSeparation = Int32.Parse(Config.IniReadValue("SpeechOffsets", "BytesOfSeparation"));
        public static int SpeechID_Offset = Int32.Parse(Config.IniReadValue("SpeechOffsets", "ID_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int SpeechID_BytesLenght = Int32.Parse(Config.IniReadValue("SpeechOffsets", "ID_BytesLenght"));
        public static int SpeechDesc_Offset = Int32.Parse(Config.IniReadValue("SpeechOffsets", "Desc_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int SpeechDesc_BytesLenght = Int32.Parse(Config.IniReadValue("SpeechOffsets", "Desc_BytesLenght"));
        public static int SpeechDescToID_BytesLenght = Int32.Parse(Config.IniReadValue("SpeechOffsets", "DescToID_BytesLenght"));

        public static int AbBytesOfSeparation = Int32.Parse(Config.IniReadValue("AbOffsets", "BytesOfSeparation"));
        public static int AbID_Offset = Int32.Parse(Config.IniReadValue("AbOffsets", "ID_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int AbID_BytesLenght = Int32.Parse(Config.IniReadValue("AbOffsets", "ID_BytesLenght"));
        public static int AbName_Offset = Int32.Parse(Config.IniReadValue("AbOffsets", "Name_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int AbName_BytesLenght = Int32.Parse(Config.IniReadValue("AbOffsets", "Name_BytesLenght"));
        public static int AbNameToID_BytesLenght = Int32.Parse(Config.IniReadValue("AbOffsets", "NameToID_BytesLenght"));
        public static int AbDesc_Offset = Int32.Parse(Config.IniReadValue("AbOffsets", "Desc_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int AbDesc_BytesLenght = Int32.Parse(Config.IniReadValue("AbOffsets", "Desc_BytesLenght"));
        public static int AbDesc2_Offset = Int32.Parse(Config.IniReadValue("AbOffsets", "Desc2_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int AbDesc2_BytesLenght = Int32.Parse(Config.IniReadValue("AbOffsets", "Desc2_BytesLenght"));

        public static int ClassBytesOfSeparation = Int32.Parse(Config.IniReadValue("ClassnameOffsets", "BytesOfSeparation"));
        public static int ClassName_Offset = Int32.Parse(Config.IniReadValue("ClassnameOffsets", "Name_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int ClassName_BytesLenght = Int32.Parse(Config.IniReadValue("ClassnameOffsets", "Name_BytesLenght"));

        public static int BanBytesOfSeparation = Int32.Parse(Config.IniReadValue("BadWordsOffsets", "BytesOfSeparation"));
        public static int BanName_Offset = Int32.Parse(Config.IniReadValue("BadWordsOffsets", "Name_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int BanName_BytesLenght = Int32.Parse(Config.IniReadValue("BadWordsOffsets", "Name_BytesLenght"));
        public static int BanDesc_Offset = Int32.Parse(Config.IniReadValue("BadWordsOffsets", "Desc_Offset").Replace("0x", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
        public static int BanDesc_BytesLenght = Int32.Parse(Config.IniReadValue("BadWordsOffsets", "Desc_BytesLenght"));
        #endregion

        #region Declarations Region

        public static int openForm = 0;
        public static int itemCount = 0;

        public static byte[] YbiByteArray = Ybi2ByteArray(ybi_dec_file);
        public static byte[] MergeByteArray = Ybi2ByteArray(merge_dec_file);
        #endregion

        #region Convertions Region
        public static byte[] Ybi2ByteArray(string filePath)
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

        private string hex2dec(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(long.Parse(hexString, System.Globalization.NumberStyles.HexNumber));
            return sb.ToString();
        }

        static public int byteToInt32(byte[] data, int position)
        {
            return BitConverter.ToInt32(data, position);
        }

        static public string byteToString(byte[] data, int startpos, int length)
        {
            byte[] arr2 = new byte[length];
            Buffer.BlockCopy(data, startpos, arr2, 0, length);
            //return System.Text.Encoding.GetEncoding("Unicode").GetString(arr2);
            return System.Text.Encoding.Default.GetString(arr2, 0, length).Replace("\0", ""); //arr2,0,32
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        #endregion

        #region ListBox Region
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                int index = (listBox1.SelectedIndex);
                try
                {
                    textBox12.Text = readValuePositions.getItemName(index);
                    textBox11.Text = readValuePositions.getItemID(index);
                    textBox2.Text = readValuePositions.getItemDesc(index);
                    textBox3.Text = readValuePositions.getItemLevel(index);
                    textBox4.Text = readValuePositions.getItemDef(index);
                    textBox5.Text = readValuePositions.getItemMinAtk(index);
                    textBox6.Text = readValuePositions.getItemMaxAtk(index);
                    textBox10.Text = readValuePositions.getItemGold(index);
                    textBox35.Text = readValuePositions.getItemRes1(index);
                    textBox34.Text = readValuePositions.getItemRes2(index);
                    textBox36.Text = readValuePositions.getItemWeight(index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex.Message));
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0)
            {
                int index = (listBox2.SelectedIndex);
                try
                {
                    textBox9.Text = readValuePositions.getMapName(index);
                    textBox14.Text = readValuePositions.getMapID(index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex.Message));
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.Items.Count != 0)
            {
                int index = (listBox3.SelectedIndex);
                try
                {
                    textBox16.Text = readValuePositions.getSpeechDesc(index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex.Message));
                }
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.Items.Count != 0)
            {
                int index = (listBox4.SelectedIndex);
                try
                {
                    textBox19.Text = readValuePositions.getNpcName(index);
                    textBox20.Text = readValuePositions.getNpcID(index);
                    textBox15.Text = readValuePositions.getNpcDesc(index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex.Message));
                }
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox5.Items.Count != 0)
            {
                int index = (listBox5.SelectedIndex);
                try
                {
                    textBox23.Text = readValuePositions.getAbName(index);
                    textBox24.Text = readValuePositions.getAbID(index);
                    textBox17.Text = readValuePositions.getAbDesc(index);
                    textBox18.Text = readValuePositions.getAbDesc2(index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex.Message));
                }
            }
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox7.Items.Count != 0)
            {
                int index = (listBox7.SelectedIndex);
                try
                {
                    textBox32.Text = readValuePositions.Ban_Name(index);
                    textBox31.Text = readValuePositions.Ban_Desc(index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex.Message));
                }
            }
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox8.Items.Count != 0)
            {
                int index = (listBox8.SelectedIndex);
                try
                {
                    textBox37.Text = readValuePositions.getClassName(index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex.Message));
                }
            }
        }

        #endregion

        #region Buttons Region
        private void button3_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ybi_dec_file))
            {
                MessageBox.Show(ybi_dec_file + " File doesn't exist!");
            }
            else
            {
                label12.Text = "Encrypting " + ybi_dec_file + " finished!";
                if (!File.Exists(ybi_enc_file))
                {
                    File.Create(ybi_enc_file).Dispose();
                    Enc.Encrypt(ybi_dec_file);
                }
                else
                {
                    Enc.Encrypt(ybi_dec_file);
                }
            }
            if (!File.Exists(speech_dec_file))
            {
                MessageBox.Show(speech_dec_file + " File doesn't exist!");
            }
            else
            {
                label19.Text = "Encrypting " + speech_dec_file + " finished!";
                if (!File.Exists(speech_enc_file))
                {
                    File.Create(speech_enc_file).Dispose();
                    Enc.Encrypt(speech_dec_file);
                }
                else
                {
                    Enc.Encrypt(speech_dec_file);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ybi_enc_file))
            {
                if (!File.Exists(ybi_file))
                {
                    MessageBox.Show(ybi_file + " and " + ybi_enc_file + " files don't exist!");
                }
                else
                {
                    label12.Text = "Decrypting " + ybi_file + " finished!";
                    Dec.Decrypt(ybi_file);
                }
            }
            else if (File.Exists(ybi_enc_file))
            {
                label12.Text = "Decrypting " + ybi_enc_file + " finished!";
                if (!File.Exists(ybi_dec_file))
                {
                    File.Create(ybi_dec_file).Dispose();
                    Dec.Decrypt(ybi_enc_file);
                }
                else
                {
                    Dec.Decrypt(ybi_enc_file);
                }
            }

            if (!File.Exists(speech_enc_file))
            {
                if (!File.Exists(speech_file))
                {
                    MessageBox.Show(speech_file + " and " + speech_enc_file + " files don't exist!");
                }
                else
                {
                    label19.Text = "Decrypting " + speech_file + " finished!";
                    Dec.Decrypt(speech_file);
                }
            }
            else if (File.Exists(speech_enc_file))
            {
                label19.Text = "Decrypting " + speech_enc_file + " finished!";
                if (!File.Exists(speech_dec_file))
                {
                    File.Create(speech_dec_file).Dispose();
                    Dec.Decrypt(speech_enc_file);
                }
                else
                {
                    Dec.Decrypt(speech_enc_file);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(ybi_dec_file))
            {
                button1.Text = "Reload";
                byte[] YbiByteArray = Ybi2ByteArray(ybi_dec_file);

                listBox1.Items.Clear();
                ItemIDBox.Items.Clear();

                try
                {
                    int pos = ItemID_Offset;
                    while (true)
                    {
                        int pid = byteToInt32(YbiByteArray, pos);
                        if (pid == 0) break;

                        string itemID = BitConverter.ToString(YbiByteArray, pos, ItemID_BytesLenght);
                        string[] strArrayID = itemID.Split(new char[] { '-' });
                        string reversedID = strArrayID[3] + strArrayID[2] + strArrayID[1] + strArrayID[0];

                        string itemName = byteToString(YbiByteArray, pos + ItemNameToID_BytesLenght, ItemName_BytesLenght);

                        ItemIDBox.Items.Add(this.hex2dec(reversedID));
                        listBox1.Items.Add(itemName);

                        pos += ItemBytesOfSeparation;
                    }

                    button2.Enabled = true;
                    button5.Enabled = true;
                    button22.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox6.Enabled = true;
                    textBox10.Enabled = true;
                    textBox12.Enabled = true;
                    textBox13.Enabled = true;
                    textBox34.Enabled = true;
                    textBox35.Enabled = true;
                    textBox36.Enabled = true;
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    listBox1.Enabled = true;
                    listBox1.SetSelected(0, true);

                    label24.Text = "Item Count:" + listBox1.Items.Count;
                    itemCount = listBox1.Items.Count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("You need to place " + ybi_dec_file + " in the same folder as the YBi Tool");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (File.Exists(ybi_dec_file))
            {
                button7.Text = "Reload";
                byte[] YbiByteArray = Ybi2ByteArray(ybi_dec_file);

                listBox2.Items.Clear();
                MapIDBox.Items.Clear();

                try
                {

                    int pos = MapID_Offset;
                    while (true)
                    {
                        int pid = byteToInt32(YbiByteArray, pos);
                        if (pid == 0) break;

                        string mapID = BitConverter.ToString(YbiByteArray, pos, MapID_BytesLenght);
                        string[] strArrayID = mapID.Split(new char[] { '-' });
                        string reversedID = strArrayID[2] + strArrayID[1] + strArrayID[0];

                        string mapName = byteToString(YbiByteArray, pos + MapNameToID_BytesLenght, MapName_BytesLenght);

                        MapIDBox.Items.Add(this.hex2dec(reversedID));
                        listBox2.Items.Add(mapName);

                        pos += MapBytesOfSeparation;
                    }

                    button6.Enabled = true;
                    button8.Enabled = true;
                    textBox7.Enabled = true;
                    textBox8.Enabled = true;
                    textBox9.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    listBox2.Enabled = true;
                    listBox2.SetSelected(0, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("You need to place " + ybi_dec_file + " in the same folder as the YBi Tool");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (File.Exists(ybi_dec_file))
            {
                button12.Text = "Reload";
                byte[] YbiByteArray = Ybi2ByteArray(ybi_dec_file);

                listBox4.Items.Clear();
                NpcIDBox.Items.Clear();

                try
                {

                    int pos = NpcID_Offset;
                    while (true)
                    {
                        int pid = byteToInt32(YbiByteArray, pos);
                        if (pid == 0) break;

                        string npcID = BitConverter.ToString(YbiByteArray, pos, NpcID_BytesLenght);
                        string[] strArrayID = npcID.Split(new char[] { '-' });
                        string reversedID = strArrayID[2] + strArrayID[1] + strArrayID[0];

                        string npcName = byteToString(YbiByteArray, pos + NpcNameToID_BytesLenght, NpcName_BytesLenght);

                        NpcIDBox.Items.Add(this.hex2dec(reversedID));
                        listBox4.Items.Add(npcName);

                        pos += NpcBytesOfSeparation;
                    }

                    button13.Enabled = true;
                    button14.Enabled = true;
                    textBox21.Enabled = true;
                    textBox22.Enabled = true;
                    textBox19.Enabled = true;
                    textBox15.Enabled = true;
                    radioButton7.Enabled = true;
                    radioButton8.Enabled = true;
                    listBox4.Enabled = true;
                    listBox4.SetSelected(0, true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("You need to place " + ybi_dec_file + " in the same folder as the YBi Tool");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (listBox1.Items.Count != 0 && textBox11.Text.Length != 0)
            {
                writeValuePositions.setItemLevel(index, ybi_dec_file, textBox3.Text);
                writeValuePositions.setItemDef(index, ybi_dec_file, textBox4.Text);
                writeValuePositions.setItemMaxAtk(index, ybi_dec_file, textBox6.Text);
                writeValuePositions.setItemMinAtk(index, ybi_dec_file, textBox5.Text);
                writeValuePositions.setItemGold(index, ybi_dec_file, textBox10.Text);
                writeValuePositions.setItemName(index, ybi_dec_file, textBox12.Text);
                writeValuePositions.setItemDesc(index, ybi_dec_file, textBox2.Text);

                writeValuePositions.setItemRes1(index, ybi_dec_file, textBox35.Text);
                writeValuePositions.setItemRes2(index, ybi_dec_file, textBox34.Text);
                writeValuePositions.setItemWeight(index, ybi_dec_file, textBox36.Text);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0 && textBox14.Text.Length != 0)
            {
                int index = listBox2.SelectedIndex;

                writeValuePositions.setMapName(index, ybi_dec_file, textBox9.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (File.Exists(speech_dec_file))
            {
                button9.Text = "Reload";
                byte[] SpeechByteArray = Ybi2ByteArray(speech_dec_file);

                listBox3.Items.Clear();

                try
                {

                    int pos = SpeechID_Offset;
                    while (true)
                    {
                        int pid = byteToInt32(SpeechByteArray, pos);
                        if (pid == 0) break;

                        string spchID = BitConverter.ToString(SpeechByteArray, pos, SpeechID_BytesLenght);
                        string[] strArrayID = spchID.Split(new char[] { '-' });
                        string reversedID = strArrayID[2] + strArrayID[1] + strArrayID[0];

                        string speechName = byteToString(SpeechByteArray, pos + SpeechDescToID_BytesLenght, SpeechDesc_BytesLenght);

                        listBox3.Items.Add(speechName);

                        pos += SpeechBytesOfSeparation;
                    }

                    button10.Enabled = true;
                    textBox16.Enabled = true;

                    listBox3.Enabled = true;
                    listBox3.SetSelected(0, true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("You need to place " + speech_dec_file + " in the same folder as the YBi Tool");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (listBox4.Items.Count != 0 && textBox20.Text.Length != 0)
            {
                int index = listBox4.SelectedIndex;

                writeValuePositions.setNpcName(index, ybi_dec_file, textBox19.Text);
                writeValuePositions.setNpcDesc(index, ybi_dec_file, textBox15.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                    if (textBox13.Text.Length != 0)
                    {
                        int index = ItemIDBox.FindStringExact(textBox13.Text);
                        if (index != -1)
                        {
                            listBox1.SetSelected(index, true);
                        }
                        else
                        {
                            MessageBox.Show("Could not find Item ID.");
                        }
                    }
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show(_Exception.ToString());
                }
            }
            else if (radioButton2.Checked)
            {
                try
                {
                    if (textBox1.Text.Length != 0)
                    {
                        int index = listBox1.FindStringExact(textBox1.Text);
                        if (index != -1)
                        {
                            listBox1.SetSelected(index, true);
                        }
                        else
                        {
                            MessageBox.Show("Could not find Item Name.");
                        }
                    }
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show(_Exception.ToString());
                }
            }
            else if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please select a search method.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                try
                {
                    if (textBox7.Text.Length != 0)
                    {
                        int index = MapIDBox.FindStringExact(textBox7.Text);
                        if (index != -1)
                        {
                            listBox2.SetSelected(index, true);
                        }
                        else
                        {
                            MessageBox.Show("Could not find Map ID.");
                        }
                    }
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show(_Exception.ToString());
                }
            }
            else if (radioButton4.Checked)
            {
                try
                {
                    if (textBox8.Text.Length != 0)
                    {
                        int index = listBox2.FindStringExact(textBox8.Text);
                        if (index != -1)
                        {
                            listBox2.SetSelected(index, true);
                        }
                        else
                        {
                            MessageBox.Show("Could not find Map Name.");
                        }
                    }
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show(_Exception.ToString());
                }
            }
            else if (!radioButton3.Checked && !radioButton4.Checked)
            {
                MessageBox.Show("Please select a search method.");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count != 0 && textBox16.Text.Length != 0)
            {
                int index = listBox3.SelectedIndex;

                writeValuePositions.setSpeechDesc(index, speech_dec_file, textBox16.Text);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (File.Exists(ybi_dec_file))
            {
                button15.Text = "Reload";
                byte[] YbiByteArray = Ybi2ByteArray(ybi_dec_file);

                listBox5.Items.Clear();
                AbIDBox.Items.Clear();

                try
                {
                    int pos = AbID_Offset;
                    while (true)
                    {
                        int pid = byteToInt32(YbiByteArray, pos);
                        if (pid == 0) break;

                        string abID = BitConverter.ToString(YbiByteArray, pos, AbID_BytesLenght);
                        string[] strArrayID = abID.Split(new char[] { '-' });
                        string reversedID = strArrayID[2] + strArrayID[1] + strArrayID[0];

                        string abName = byteToString(YbiByteArray, pos + AbNameToID_BytesLenght, AbName_BytesLenght);

                        AbIDBox.Items.Add(this.hex2dec(reversedID));
                        listBox5.Items.Add(abName);

                        pos += AbBytesOfSeparation;
                    }

                    button16.Enabled = true;
                    button17.Enabled = true;
                    textBox23.Enabled = true;
                    textBox24.Enabled = true;
                    textBox25.Enabled = true;
                    textBox26.Enabled = true;
                    textBox17.Enabled = true;
                    textBox18.Enabled = true;
                    radioButton9.Enabled = true;
                    radioButton10.Enabled = true;
                    listBox5.Enabled = true;
                    listBox5.SetSelected(0, true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("You need to place " + ybi_dec_file + " in the same folder as the YBi Tool");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int index = listBox5.SelectedIndex;
            if (listBox5.Items.Count != 0 && textBox24.Text.Length != 0)
            {
                writeValuePositions.setAbName(index, ybi_dec_file, textBox23.Text);
                writeValuePositions.setAbDesc(index, ybi_dec_file, textBox17.Text);
                writeValuePositions.setAbDesc2(index, ybi_dec_file, textBox18.Text);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (File.Exists(ybi_dec_file))
            {
                button11.Text = "Reload";
                byte[] YbiByteArray = Ybi2ByteArray(ybi_dec_file);

                listBox7.Items.Clear();

                try
                {
                    int pos = BanName_Offset;
                    while (true)
                    {
                        int pid = byteToInt32(YbiByteArray, pos);
                        if (pid == 0) break;

                        string badWord = byteToString(YbiByteArray, pos, BanName_BytesLenght);
                        listBox7.Items.Add(badWord);

                        pos += BanBytesOfSeparation;
                    }
                    button21.Enabled = true;
                    textBox31.Enabled = true;
                    textBox32.Enabled = true;
                    listBox7.Enabled = true;
                    listBox7.SetSelected(0, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("You need to place " + ybi_dec_file + " in the same folder as the YBi Tool");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (listBox7.Items.Count != 0 && textBox31.Text.Length != 0)
            {
                int index = listBox7.SelectedIndex;

                writeValuePositions.setBan_Name(index, ybi_dec_file, textBox32.Text);
                writeValuePositions.setBan_Desc(index, ybi_dec_file, textBox31.Text);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                try
                {
                    if (textBox21.Text.Length != 0)
                    {
                        int index = NpcIDBox.FindStringExact(textBox21.Text);
                        if (index != -1)
                        {
                            listBox4.SetSelected(index, true);
                        }
                        else
                        {
                            MessageBox.Show("Could not find Npc ID.");
                        }
                    }
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show(_Exception.ToString());
                }
            }
            else if (radioButton8.Checked)
            {
                try
                {
                    if (textBox22.Text.Length != 0)
                    {
                        int index = listBox4.FindStringExact(textBox22.Text);
                        if (index != -1)
                        {
                            listBox4.SetSelected(index, true);
                        }
                        else
                        {
                            MessageBox.Show("Could not find Npc Name.");
                        }
                    }
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show(_Exception.ToString());
                }
            }
            else if (!radioButton7.Checked && !radioButton8.Checked)
            {
                MessageBox.Show("Please select a search method.");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            AddCreds ac = new AddCreds();
            if (openForm == 0)
            {
                openForm = 1;
                ac.Show();
            }
            else
            {
                MessageBox.Show("Another window is already open!");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (File.Exists(ybi_dec_file))
            {
                button26.Text = "Reload";
                byte[] YbiByteArray = Ybi2ByteArray(ybi_dec_file);

                listBox8.Items.Clear();

                try
                {
                    int pos = ClassName_Offset;
                    while (true)
                    {
                        int pid = byteToInt32(YbiByteArray, pos);
                        if (pid == 0) break;

                        string className = byteToString(YbiByteArray, pos, ClassName_BytesLenght);
                        listBox8.Items.Add(className);

                        pos += ClassBytesOfSeparation;
                    }
                    button27.Enabled = true;
                    textBox37.Enabled = true;
                    listBox8.Enabled = true;
                    listBox8.SetSelected(0, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("You need to place " + ybi_dec_file + " in the same folder as the YBi Tool");
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (listBox8.Items.Count != 0 && textBox37.Text.Length != 0)
            {
                int index = listBox8.SelectedIndex;

                writeValuePositions.setClassName(index, ybi_dec_file, textBox37.Text);
            }
        }
        #endregion

        #region TextBox's KeyPress & TextChanged Region
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                textBox3.Text = "0";
            if (int.Parse(textBox3.Text) > 255)
                textBox3.Text = "255";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                textBox4.Text = "0";
            if (int.Parse(textBox4.Text) > 255)
                textBox4.Text = "255";
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                textBox5.Text = "0";
            if (int.Parse(textBox5.Text) > 65535)
                textBox5.Text = "65535";
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
                textBox6.Text = "0";
            if (int.Parse(textBox6.Text) > 65535)
                textBox6.Text = "65535";
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
                textBox10.Text = "0";
            if (long.Parse(textBox10.Text) > 4294967295)
                textBox10.Text = "4294967295";
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

        private void button18_Click(object sender, EventArgs e)
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            int pos = ItemID_Offset;
            int index = 0;
            while (true)
            {
                int pid = byteToInt32(MergeByteArray, pos);
                int pid_ = byteToInt32(YbiByteArray, pos);
                if (pid + pid_ == 0) break;

                string itemID = BitConverter.ToString(MergeByteArray, pos, ItemID_BytesLenght);
                string[] strArrayID = itemID.Split(new char[] { '-' });
                string reversedID = strArrayID[3] + strArrayID[2] + strArrayID[1] + strArrayID[0];

                string itemID_ = BitConverter.ToString(YbiByteArray, pos, ItemID_BytesLenght);
                string[] strArrayID_ = itemID_.Split(new char[] { '-' });
                string reversedID_ = strArrayID_[3] + strArrayID_[2] + strArrayID_[1] + strArrayID_[0];

                string itemName = byteToString(MergeByteArray, pos + ItemNameToID_BytesLenght, ItemName_BytesLenght);
                string itemName_ = byteToString(YbiByteArray, pos + ItemNameToID_BytesLenght, ItemName_BytesLenght);
                string itemDesc = byteToString(MergeByteArray, pos + ItemDesc_BytesLenght, ItemName_BytesLenght);



                M_ItemIDBox.Items.Add(this.hex2dec(reversedID));
                M_ItemNameBox.Items.Add(itemName);
                M_ItemDescBox.Items.Add(itemDesc);

                int iid = Convert.ToInt32(ItemIDBox.Items[index].ToString());
                int id = Convert.ToInt32(M_ItemIDBox.Items[index].ToString());
                string name = M_ItemNameBox.Items[index].ToString();
                string desc = M_ItemDescBox.Items[index].ToString();

                if (id == iid)
                {
                    writeValuePositions.mergeItemName(index, ybi_dec_file, name);
                    writeValuePositions.mergeItemDesc(index, ybi_dec_file, desc);
                }
                else { MessageBox.Show("Error!"); }

                pos += ItemBytesOfSeparation;
                index += 1;
            }
        }
    }
}
