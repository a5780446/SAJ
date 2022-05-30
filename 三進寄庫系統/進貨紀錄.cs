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
    public partial class 進貨紀錄 : Form
    {
        public 進貨紀錄()
        {
            InitializeComponent();
        }

        private void 進貨紀錄_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label5.Text = Chart.ID;
            SqlConnection con = new SqlConnection(Chart.cn);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter($"select a.id,a.pname as '品名',b.informat as '規格',a.thin as '厚度',b.inqty as '進貨量',b.leftqty as '寄庫餘量',b.inprice as '進貨單價',b.intotal as '進貨總價',b.indate as '進貨日期',b.num from a inner join b on a.id=b.log_id where id='{label5.Text}' order by b.num ", con);
            DataSet ds = new DataSet();
            sa.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;


            SqlCommand cmd = new SqlCommand($"select num from b where log_id='{label5.Text}'", con);
            cmd.ExecuteNonQuery();
            label6.Text = cmd.ExecuteScalar().ToString();
            SqlCommand cmd8 = new SqlCommand($"select sum(inqty) from b where log_id={label5.Text}", con);
            cmd8.ExecuteNonQuery();
            label2.Text = cmd8.ExecuteScalar().ToString();
            SqlCommand cmd9 = new SqlCommand($"select sum(intotal) from b where log_id={label5.Text}", con);
            cmd9.ExecuteNonQuery();
            label4.Text = cmd9.ExecuteScalar().ToString();
            con.Close();
            
        }

            private void button1_Click(object sender, EventArgs e)  //刪除
        {
            DialogResult r;
            r = MessageBox.Show("刪除此進貨資料?", "移除", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(Chart.cn);
                conn.Open();
                SqlCommand cmd1 = new SqlCommand($"delete from b where num='{label6.Text}'", conn);
                SqlCommand cmd2 = new SqlCommand($"update a set qty=qty+{label7.Text} where id=N'{label5.Text}' ",conn);
                //SqlCommand cmd3 = new SqlCommand($"update b set leftqty=leftqty+{label7.Text}where log_id=N'{label5.Text}' ", conn);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                SqlCommand cmd4=new SqlCommand($"update cc set cttotalwei=cttotalwei-{label7.Text} where ctid=N'{label5.Text}' ", conn);
                cmd4.ExecuteNonQuery();
                SqlCommand cmd5 = new SqlCommand($"update cc set cttotalwei=(select sum(inqty) from b where log_id='{label5.Text}'),ctpay=(select sum(intotal) from b where log_id='{label5.Text}'),state=N'已出完' where ctid='{label5.Text}'", conn);
                cmd5.ExecuteNonQuery();
                SqlCommand cmd6 = new SqlCommand($"update cc set ctq=abs(ctpay-cttotalprice) where ctid={label5.Text}", conn);
                cmd6.ExecuteNonQuery();
                //cmd3.ExecuteNonQuery();
                conn.Close();
                進貨紀錄_Load(sender, e);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label6.Text = dataGridView1.Rows[e.RowIndex].Cells["num"].Value.ToString();
                label7.Text = dataGridView1.Rows[e.RowIndex].Cells["進貨量"].Value.ToString();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
