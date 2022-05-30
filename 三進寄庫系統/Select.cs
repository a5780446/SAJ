using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 三進寄庫系統
{
    public partial class Select : Form
    {
        public Select()
        {
            InitializeComponent();
        }
        新增鐵材類 g1;
        新增 g2;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g1 = new 新增鐵材類();
            g1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g2 = new 新增();
            g2.Show();
            this.Close();
        }

        private void Select_Load(object sender, EventArgs e)
        {

        }
    }
}
