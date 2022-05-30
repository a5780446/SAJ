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
    public partial class 新增 : Form
    {
        public 新增()
        {
            InitializeComponent();
        }

        string x = DateTime.Now.ToString("yyyyMMdd" + "01");//真的今天日期
        
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = (float.Parse(textBox5.Text) * float.Parse(textBox6.Text)).ToString();
            }
            catch(Exception ex)
            {
                
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = (float.Parse(textBox5.Text) * float.Parse(textBox6.Text)).ToString();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Chart.cn);   //新增a
                conn.Open();
                SqlCommand cmd = new SqlCommand($"insert into a (id,pnum,pname,fomat,price,qty,unit,date,remark,total,class,vname,claas) values(@id,@品號,@品名,@規格,@價錢,@數量,@單位,@日期,@備註,@總金額,@類別,@廠商,@類型)",conn);
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = label13.Text;
                cmd.Parameters.Add("@品號", SqlDbType.NVarChar, 50).Value = textBox1.Text;
                cmd.Parameters.Add("@品名", SqlDbType.NVarChar, 50).Value = textBox2.Text;
                cmd.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = textBox4.Text;
                cmd.Parameters.Add("@價錢", SqlDbType.Float).Value = textBox5.Text;
                cmd.Parameters.Add("@數量", SqlDbType.Float).Value = textBox6.Text;
                cmd.Parameters.Add("@單位", SqlDbType.NVarChar, 50).Value = comboBox1.Text;
                cmd.Parameters.Add("@日期", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                cmd.Parameters.Add("@備註", SqlDbType.NVarChar, 225).Value = richTextBox1.Text;
                cmd.Parameters.Add("@總金額", SqlDbType.Float).Value = textBox7.Text;
                cmd.Parameters.Add("@類別", SqlDbType.NVarChar, 50).Value = label14.Text;
                cmd.Parameters.Add("@廠商", SqlDbType.NVarChar, 50).Value = textBox3.Text;
                cmd.Parameters.Add("@類型", SqlDbType.NVarChar, 50).Value = label14.Text;
                //cmd.Parameters.Add("@重", SqlDbType.Float).Value = textBox6.Text;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("insert into b (log_id,indate,leftqty,informat) values(@dd,@進日,@剩量,@歸歸)", conn);
                cmd1.Parameters.Add("@dd", SqlDbType.NVarChar, 50).Value = label13.Text;
                cmd1.Parameters.Add("@進日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = textBox6.Text;
                cmd1.Parameters.Add("@歸歸", SqlDbType.NVarChar, 50).Value = textBox4.Text;
                cmd1.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("新增成功");


                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 新增_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label14.Text = "其他類";
            label10.Text = x;
            SqlConnection con = new SqlConnection(Chart.cn);
            con.Open();
            SqlCommand cd = new SqlCommand($"select top(1) id from a order by id DESC ",con);  //須注意排序
            cd.ExecuteNonQuery();
            string y =cd.ExecuteScalar().ToString();
            label11.Text = y;
            string z = y.Substring(x.Length - 2);
            label12.Text = z;
            con.Close();


            if (string.Compare(y, x, true) == -1) //比對string
            {
                //Console.WriteLine("如果[不]等於今天顯示" 
                label13.Text= DateTime.Now.ToString("yyyyMMdd" + "01");
            }
            else
            {
                int i = Convert.ToInt32(z);
                int i1 = i + 1;
                string ans = i1.ToString();
                label13.Text=(DateTime.Now.ToString("yyyyMMdd" + int.Parse(ans).ToString("00")));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
