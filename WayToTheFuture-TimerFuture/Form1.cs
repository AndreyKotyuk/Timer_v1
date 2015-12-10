using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WayToTheFuture_TimerFuture
{
    public partial class Timer : Form
    {
        public int editrows = 0;
        public Timer()
        {
            InitializeComponent();
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetClientSizeCore(886, 251);
        }
       
        public int row = 0;
        public int value = 0;
        public List<int> valarr = new List<int>() { };

        private void button1_Click(object sender, EventArgs e)
        {
            this.SetClientSizeCore(886,343);
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            button1.Visible = false; //Делаем кнопки видимыми
        }

        public void Cl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            this.SetClientSizeCore(886, 251);
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button1.Visible = true; //Прячем кнопки
            box4 = 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if ((!(String.IsNullOrEmpty(textBox3.Text))) && (!(String.IsNullOrEmpty(textBox4.Text))) && (!(String.IsNullOrEmpty(textBox5.Text))))
            {
                data.Rows.Add(1);
                data.Rows[row].HeaderCell.Value = row + 1;
                data.Rows[row].Cells[0].Value = textBox1.Text;
                data.Rows[row].Cells[1].Value = textBox2.Text;
                data.Rows[row].Cells[2].Value = textBox3.Text;
                data.Rows[row].Cells[3].Value = textBox4.Text;
                try
                {
                    value = Convert.ToInt32(textBox5.Text);
                    valarr.Add(value);
                }
                catch { };
                row++;


                editrows++;
                timer1.Enabled = true;
                box4 = 0;

                Cl();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
        private void button14_Click(object sender, EventArgs e)
        {

            textBox3.Text = System.DateTime.Now.ToShortTimeString();
        }

        public int box4 = 0;

        private void button10_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(textBox3.Text)))
            {
                if (box4 == 0)
                {
                    box4++;
                    textBox4.Text = Convert.ToString(Convert.ToInt32(textBox3.Text.Remove(textBox3.Text.IndexOf(":"))) + 1) + Convert.ToString(textBox3.Text.Substring(textBox3.Text.IndexOf(":")));
                }
                else
                {
                    textBox4.Text = Convert.ToString(Convert.ToInt32(textBox4.Text.Remove(textBox4.Text.IndexOf(":"))) + 1) + Convert.ToString(textBox4.Text.Substring(textBox4.Text.IndexOf(":")));
                }
            }
        }

        public void Time(int rw)
        {
            data.Rows[rw].Cells[4].Value = Convert.ToInt32(data.Rows[rw].Cells[3].Value.ToString().Substring(0, data.Rows[rw].Cells[3].Value.ToString().IndexOf(":"))) * 60 + Convert.ToInt32(data.Rows[rw].Cells[3].Value.ToString().Substring(data.Rows[rw].Cells[3].Value.ToString().IndexOf(":") + 1)) - (Convert.ToInt32(data.Rows[rw].Cells[2].Value.ToString().Substring(0, System.DateTime.Now.ToShortTimeString().ToString().IndexOf(":"))) * 60 + Convert.ToInt32(System.DateTime.Now.ToShortTimeString().ToString().Substring(System.DateTime.Now.ToShortTimeString().ToString().IndexOf(":") + 1)));
            data.Rows[rw].Cells[5].Value = Convert.ToInt32(System.DateTime.Now.ToShortTimeString().ToString().Substring(0, System.DateTime.Now.ToShortTimeString().ToString().IndexOf(":"))) * 60 + Convert.ToInt32(System.DateTime.Now.ToShortTimeString().ToString().Substring(System.DateTime.Now.ToShortTimeString().ToString().IndexOf(":") + 1)) - (Convert.ToInt32(data.Rows[rw].Cells[2].Value.ToString().Substring(0, data.Rows[rw].Cells[2].Value.ToString().IndexOf(":"))) * 60 + Convert.ToInt32(data.Rows[rw].Cells[2].Value.ToString().Substring(data.Rows[rw].Cells[2].Value.ToString().IndexOf(":") + 1)));
            data.Rows[rw].Cells[6].Value = Convert.ToInt32(data.Rows[rw].Cells[5].Value) * valarr[rw]; ;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < editrows; i++)
            {
                Time(i);
                //data.Rows[0].Cells[4].Value = Convert.ToInt32(data.Rows[0].Cells[3].Value.ToString().Substring(0, data.Rows[0].Cells[3].Value.ToString().IndexOf(":"))) * 60 + Convert.ToInt32(data.Rows[0].Cells[3].Value.ToString().Substring(data.Rows[0].Cells[3].Value.ToString().IndexOf(":") + 1)) - (Convert.ToInt32(data.Rows[0].Cells[2].Value.ToString().Substring(0, System.DateTime.Now.ToShortTimeString().ToString().IndexOf(":"))) * 60 + Convert.ToInt32(System.DateTime.Now.ToShortTimeString().ToString().Substring(System.DateTime.Now.ToShortTimeString().ToString().IndexOf(":") + 1)));
                //data.Rows[0].Cells[5].Value = Convert.ToInt32(data.Rows[0].Cells[2].Value.ToString().Substring(0, System.DateTime.Now.ToShortTimeString().ToString().IndexOf(":"))) * 60 + Convert.ToInt32(System.DateTime.Now.ToShortTimeString().ToString().Substring(System.DateTime.Now.ToShortTimeString().ToString().IndexOf(":") + 1)) - (Convert.ToInt32(data.Rows[0].Cells[2].Value.ToString().Substring(0, data.Rows[0].Cells[2].Value.ToString().IndexOf(":"))) * 60 + Convert.ToInt32(data.Rows[0].Cells[2].Value.ToString().Substring(data.Rows[0].Cells[2].Value.ToString().IndexOf(":") + 1)));
                //data.Rows[0].Cells[6].Value = Convert.ToInt32(data.Rows[0].Cells[5].Value) * value;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (row != 0)
            {
                textBox5.Text = Convert.ToString(value);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Cl();
        }
    }
}
