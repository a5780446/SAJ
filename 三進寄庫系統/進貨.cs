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
    public partial class 進貨 : Form
    {
        public 進貨()
        {
            InitializeComponent();
        }

        private void 進貨_Load(object sender, EventArgs e)
        {
            label1.Text = Chart.ID;  //流水編號
            textBox2.Enabled = false;
            panel1.Visible = false;

            SqlConnection conn = new SqlConnection(Chart.cn);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select unit from a where id='{label1.Text}'", conn);
            SqlCommand cmd1 = new SqlCommand($"select price from a where id='{label1.Text}'", conn);
            SqlCommand cmd8 = new SqlCommand($"select qty from a where id='{label1.Text}'", conn);
            cmd8.ExecuteNonQuery();
            label8.Text = cmd8.ExecuteScalar().ToString();  //商品剩餘數量
            cmd.ExecuteNonQuery();
            label5.Text = cmd.ExecuteScalar().ToString();  //商品單位
            cmd1.ExecuteNonQuery();
            textBox3.Text = cmd1.ExecuteScalar().ToString();
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = (float.Parse(textBox1.Text) * float.Parse(textBox3.Text)).ToString();
            }
            catch
            {

            }

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = (float.Parse(textBox1.Text) * float.Parse(textBox3.Text)).ToString();
            }
            catch
            {

            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(textBox1.Text) >= float.Parse(label8.Text))
                {
                    DialogResult ans;
                    ans = MessageBox.Show("允許此筆結案?", "警告", MessageBoxButtons.YesNo);
                    if (ans == DialogResult.Yes)
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection(Chart.cn);
                            con.Open();
                            SqlCommand cd = new SqlCommand($"update a set qty=qty-{textBox1.Text},state=N'結案' where id=N'{label1.Text}' ", con); 
                            SqlCommand cmd1 = new SqlCommand("insert into b (log_id,indate,inqty,inprice,leftqty,intotal) values(@dd,@進日,@進量,@進錢,@剩量,@進總)", con);
                            cmd1.Parameters.Add("@dd", SqlDbType.NVarChar, 50).Value = label1.Text;
                            cmd1.Parameters.Add("@進日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                            cmd1.Parameters.Add("@進量", SqlDbType.Float).Value = textBox1.Text;
                            cmd1.Parameters.Add("@進錢", SqlDbType.Float).Value = textBox3.Text;
                            cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = float.Parse(label8.Text) - float.Parse(textBox1.Text);
                            cmd1.Parameters.Add("@進總", SqlDbType.Float).Value = textBox2.Text;
                            cd.ExecuteNonQuery();
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("進貨成功");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {

                    }

                }
                else
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(Chart.cn);
                        con.Open();
                        SqlCommand cd = new SqlCommand($"update a set qty=qty-{textBox1.Text} where id=N'{label1.Text}' ", con);
                        SqlCommand cmd1 = new SqlCommand("insert into b (log_id,indate,inqty,inprice,leftqty,intotal) values(@dd,@進日,@進量,@進錢,@剩量,@進總)", con);
                        cmd1.Parameters.Add("@dd", SqlDbType.NVarChar, 50).Value = label1.Text;
                        cmd1.Parameters.Add("@進日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                        cmd1.Parameters.Add("@進量", SqlDbType.Float).Value = textBox1.Text;
                        cmd1.Parameters.Add("@進錢", SqlDbType.Float).Value = textBox3.Text;
                        cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = float.Parse(label8.Text) - float.Parse(textBox1.Text);
                        cmd1.Parameters.Add("@進總", SqlDbType.Float).Value = textBox2.Text;
                        cd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("進貨成功");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
            }
        }
    }
}
