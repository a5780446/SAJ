using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 三進寄庫系統
{
    public partial class 修改 : Form
    {
        public 修改()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 修改_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Chart.cn);
                conn.Open();
                SqlCommand cmd1 = new SqlCommand($"select pnum from a where id='{Chart.ID}'", conn);
                cmd1.ExecuteNonQuery();
                textBox1.Text = cmd1.ExecuteScalar().ToString();
                SqlCommand cmd2 = new SqlCommand($"select pname from a where id='{Chart.ID}'", conn);
                cmd2.ExecuteNonQuery();
                textBox2.Text = cmd2.ExecuteScalar().ToString();
                SqlCommand cmd3 = new SqlCommand($"select thin from a where id='{Chart.ID}'", conn);
                cmd3.ExecuteNonQuery();
                textBox3.Text = cmd3.ExecuteScalar().ToString();
                SqlCommand cmd4 = new SqlCommand($"select fomat from a where id='{Chart.ID}'", conn);
                cmd4.ExecuteNonQuery();
                textBox4.Text = cmd4.ExecuteScalar().ToString();
                SqlCommand cmd5 = new SqlCommand($"select date from a where id='{Chart.ID}'", conn);
                cmd5.ExecuteNonQuery();
                dateTimePicker1.Text = cmd5.ExecuteScalar().ToString();
                SqlCommand cmd6 = new SqlCommand($"select remark from a where id='{Chart.ID}'", conn);
                cmd6.ExecuteNonQuery();
                richTextBox1.Text = cmd6.ExecuteScalar().ToString();
                SqlCommand cmd7 = new SqlCommand($"select mark from a where id='{Chart.ID}'", conn);
                cmd7.ExecuteNonQuery();
                textBox5.Text = cmd7.ExecuteScalar().ToString();
                conn.Close();

            }catch(Exception ex)
            {
                MessageBox.Show("未指定項目");
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Chart.cn);
                con.Open();
                SqlCommand cmd = new SqlCommand($"update a set pnum='{textBox1.Text}',pname=N'{textBox2.Text}',thin='{textBox3.Text}',fomat='{textBox4.Text}',date='{dateTimePicker1.Value.ToShortDateString()}',mark=N'{textBox5.Text}',remark=N'{richTextBox1.Text}' where id='{Chart.ID}' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("修改成功");
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
