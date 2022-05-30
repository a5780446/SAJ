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
    public partial class 新增鐵材類 : Form
    {
        public 新增鐵材類()
        {
            InitializeComponent();
        }
        string x = DateTime.Now.ToString("yyyyMMdd" + "01");//真的今天日期

        private void button1_Click(object sender, EventArgs e)
        {
            if (label18.Text == "")
            {
                MessageBox.Show("請選擇寄庫類型");
                label17.Visible = true;
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Chart.cn);   //新增a
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"insert into a (id,pnum,pname,thin,fomat,price,qty,unit,date,remark,total,class,vname,claas,mark) values(@id,@品號,@品名,@厚,@規格,@價錢,@數量,@單位,@日期,@備註,@總金額,@類別,@廠商,@類型,@合約號)", conn);
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = label13.Text;
                    cmd.Parameters.Add("@品號", SqlDbType.NVarChar, 50).Value = textBox1.Text;
                    cmd.Parameters.Add("@品名", SqlDbType.NVarChar, 50).Value = comboBox3.Text +"-"+ textBox2.Text;
                    cmd.Parameters.Add("@厚", SqlDbType.NVarChar, 50).Value = textBox3.Text;
                    cmd.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = textBox4.Text;
                    cmd.Parameters.Add("@價錢", SqlDbType.Float).Value = textBox5.Text;
                    cmd.Parameters.Add("@數量", SqlDbType.Float).Value = textBox6.Text;
                    cmd.Parameters.Add("@單位", SqlDbType.NVarChar, 50).Value = comboBox1.Text;
                    cmd.Parameters.Add("@日期", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                    cmd.Parameters.Add("@備註", SqlDbType.NVarChar, 225).Value = richTextBox1.Text;
                    cmd.Parameters.Add("@總金額", SqlDbType.Float).Value = textBox7.Text;
                    cmd.Parameters.Add("@類別", SqlDbType.NVarChar, 50).Value = label99.Text;
                    cmd.Parameters.Add("@廠商", SqlDbType.NVarChar, 50).Value = comboBox2.Text;
                    cmd.Parameters.Add("@類型", SqlDbType.NVarChar, 50).Value = label18.Text;
                    cmd.Parameters.Add("@合約號", SqlDbType.NVarChar, 50).Value = textBox8.Text;
                    //cmd.Parameters.Add("@重", SqlDbType.Float).Value = textBox6.Text;
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("insert into b (log_id,indate,leftqty,informat) values(@dd,@進日,@剩量,@歸歸)", conn);
                    cmd1.Parameters.Add("@dd", SqlDbType.NVarChar, 50).Value = label13.Text;
                    cmd1.Parameters.Add("@進日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                    cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = textBox6.Text;
                    cmd1.Parameters.Add("@歸歸", SqlDbType.NVarChar, 50).Value = comboBox3.Text + "-" + textBox2.Text; ;
                    cmd1.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand("insert into cc (ctid,ctmark,ctwei,ctprice,cttotalprice,state,ctdate) values(@水號,@合約號,@合約重量,@合約價,@預收金,@狀態,@帳月)", conn);
                    cmd2.Parameters.Add("@水號", SqlDbType.NVarChar, 50).Value = label13.Text;
                    cmd2.Parameters.Add("@合約號", SqlDbType.NVarChar, 50).Value = textBox8.Text;
                    cmd2.Parameters.Add("@合約重量", SqlDbType.Float).Value = textBox6.Text;
                    cmd2.Parameters.Add("@合約價", SqlDbType.Float).Value = textBox5.Text;
                    cmd2.Parameters.Add("@預收金", SqlDbType.Float).Value = textBox7.Text;
                    cmd2.Parameters.Add("@狀態", SqlDbType.NVarChar, 50).Value = "未出完";
                    cmd2.Parameters.Add("@帳月", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToString("yyyy-MM");
                    cmd2.ExecuteNonQuery();


                    conn.Close();
                    MessageBox.Show("新增成功");


                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void 新增鐵材類_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label18.Text = "";
            label99.Text = "鐵材類";
            label10.Text = x;
            SqlConnection con = new SqlConnection(Chart.cn);
            con.Open();
            SqlCommand cd = new SqlCommand($"select top(1) id from a order by id DESC ", con);  //須注意排序
            
            //cd.ExecuteNonQuery();
            
            string y = cd.ExecuteScalar().ToString();
            label11.Text = y;
            string z = y.Substring(x.Length - 2);
            label12.Text = z;
            //comboBox2.Items.Add(cm.ExecuteScalar().ToString());
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand($"select DISTINCT vname from a where class=N'鐵材類'", con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    for(int i = 0; i < rd.FieldCount; i++)
                    {
                        comboBox2.Items.Add(rd[i].ToString());
                    }
                }
            }
            con.Close();


            if (string.Compare(y, x, true) == -1) //比對string
            {
                //Console.WriteLine("如果[不]等於今天顯示" 
                label13.Text = DateTime.Now.ToString("yyyyMMdd" + "01");
            }
            else
            {
                int i = Convert.ToInt32(z);
                int i1 = i + 1;
                string ans = i1.ToString();
                label13.Text = (DateTime.Now.ToString("yyyyMMdd" + int.Parse(ans).ToString("00")));
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = (float.Parse(textBox5.Text) * float.Parse(textBox6.Text)).ToString();
            }
            catch (Exception ex)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label18.Text = "板材";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label18.Text = "角鋼";
            }
        }
    }
    
}
