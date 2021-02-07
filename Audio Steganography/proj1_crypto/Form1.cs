using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.IO;

namespace proj1_crypto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            textBox1.Text = open.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Open File";
            save.Filter = "All File (*.*)|*.*";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(File.Create(save.FileName));
                write.Write(textBox1.Text);
                write.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.URL = textBox1.Text;
            axWindowsMediaPlayer1.Ctlcontrols.play();
  
        }


        string ciperdata;
        byte[] ciperbyte;
        byte[] plaintext;
        byte[] plainbyte;
        byte[] key;

        SymmetricAlgorithm sym = Rijndael.Create();

        private void button4_Click(object sender, EventArgs e)
        {
            ciperdata = textBox2.Text;
            plaintext = Encoding.ASCII.GetBytes(ciperdata);
            key = Encoding.ASCII.GetBytes("0123456789abcdef");
            sym.Key = key;
            sym.Mode = CipherMode.CBC;
            sym.Padding = PaddingMode.PKCS7;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, sym.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(plaintext, 0, plaintext.Length);
            cs.Close();
            ciperbyte = ms.ToArray();
            ms.Close();
            textBox3.Text = Encoding.ASCII.GetString(ciperbyte);
            MessageBox.Show("Message has been encrypted successfully...!");
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
