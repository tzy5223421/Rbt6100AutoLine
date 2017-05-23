using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Rbt6100AutoLine.Controls
{
    public class DataBase
    {
        string connectCommand;
        //string password;
        public DataBase(string serverName, string password, string userID)
        {
            this.connectCommand = @"Data Source=" + serverName + ";Initial Catalog=Rbt6100AutoLine;User ID=" + userID + "; Password=" + password;
        }
        public bool CreateTable()
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                string sql = @"create table AutoLineStatue" + DateTime.Now.Second + " (ID int PRIMARY KEY,SN序列号 nchar(255),上料状态 nchar(255),装配状态 nchar(255),下料状态 nchar(255))";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlconnection);
                int val = sqlCommand.ExecuteNonQuery();
                if (val > 0)
                {
                    MessageBox.Show("表创建成功");
                }
                sqlconnection.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ReadData()
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("SN序列号");
                dt.Columns.Add("上料状态");
                dt.Columns.Add("装配状态");
                dt.Columns.Add("下料状态");

                sqlconnection.Open();
                string sql = "select * from AutoLineStatue";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlconnection);
                SqlDataReader mysqldataReader = sqlCommand.ExecuteReader();
                while (mysqldataReader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = mysqldataReader.GetInt32(0).ToString();
                    dr[1] = mysqldataReader.GetString(1);
                    dr[2] = mysqldataReader.GetString(2);
                    dr[3] = mysqldataReader.GetString(3);
                    if (mysqldataReader.GetString(4) != null)
                    {
                        dr[4] = mysqldataReader.GetString(4);
                    }
                    else
                    {
                        dr[4] = "";
                    }
                    dt.Rows.Add(dr);
                }
                mysqldataReader.Close();
                sqlconnection.Close();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="columnname"></param>
        /// <param name="value"></param>
        /// <param name="SnValue"></param>
        /// <returns></returns>
        public bool UpDate(string tablename, string columnname, string value, string SnValue)
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                string sql = @"update " + tablename + " set " + columnname + "=" + value + " where SN序列号=" + SnValue;
                SqlCommand sqlcommand = new SqlCommand(sql, sqlconnection);
                int val = sqlcommand.ExecuteNonQuery();
                if (val > 0)
                {
                    MessageBox.Show("更新数据成功");
                }
                else
                {
                    MessageBox.Show("更新数据失败");
                }
                sqlconnection.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            sqlconnection.Close();
            return true;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteDate()
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                string sql = @"Delete from AutoLineStatue Where ID=0";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlconnection);
                int val = sqlCommand.ExecuteNonQuery();
                if (val > 0)
                {
                    MessageBox.Show("更新数据成功");
                }
                else
                {
                    MessageBox.Show("更新数据失败");
                }
                sqlconnection.Close();
            }
            catch (Exception)
            {
                sqlconnection.Close();
                throw;
            }
            return true;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="ID"></param>
        /// <param name="SN"></param>
        /// <param name="statue"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool InsertData(string tablename, string ID, string SN, string statue, string time)
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                string sql = @"Insert into " + tablename + "(ID,SN序列号,上料状况,装配状况) values (" + ID + "," + SN + "," + statue + "," + time + ")";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlconnection);
                int val = sqlCommand.ExecuteNonQuery();//执行sql语句
                if (val > 0)
                {
                    MessageBox.Show("更新数据成功");
                }
                else
                {
                    MessageBox.Show("更新数据失败");
                }
                sqlconnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlconnection.Close();
                return false;
                throw;
            }
        }
    }
}
