using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopTudo
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            Query();
            //设置表格样式
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
        SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = xiaobaibookshop; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_Name.Text == null || tb_Password.Text == null || tb_phone.Text == null || tb_Address.Text == null)
            {
                MessageBox.Show("输入框不能为空", "提示");
            }

            else
            {
                try
                {
                    sc.Open();
                    string insert = "insert into [dbo].[Table2] values('" + tb_Name.Text + "','" + tb_phone.Text + "','" + tb_Address.Text + "','" + tb_Password.Text + "')";
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
        public void Query()
        {
            sc.Open();
            string str = "select * from [dbo].[Table2]";
            SqlDataAdapter adapter = new SqlDataAdapter(str, sc);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            sc.Close();
            Reset();


        }

        public void Reset()
        {
            tb_Address.Text = "";
            tb_Name.Text = "";
            tb_Password.Text = "";
            tb_phone.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (tb_Address.Text == null || tb_Name.Text == null || tb_Password.Text == null || tb_phone.Text == null)
            {
                MessageBox.Show("输入框不能为空", "提示");
            }

            else
            {
                try
                {
                    sc.Open();
                    string insert = "update [dbo].[Table2] set UName= '" + tb_Name.Text + "',UPhone='" + tb_phone.Text + "',UAdd='" + tb_Address.Text + "',UPassword='" + tb_Password.Text + "'where UId='" + key + "'";
                    SqlCommand scm = new SqlCommand(insert, sc);
                    scm.ExecuteNonQuery();
                    MessageBox.Show("用户信息修改成功");
                    sc.Close();
                    Query();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_Name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tb_phone.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            tb_Address.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            tb_Password.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //获取用户编号
            key = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    string insert = "delete from [dbo].[Table2] where UId='" + key + "'";
                    SqlCommand scm = new SqlCommand(insert, sc);
                    scm.ExecuteNonQuery();
                    MessageBox.Show("用户信息删除成功");
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
