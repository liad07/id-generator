using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace id_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }



        static bool IsIsraeliIdNumber(string id)
        {
            id = id.Trim();
            if (id.Length > 9 || !int.TryParse(id, out _)) return false;
            id = id.Length < 9 ? ("00000000" + id).Substring(id.Length - 9) : id;
            return id.Select(c => int.Parse(c.ToString()))
            .Select((digit, i) =>
            {
                var step = digit * ((i % 2) + 1);
                return step > 9 ? step - 9 : step;
            }).Sum() % 10 == 0;
        }
        static string GenerateValidIsraeliIdNumber()
        {
            var random = new Random();
            var id = new string(Enumerable.Repeat("0", 9).Select(s => (char)('0' + random.Next(10))).ToArray());
            while (!IsIsraeliIdNumber(id))
            {
                id = new string(Enumerable.Repeat("0", 9).Select(s => (char)('0' + random.Next(10))).ToArray());
            }
            return id;
        }

       


        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            var idNumbers = Enumerable.Range(0, int.Parse(textBox1.Text)).Select(i => GenerateValidIsraeliIdNumber()).ToArray();
            for(int i=0;i< int.Parse(textBox1.Text); i++)
            {
               
                if (i % 3 == 0)
                {
              
                    richTextBox1.Text += "\n";
                    richTextBox1.Text += idNumbers[i] + ",";
                  

                }
                else
                {
                    richTextBox1.Text += idNumbers[i]+",";
                }
            }
            string text = richTextBox1.Text;
            int index = text.IndexOf("\n");
            if (index >= 0)
            {
                text = text.Remove(index, 1).Insert(index, "");
                richTextBox1.Text = text;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
