using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wk5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.KeyPress += TextBox1_KeyPress;
            this.textBox2.KeyPress += TextBox2_KeyPress;

        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只能輸入數字
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只能輸入數字
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            int total = 0;
            double people_num = 0;
            int child_num = 0;
            int free_man = 0;
            int free_money = 0;
            int man_fee = 0;
            int man_num = 0;
            int child_fee = 0;
            int count95 = 0;

            if (radioButton3.Checked == true && radioButton1.Checked == true)
            {
                man_fee = 268;
                child_fee = 120;
            }
            else
            {
                man_fee = 368;
                child_fee = 150;
            }

            people_num = int.Parse(textBox1.Text) + int.Parse(textBox2.Text);
            child_num = int.Parse(textBox2.Text);
            man_num = int.Parse(textBox1.Text);
            free_man = Convert.ToInt16(Math.Floor((people_num / 3)));
            if (free_man!=0)
            {
                if (free_man<=child_num)
                {
                    free_money = child_fee * child_num;
                }
                else
                {
                    free_money = child_num * child_fee + (free_man - child_num) * man_fee;
                }
            }
            else
            {
                free_money = 0;
            }
            free_label.Text =string.Format("{0}",free_money);
            label11.Text = string.Format("{0}", child_fee * child_num);
            label12.Text = string.Format("{0}", man_fee * man_num);
            total = man_fee * man_num + child_fee * child_num - free_money;
            if (people_num >=10)
            {
                count95 = total * 5 / 100;
            }
            label15.Text = string.Format("{0}", count95);
            label18.Text = string.Format("{0}", total - count95);

        }
    }
}
