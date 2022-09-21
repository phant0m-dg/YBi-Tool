using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ybi
{
    public partial class AddCreds : Form
    {
        public AddCreds()
        {
            InitializeComponent();
        }

        private string hex2dec(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(long.Parse(hexString, System.Globalization.NumberStyles.HexNumber));
            return sb.ToString();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form1.openForm = 0;
            e.Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();

            int posID = 8;
            int posDesc = 124;
            int count = 0;
            int credLenght = textBox1.Text.Length;
            while (true)
            {
                int pid = Form1.byteToInt32(Form1.YbiByteArray, posID);
                if (pid == 0) break;

                byte[] str2array = System.Text.Encoding.Default.GetBytes("^" + textBox1.Text);

                try
                {
                    BinaryWriter bw = new BinaryWriter(File.Open(Form1.ybi_dec_file, FileMode.Open));
                    bw.BaseStream.Seek(posDesc + 255 - credLenght, SeekOrigin.Begin);
                    
                    bw.Write(str2array);
                    bw.Close();
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show(_Exception.ToString());
                }

                posID += 808;
                posDesc += 808;
                count++;
            }

            MessageBox.Show("Credit '" + textBox1.Text + "' has been added to the items.");
            textBox1.Text = "";
            this.Close();
        }
    }
}
