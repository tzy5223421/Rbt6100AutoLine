using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Rbt6100AutoLine.Controls
{
    public class DataBase
    {
        string connectCommand;
        List<string> ColumnList = new List<string>();
        List<string> tableName = new List<string>();

        public DataBase(string ConnectionString)
        {
            this.connectCommand = ConnectionString;
        }

        /// <summary>
        /// 创建表
        /// </summary>
        /// <returns></returns>
        public void CreateTable(string tableName, string time)
        {
            if (CheckTableIsExist(tableName))
            {
                MessageBox.Show("数据表创建失败，存在相同表名的数据表格");
            }
            else
            {
                SqlConnection sqlconnection = new SqlConnection(connectCommand);
                try
                {
                    sqlconnection.Open();
                    string sql = @"create table " + tableName + " (ID int PRIMARY KEY,SN序列号 nchar(255),上料状态 nchar(255),装配状态 nchar(255),下料状态 nchar(255))";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlconnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("表创建成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// 检查是否存在相同表名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private bool CheckTableIsExist(string tableName)
        {
            bool isExist = false;
            List<string> list = ReadTableName();
            for (int i = 0; i < list.Count; i++)
            {
                if (tableName.Equals(list[i]))
                {
                    isExist = true;
                }
            }
            return isExist;
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        public List<string> ReadTableName()
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                DataTable dt = sqlconnection.GetSchema("Tables");//获取表名
                foreach (DataRow row in dt.Rows)
                {
                    tableName.Add(row[2].ToString());
                }
                sqlconnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //   throw;
            }
            return tableName;
        }

        /// <summary>
        /// 获取表格数据
        /// </summary>
        /// <returns></returns>
        public DataTable ReadTable(string tableName)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                string sql = @"select * from " + tableName;
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlconnection);
                da.Fill(ds, tableName);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return ds.Tables[tableName];
        }

        /// <summary>
        /// 更新上料数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="columnname"></param>
        /// <param name="value"></param>
        /// <param name="SnValue"></param>
        /// <returns></returns>
        public void UpData_Feed(string tablename, string oldvalue, string newvalue)
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                string sql = @"update " + tablename + " set 上料状况=" + oldvalue + " where SN序列号=" + newvalue;
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
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        /// <summary>
        /// 更新装配状况数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="OldValue"></param>
        /// <param name="SnValue"></param>
        /// <returns></returns>
        public void UpData_Assembly(string tableName, string OldValue, string SnValue)
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                string sql = @"update " + tableName + "set 装配状况=" + OldValue + "where SN序列号=" + SnValue;
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        /// <summary>
        /// 更新下料状况数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="OldValue"></param>
        /// <param name="SnValue"></param>
        public void Updata_Bait(string tableName, string OldValue, string SnValue)
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                string sql = @"update " + tableName + "set 下料状况=" + OldValue + "where SN序列号=" + SnValue;
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
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public void DeleteDate()
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
            catch (Exception ex)
            {
                sqlconnection.Close();
                Console.Write(ex.Message);
            }
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
        public void InsertData(string tablename, string ID, string SN, string statue, string time)
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                string sql = @"Insert into " + tablename + "(ID,SN序列号,上料状况,装配状况) values (" + "'" + ID + "'" + "," + "'" + SN + "'" + "," + "'" + statue + "'" + "," + "'" + time + "'" + ")";
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
            }
            catch (Exception ex)
            {
                sqlconnection.Close();
                Console.Write(ex.Message);
            }
        }

        public void DeleteTable(string tableName)
        {
            SqlConnection sqlconnection = new SqlConnection(connectCommand);
            try
            {
                sqlconnection.Open();
                if (CheckTableIsExist(tableName))
                {
                    string sql = "Drop table " + tableName;
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlconnection);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}
