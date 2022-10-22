using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopTudo
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            //将数据库中的所有书籍加载到dataview中
            Query();
            //设置表格样式
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        }

        private void Books_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存图书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        SqlConnection sc = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=xiaobaibookshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_BookName.Text == null || tb_Author.Text == null || tb_Num.Text == null || tb_Price.Text == null || cb_type.SelectedIndex == -1)
            {
                MessageBox.Show("输入框不能为空", "提示");
            }

            else
            {
                try
                {
                    sc.Open();
                    string insert = "insert into [dbo].[Table] values('" + tb_BookName.Text + "','" + tb_Author.Text + "','" + cb_type.SelectedItem.ToString() + "','" + int.Parse(tb_Num.Text) + "','" + int.Parse(tb_Price.Text) + "')";
                    SqlCommand scm = new SqlCommand(insert, sc);
                    scm.ExecuteNonQuery();
                    MessageBox.Show("信息保存成功");
                    sc.Close();
                    Query();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }




        /// <summary>
        /// 在datagridview中显示数据
        /// </summary>
        public void Query()
        {
            sc.Open();
            string str = "select * from [dbo].[Table]";
            SqlDataAdapter adapter = new SqlDataAdapter(str, sc);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            sc.Close();
            Reset();
            
        }



        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //调用条件查询
            Filter();
        }



        //条件查询
        public void Filter()
        {
            sc.Open();
            string str = "select * from [dbo].[Table] where Bcat ='" + comboBox2.SelectedItem.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(str, sc);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            sc.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Query();
        }


        /// <summary>
        /// 重置功能将所有输入框内容设置为空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //Reset();
        }



        public void Reset()
        {
            tb_Author.Text = "";
            tb_BookName.Text = "";
            tb_Num.Text = "";
            tb_Price.Text = "";
            cb_type.SelectedIndex = -1;
        }



        /// <summary>
        /// 点击表格中的项目，将项目中数据添加到对应输入框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            tb_BookName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tb_Author.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cb_type.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            tb_Num.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            tb_Price.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
           
            key = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("信息缺失");
            }
            else
            {

                try
                {
                    sc.Open();
                    string insert = "delete from [dbo].[Table] where Id='"+key+"'";
                    SqlCommand scm = new SqlCommand(insert, sc);
                    scm.ExecuteNonQuery();
                    MessageBox.Show("信息删除成功");
                    sc.Close();
                    Query();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }  }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (tb_BookName.Text == null || tb_Author.Text == null || tb_Num.Text == null || tb_Price.Text == null || cb_type.SelectedIndex == -1)
            {
                MessageBox.Show("输入框不能为空", "提示");
            }

            else
            {
                try
                {
                    sc.Open();
                    string insert = "update [dbo].[Table] set BTitle= '"+tb_BookName.Text+"',BAuthor='"+tb_Author.Text+"',BCat='"+cb_type.SelectedItem.ToString()+"',BQty='"+tb_Num.Text+"',BPrice='"+tb_Price.Text+"'where id='"+key+"'";
                    SqlCommand scm = new SqlCommand(insert, sc);
                    scm.ExecuteNonQuery();
                    MessageBox.Show("信息修改成功");
                    sc.Close();
                    Query();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
