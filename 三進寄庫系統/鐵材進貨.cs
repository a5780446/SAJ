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
    public partial class 鐵材進貨 : Form
    {
        public 鐵材進貨()
        {
            InitializeComponent();
        }

        private void 鐵材進貨_Load(object sender, EventArgs e)
        {
            label1.Text = Chart.ID;
            label14.Text = Chart.cla;
            panel1.Visible = false;

            SqlConnection conn = new SqlConnection(Chart.cn);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select unit from a where id='{label1.Text}'", conn);
            SqlCommand cmd1=new SqlCommand($"select thin from a where id='{label1.Text}'", conn);
            SqlCommand cmd2 = new SqlCommand($"select qty from a where id='{label1.Text}'", conn);
            SqlCommand cmd3 = new SqlCommand($"select price from a where id='{label1.Text}'", conn);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            label20.Text = cmd.ExecuteScalar().ToString();
            label24.Text = cmd.ExecuteScalar().ToString();
            label21.Text = cmd1.ExecuteScalar().ToString();
            label22.Text = cmd2.ExecuteScalar().ToString();
            label77.Text = cmd3.ExecuteScalar().ToString();
            numericUpDown3.Value = decimal.Parse(label21.Text);
            conn.Close();

            if (label14.Text == "板材")
            {
                groupBox2.Enabled = false;
                //textBox3.Text = label77.Text;
            }
            else
            {
                groupBox1.Enabled = false;
                textBox5.Text = label77.Text;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = (float.Parse(textBox1.Text) * float.Parse(textBox2.Text)).ToString("0.0");
                
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = (float.Parse(textBox1.Text) * float.Parse(textBox2.Text)).ToString("0.0");
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox2.Enabled == false)  //進板材
            {
                try
                {
                    if (float.Parse(textBox1.Text) >= float.Parse(label22.Text))
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
                                SqlCommand cmd1 = new SqlCommand("insert into b (log_id,indate,inqty,inprice,leftqty,intotal,inmark,informat) values(@dd,@進日,@進量,@進錢,@剩量,@進總,@備註,@規格)", con);
                                cmd1.Parameters.Add("@dd", SqlDbType.NVarChar, 50).Value = label1.Text;
                                cmd1.Parameters.Add("@進日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                                cmd1.Parameters.Add("@進量", SqlDbType.Float).Value = textBox1.Text;
                                cmd1.Parameters.Add("@進錢", SqlDbType.Float).Value = textBox2.Text;
                                cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = float.Parse(label22.Text) - float.Parse(textBox1.Text);
                                cmd1.Parameters.Add("@進總", SqlDbType.Float).Value = textBox3.Text;
                                cmd1.Parameters.Add("@備註", SqlDbType.NVarChar, 50).Value = richTextBox1.Text;
                                cmd1.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = numericUpDown1.Value + "*" + numericUpDown2.Value + "-" + textBox7.Text+"T".ToString();
                                cd.ExecuteNonQuery();
                                cmd1.ExecuteNonQuery();

                                SqlCommand cmd2 = new SqlCommand($"update cc set cttotalwei=(select sum(inqty) from b where log_id='{label1.Text}'),ctpay=(select sum(intotal) from b where log_id='{label1.Text}'),state=N'已出完' where ctid='{label1.Text}'", con);
                                cmd2.ExecuteNonQuery();
                                SqlCommand cmd3 = new SqlCommand($"update cc set ctq=abs(ctpay-cttotalprice) where ctid={label1.Text}",con);
                                cmd3.ExecuteNonQuery();
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
                            SqlCommand cmd1 = new SqlCommand("insert into b (log_id,indate,inqty,inprice,leftqty,intotal,inmark,informat) values(@dd,@進日,@進量,@進錢,@剩量,@進總,@備註,@規格)", con);
                            cmd1.Parameters.Add("@dd", SqlDbType.NVarChar, 50).Value = label1.Text;
                            cmd1.Parameters.Add("@進日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                            cmd1.Parameters.Add("@進量", SqlDbType.Float).Value = textBox1.Text;
                            cmd1.Parameters.Add("@進錢", SqlDbType.Float).Value = textBox2.Text;
                            cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = float.Parse(label22.Text) - float.Parse(textBox1.Text);
                            cmd1.Parameters.Add("@進總", SqlDbType.Float).Value = textBox3.Text;
                            cmd1.Parameters.Add("@備註", SqlDbType.NVarChar, 50).Value = richTextBox1.Text;
                            cmd1.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = numericUpDown1.Value + "*" + numericUpDown2.Value + "-" + textBox7.Text+"T".ToString();
                            cd.ExecuteNonQuery();
                            cmd1.ExecuteNonQuery();
                            SqlCommand cmd2 = new SqlCommand($"update cc set cttotalwei=(select sum(inqty) from b where log_id='{label1.Text}'),ctpay=(select sum(intotal) from b where log_id='{label1.Text}') where ctid='{label1.Text}'", con);
                            cmd2.ExecuteNonQuery();
                            SqlCommand cmd3 = new SqlCommand($"update cc set ctq=abs(ctpay-cttotalprice) where ctid={label1.Text}", con);
                            cmd3.ExecuteNonQuery();
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else   //進角鋼
            {
                try
                {
                    if (float.Parse(textBox6.Text) >= float.Parse(label22.Text))
                    {
                        DialogResult ans;
                        ans = MessageBox.Show("允許此筆結案?", "警告", MessageBoxButtons.YesNo);
                        if (ans == DialogResult.Yes)
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection(Chart.cn);
                                con.Open();
                                SqlCommand cd = new SqlCommand($"update a set qty=qty-{textBox6.Text},state=N'結案' where id=N'{label1.Text}' ", con);
                                SqlCommand cmd1 = new SqlCommand("insert into b (log_id,indate,inqty,inprice,leftqty,intotal,inmark,informat) values(@dd,@進日,@進量,@進錢,@剩量,@進總,@備註,@規格)", con);
                                cmd1.Parameters.Add("@dd", SqlDbType.NVarChar, 50).Value = label1.Text;
                                cmd1.Parameters.Add("@進日", SqlDbType.NVarChar, 50).Value = dateTimePicker2.Value.ToShortDateString();
                                cmd1.Parameters.Add("@進量", SqlDbType.Float).Value = textBox6.Text;
                                cmd1.Parameters.Add("@進錢", SqlDbType.Float).Value = textBox5.Text;
                                cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = float.Parse(label22.Text) - float.Parse(textBox6.Text);
                                cmd1.Parameters.Add("@進總", SqlDbType.Float).Value = textBox4.Text;
                                cmd1.Parameters.Add("@備註", SqlDbType.NVarChar, 50).Value = richTextBox2.Text;
                                cmd1.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = numericUpDown4.Value + "," + numericUpDown5.Value + "-" + numericUpDown3.Value + "T-" + textBox8.Text + "M".ToString();
                                cd.ExecuteNonQuery();
                                cmd1.ExecuteNonQuery();
                                SqlCommand cmd2 = new SqlCommand($"update cc set cttotalwei=(select sum(inqty) from b where log_id='{label1.Text}'),ctpay=(select sum(intotal) from b where log_id='{label1.Text}'),state=N'已出完' where ctid='{label1.Text}'", con);
                                cmd2.ExecuteNonQuery();
                                SqlCommand cmd3 = new SqlCommand($"update cc set ctq=abs(ctpay-cttotalprice) where ctid={label1.Text}", con);
                                cmd3.ExecuteNonQuery();
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
                            SqlCommand cd = new SqlCommand($"update a set qty=qty-{textBox6.Text} where id=N'{label1.Text}' ", con);
                            SqlCommand cmd1 = new SqlCommand("insert into b (log_id,indate,inqty,inprice,leftqty,intotal,inmark,informat) values(@dd,@進日,@進量,@進錢,@剩量,@進總,@備註,@規格)", con);
                            cmd1.Parameters.Add("@dd", SqlDbType.NVarChar, 50).Value = label1.Text;
                            cmd1.Parameters.Add("@進日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                            cmd1.Parameters.Add("@進量", SqlDbType.Float).Value = textBox6.Text;
                            cmd1.Parameters.Add("@進錢", SqlDbType.Float).Value = textBox5.Text;
                            cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = float.Parse(label22.Text) - float.Parse(textBox6.Text);
                            cmd1.Parameters.Add("@進總", SqlDbType.Float).Value = textBox4.Text;
                            cmd1.Parameters.Add("@備註", SqlDbType.NVarChar, 50).Value = richTextBox2.Text;
                            cmd1.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = numericUpDown4.Value + "," + numericUpDown5.Value + "-" + numericUpDown3.Value + "T-" + textBox8.Text + "M".ToString();
                            cd.ExecuteNonQuery();
                            cmd1.ExecuteNonQuery();
                            SqlCommand cmd2 = new SqlCommand($"update cc set cttotalwei=(select sum(inqty) from b where log_id='{label1.Text}'),ctpay=(select sum(intotal) from b where log_id='{label1.Text}') where ctid='{label1.Text}'", con);
                            cmd2.ExecuteNonQuery();
                            SqlCommand cmd3 = new SqlCommand($"update cc set ctq=abs(ctpay-cttotalprice) where ctid={label1.Text}", con);
                            cmd3.ExecuteNonQuery();
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
            
            if (numericUpDown1.Value == 4)
            {
                if (textBox7.Text == "1.2")
                {
                    textBox2.Text = (float.Parse(label77.Text) + 1.5).ToString("0.0");
                }
                else if (textBox7.Text == "1.6")
                {
                    textBox2.Text = (float.Parse(label77.Text) + 0.5).ToString("0.0");
                }
                else
                {
                    textBox2.Text = label77.Text;
                }
            }
            else if (numericUpDown1.Value == 5)
            {
                if (textBox7.Text == "1.6")
                {
                    textBox2.Text = (float.Parse(label77.Text) + 0.7).ToString("0.0");
                }
                else if (textBox7.Text == "2" || textBox7.Text=="2.0")
                {
                    textBox2.Text = (float.Parse(label77.Text) + 0.3).ToString("0.0");
                }
                else
                {
                    textBox2.Text = label77.Text;
                }
            }
            else
            {
                
            }
            

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = (float.Parse(textBox6.Text) * float.Parse(textBox5.Text)).ToString("0.0");
            }
            catch
            {

            }
            
        }
    }
}
