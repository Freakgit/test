using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ttyd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDatabass();
        }
        public void Show_List(string szTemp)
        {
            this.Invoke(new EventHandler(delegate
            {
                string szTime = DateTime.Now.ToString("HH:mm:ss");
                listBox1.Items.Add("(" + szTime + ")" + szTemp);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }));
        }
        public void CreateDatabass()
        {
            MySqlConnection conn1 = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=root;");
            MySqlCommand cmd1 = new MySqlCommand("CREATE DATABASE datastorage;", conn1);
            conn1.Open();
            try
            {
                cmd1.ExecuteNonQuery();
                conn1.Close();
                Show_List("数据库创建成功");
            }
            catch (Exception)
            {
                conn1.Close();
                Show_List("数据库已存在");
            }
            MySqlConnection conn2 = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=root;");
            MySqlCommand cmd2 = new MySqlCommand("CREATE DATABASE datatemporary;", conn2);
            conn2.Open();
            try
            {
                cmd2.ExecuteNonQuery();
                conn2.Close();
                Show_List("数据库创建成功");
            }
            catch (Exception)
            {
                conn2.Close();
                Show_List("数据库已存在");
            }
            MySqlConnection conn3 = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=root;");
            MySqlCommand cmd3 = new MySqlCommand("CREATE DATABASE timingstorage;", conn3);
            conn3.Open();
            try
            {
                cmd3.ExecuteNonQuery();
                conn3.Close();
                Show_List("数据库创建成功");
            }
            catch (Exception)
            {
                conn3.Close();
                Show_List("数据库已存在");
            }
            MySqlConnection conn4 = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=root;");
            MySqlCommand cmd4 = new MySqlCommand("CREATE DATABASE timingupload;", conn4);
            conn4.Open();
            try
            {
                cmd4.ExecuteNonQuery();
                conn4.Close();
                Show_List("数据库创建成功");
            }
            catch (Exception)
            {
                conn4.Close();
                Show_List("数据库已存在");
            }
            MySqlConnection conn5 = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=root;");
            MySqlCommand cmd5 = new MySqlCommand("CREATE DATABASE jishu;", conn5);
            conn5.Open();
            try
            {
                cmd5.ExecuteNonQuery();
                conn5.Close();
                Show_List("数据库创建成功");
            }
            catch (Exception)
            {
                conn5.Close();
                Show_List("数据库已存在");
            }
        }
        public void CreateDataTable()
        {
            string connStr1 = "server=localhost;port=3306;database=datastorage;user=root;password=root;";
            string createStatement1 = "CREATE TABLE `storage` (`id` varchar(20) DEFAULT NULL,`MAC` varchar(20) DEFAULT NULL,`Temp` varchar(10) DEFAULT NULL,`Hum` varchar(10) DEFAULT NULL,`Vol` varchar(10) DEFAULT NULL,`Cur` varchar(10) DEFAULT NULL,`Net1` varchar(10) DEFAULT NULL,`Net2` varchar(10) DEFAULT NULL,`COM1` varchar(10) DEFAULT NULL,`IO1` varchar(10) DEFAULT NULL,`IO2` varchar(10) DEFAULT NULL,`IO3` varchar(10) DEFAULT NULL,`IO4` varchar(10) DEFAULT NULL) ENGINE = InnoDB DEFAULT CHARSET = latin1";
            using (MySqlConnection conn1 = new MySqlConnection(connStr1))
            {
                conn1.Open();
                try
                {
                    using (MySqlCommand cmd1 = new MySqlCommand(createStatement1, conn1))
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    Show_List("建表成功");
                }
                catch (Exception)
                {
                    Show_List("表已存在");
                }
            }
            string connStr2 = "server=localhost;port=3306;database=datatemporary;user=root;password=root;";
            string createStatement2 = "CREATE TABLE `temporary` (`id` int(11) DEFAULT NULL,`datami` varchar(500) DEFAULT NULL) ENGINE = InnoDB DEFAULT CHARSET = latin1";
            using (MySqlConnection conn2 = new MySqlConnection(connStr2))
            {
                conn2.Open();
                try
                {
                    using (MySqlCommand cmd2 = new MySqlCommand(createStatement2, conn2))
                    {
                        cmd2.ExecuteNonQuery();
                    }
                    Show_List("建表成功");
                }
                catch (Exception)
                {
                    Show_List("表已存在");
                }
            }
            string connStr3 = "server=localhost;port=3306;database=timingstorage;user=root;password=root;";
            string createStatement3 = "CREATE TABLE `timing` (`ID` varchar(100) DEFAULT NULL,`MAC` varchar(100) DEFAULT NULL,`IO1` varchar(50) DEFAULT NULL,`IO2` varchar(50) DEFAULT NULL,`IO3` varchar(50) DEFAULT NULL,`IO4` varchar(50) DEFAULT NULL) ENGINE = InnoDB DEFAULT CHARSET = latin1";
            using (MySqlConnection conn3 = new MySqlConnection(connStr3))
            {
                conn3.Open();
                try
                {
                    using (MySqlCommand cmd3 = new MySqlCommand(createStatement3, conn3))
                    {
                        cmd3.ExecuteNonQuery();
                    }
                    Show_List("建表成功");
                }
                catch (Exception)
                {
                    Show_List("表已存在");
                }
            }
            string connStr4 = "server=localhost;port=3306;database=timingupload;user=root;password=root;";
            string createStatement4 = "CREATE TABLE `upload` (`id` int(20) DEFAULT NULL,`datatiming` varchar(1024) DEFAULT NULL) ENGINE = InnoDB DEFAULT CHARSET = latin1";
            using (MySqlConnection conn4 = new MySqlConnection(connStr4))
            {
                conn4.Open();
                try
                {
                    using (MySqlCommand cmd4 = new MySqlCommand(createStatement4, conn4))
                    {
                        cmd4.ExecuteNonQuery();
                    }
                    Show_List("建表成功");
                }
                catch (Exception)
                {
                    Show_List("表已存在");
                }
            }
            string connStr5 = "server=localhost;port=3306;database=jishu;user=root;password=root;";
            string createStatement5 = "CREATE TABLE `biao` (`id` varchar(20) DEFAULT NULL,`IO1` varchar(50) DEFAULT NULL,`IO2` varchar(50) DEFAULT NULL,`IO3` varchar(50) DEFAULT NULL,`IO4` varchar(50) DEFAULT NULL) ENGINE = InnoDB DEFAULT CHARSET = latin1";
            using (MySqlConnection conn5 = new MySqlConnection(connStr5))
            {
                conn5.Open();
                try
                {
                    using (MySqlCommand cmd5 = new MySqlCommand(createStatement5, conn5))
                    {
                        cmd5.ExecuteNonQuery();
                    }
                    Show_List("建表成功");
                }
                catch (Exception)
                {
                    Show_List("表已存在");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateDataTable();
        }
    }
}
