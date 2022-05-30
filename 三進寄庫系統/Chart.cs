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
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "Wave.ssk";
        }
        
        Select f2;
        修改 f3;
        進貨 f4;
        鐵材進貨 f5;
        進貨紀錄 f6;


        public static string cn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\E倉管處\pup.mdf;Integrated Security=True;Connect Timeout=30";
        public static string ID;
        public static string cla;
        public static string sta;
        public static string mark;
        private void Chart_Load(object sender, EventArgs e)
        {

            label1.Text = "";
            label2.Visible = false;
            label3.Visible = false;
            SqlConnection con = new SqlConnection(cn);
            SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where state=N'未結案'", con);
            DataSet ds = new DataSet();
            sa.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                label1.Text = ID;
                richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["備註"].Value.ToString();

                cla = dataGridView1.Rows[e.RowIndex].Cells["類別"].Value.ToString();
                label2.Text = cla;
                label2.Visible = false;

                sta= dataGridView1.Rows[e.RowIndex].Cells["狀態"].Value.ToString();
                label3.Text = sta;
                label3.Visible = false;

                mark=dataGridView1.Rows[e.RowIndex].Cells["mark"].Value.ToString();
                label5.Text = mark;



            }
            catch (Exception ex)
            {

            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where class = N'鐵材類' and state=N'未結案'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[4].Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where class = N'其他類' and state=N'未結案'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cn);
            SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where state=N'未結案'", con);
            DataSet ds = new DataSet();
            sa.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[13].Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)   //按下查詢健
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter($"select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where pname like N'%{textBox1.Text}%'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter($"select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where date like N'%{textBox1.Text}%'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter($"select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where pnum like N'%{textBox1.Text}%'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter($"select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where mark like N'%{textBox1.Text}%'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2 = new Select();
            f2.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    SqlConnection con = new SqlConnection(cn);
                    con.Open();
                    SqlDataAdapter sa = new SqlDataAdapter($"select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where pname like N'%{textBox1.Text}%'", con);
                    DataSet ds = new DataSet();
                    sa.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    SqlConnection con = new SqlConnection(cn);
                    con.Open();
                    SqlDataAdapter sa = new SqlDataAdapter($"select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where date like N'%{textBox1.Text}%'", con);
                    DataSet ds = new DataSet();
                    sa.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    SqlConnection con = new SqlConnection(cn);
                    con.Open();
                    SqlDataAdapter sa = new SqlDataAdapter($"select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where pnum like N'%{textBox1.Text}%'", con);
                    DataSet ds = new DataSet();
                    sa.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    SqlConnection con = new SqlConnection(cn);
                    con.Open();
                    SqlDataAdapter sa = new SqlDataAdapter($"select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where pnum like N'%{textBox1.Text}%'", con);
                    DataSet ds = new DataSet();
                    sa.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)  //修改
        {
            try
            {
                if (label1.Text == "")
                {
                    MessageBox.Show("未指定項目");
                }
                else
                {
                    f3 = new 修改();
                    f3.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("未指定項目");
            }

        }

        private void button5_Click(object sender, EventArgs e)  //刪除
        {
            DialogResult r;
            r = MessageBox.Show("刪除所有相關資料?", "移除", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = cn;
                conn.Open();
                SqlCommand cmd = new SqlCommand($"delete from a where id=N'{label1.Text}' ", conn);
                SqlCommand cmd1 = new SqlCommand($"delete from b where log_id=N'{label1.Text}'", conn);
                SqlCommand cmd2 = new SqlCommand($"delete from cc where ctid=N'{label1.Text}' ", conn);
                //SqlCommand cmd1 = new SqlCommand($"delete from  b where =N'{label9.Text}' ", conn);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                conn.Close();
                Chart_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)  //進貨鍵
        {
            if (label1.Text == "")
            {
                MessageBox.Show("未指定項目");
            }
            if (label1.Text != "" && label3.Text == "結案")
            {
                DialogResult r;
                r = MessageBox.Show("已結案項目,確定繼續進貨?", "警告", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    if (label2.Text == "其他類")
                    {
                        f4 = new 進貨();
                        f4.Show();
                    }
                    else
                    {
                        f5 = new 鐵材進貨();
                        f5.Show();
                    }
                }
            }
            if (label1.Text != "" && label3.Text == "未結案")
            {
                if (label2.Text == "其他類")
                {
                    f4 = new 進貨();
                    f4.Show();
                }
                else
                {
                    if (label5.Text != "")
                    {
                        DialogResult g;
                        g = MessageBox.Show($"確定進貨合約號-{label5.Text}?", "警告", MessageBoxButtons.OKCancel);
                        if (g == DialogResult.OK)
                        {
                            f5 = new 鐵材進貨();
                            f5.Show();
                        }
                    }
                    else
                    {
                        f5 = new 鐵材進貨();
                        f5.Show();
                    }
                    
                }
            }


        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)   
        {
            if (checkBox1.Checked == true)
            {
                radioButton1.Checked = radioButton2.Checked = false;
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where state=N'結案'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }
            else
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',date as '單據日期',remark as '備註',claas as '類別',mark from a where state=N'未結案'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }
            /*
            if (radioButton1.Checked == true)  //僅鐵材
            {
                if (checkBox1.Checked == true)
                {
                    SqlConnection con = new SqlConnection(cn);
                    SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',mark as 'state',remark as '備註',claas as '類別' from a where class=N'鐵材類' and state=N'結案'", con);
                    DataSet ds = new DataSet();
                    sa.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                }
                else
                {
                    SqlConnection con = new SqlConnection(cn);
                    SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',mark as 'state',remark as '備註',claas as '類別' from a where class=N'鐵材類'", con);
                    DataSet ds = new DataSet();
                    sa.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                }
            }
            if (radioButton2.Checked == true)  //僅其他
            {
                if (checkBox1.Checked == true)
                {
                    SqlConnection con = new SqlConnection(cn);
                    SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',mark as 'state',remark as '備註',claas as '類別' from a where class=N'其他類' and state=N'結案'", con);
                    DataSet ds = new DataSet();
                    sa.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                }
                else
                {
                    SqlConnection con = new SqlConnection(cn);
                    SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',mark as 'state',remark as '備註',claas as '類別' from a where class=N'其他類'", con);
                    DataSet ds = new DataSet();
                    sa.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                }
            }
            else
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',mark as 'state',remark as '備註',claas as '類別' from a where state=N'結案'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
            }
            
            /*
            if (radioButton1.Checked==true && checkBox1.Checked == true)
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter sa = new SqlDataAdapter("select id as 'ID',pnum as '品號',vname as '廠商',pname as '品名',thin as '板厚',fomat as '規格',price as '單價',qty as '數量',unit as '單位',state as '狀態',mark as 'state',remark as '備註',claas as '類別' from a where class=N'鐵材類'", con);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
            }*/
        }

        private void button6_Click(object sender, EventArgs e)  //進貨紀錄
        {
            if (label1.Text == "")
            {
                MessageBox.Show("未指定項目");
            }
            else
            {
                f6 = new 進貨紀錄();
                f6.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cn);
            SqlDataAdapter sa = new SqlDataAdapter($"select ctid,ctmark as '合約號',ctwei as '合約重量',ctprice as '合約價格',cttotalwei as '已出總重',cttotalprice as '預收金額',ctpay as '已出金額',ROUND(ctq,1)as '重量差額',ctdate as '帳款年月',state as '狀態' from cc", con);
            DataSet ds = new DataSet();
            sa.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            label5.Text = "";
            label1.Text = "";
        }
    }
}

