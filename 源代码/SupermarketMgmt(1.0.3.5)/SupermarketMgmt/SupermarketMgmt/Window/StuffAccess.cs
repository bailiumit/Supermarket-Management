using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;
using LogicLib;
using System.Diagnostics;

namespace GUI.Window
{
    public partial class StuffAccess
    {
        private OleDbConnection myConn;
        private OleDbCommand myCommand;
        private OleDbDataReader myReader;

        #region 数据库连接、操作执行函数
        /// <summary>
        /// 利用封装好的函数连接数据库、处理向数据库发出的操作指令，达到减少代码量、提高封装性的目的
        /// </summary>
        private bool DatabaseCommand(string commandString)
        {
            myConn = new OleDbConnection();
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source = ..\Database\Market.mdb";
            bool flag = true;

            try
            {
                myConn.ConnectionString = connectionString;
                myConn.Open();

                if (myConn.State != ConnectionState.Open)
                {
                    Debug.WriteLine("Failed in opening the database!");
                }
                myCommand = new OleDbCommand(commandString, myConn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return flag;
        }
        #endregion
        
        #region 验证用户名和密码
        /// <summary>
        /// 将传进来的工号和数据库中对应的密码相对比，返回匹配结果和操作者的权限等级
        /// </summary>
        public string[] LogInStuff(string[] n_commandArray)
        {
            string commandString = null;
            bool flag = true;
            string[] queryResult = new string[5];

            try
            {
                commandString = "SELECT * FROM Stuff WHERE StuffNumber = '";
                commandString += n_commandArray[0] + "'";

                flag = DatabaseCommand(commandString);

                myReader = myCommand.ExecuteReader();
                myReader.Read();
                if (myReader.HasRows == true)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        queryResult[i] = myReader[i+1].ToString();
                    }
                    if (queryResult[3] == n_commandArray[1])
                    {
                        queryResult[4] = "1";
                    }
                    else
                    {
                        queryResult[4] = "0";
                    }
                }
                else
                {
                    queryResult[4] = "0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                myConn.Close();
            }

            if (!flag)
            {
                MessageBox.Show("登陆系统故障！");
            }
  
            return queryResult;
        }

        #endregion

        #region 向Stuff数据表添加数据
        /// <summary>
        /// 向Stuff数据表中添加数据
        /// </summary>
        public void AddStuff(Stuff stuff)
        {
            string commandString = "";
            bool flag = true;

            try
            {
                commandString = "INSERT INTO Stuff (StuffNumber, StuffName, StuffPosition, StuffPassword) VALUES('";
                commandString += stuff.GetStuffNumber() + "', '";
                commandString += stuff.GetStuffName() + "', '";
                commandString += stuff.GetStuffPosition() + "', '";
                commandString += stuff.GetStuffPassword() + "')";

                flag = DatabaseCommand(commandString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                myConn.Close();
            }

            if (flag)
            {
                MessageBox.Show("添加数据成功！");
            }
            else
            {
                MessageBox.Show("添加数据失败！");
            }
        }
        #endregion

        #region 在Stuff数据表中进行单条数据查询
        /// <summary>
        /// 在Stuff数据表中进行单条数据查询
        /// </summary>
        public string[] SingleQueryStuff(string n_StuffNumber)
        {
            string commandString;
            string[] queryResult = new string[4];
            bool flag = true;

            try
            {
                commandString = "SELECT * FROM Stuff WHERE StuffNumber = '";
                commandString += n_StuffNumber + "'";

                flag = DatabaseCommand(commandString);

                myReader = myCommand.ExecuteReader();
                myReader.Read();
                if (myReader.HasRows == true)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        queryResult[i] = myReader[i].ToString();
                    }
                }
                else
                {
                    queryResult[1] = "fail";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                myConn.Close();
            }

            if (!flag)
            {
                MessageBox.Show("查询数据功能出现故障！");
            }

            return queryResult;
        }
        #endregion

        #region 在Stuff数据表中进行数据更新操作
        /// <summary>
        /// 在Stuff数据表中进行数据更新操作
        /// </summary>
        public void UpdateStuff(string[] n_commandArray)
        {
            string commandString;
            bool flag = true;

            try
            {
                commandString = "UPDATE Stuff SET StuffNumber = '" + n_commandArray[1] + "', ";
                commandString += "StuffName = '" + n_commandArray[2] + "', ";
                commandString += "StuffPosition = '" + n_commandArray[3] + "'";
                commandString += "WHERE StuffNumber = '" + n_commandArray[0] + "'";
                flag = DatabaseCommand(commandString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                myConn.Close();
            }

            if (flag)
            {
                MessageBox.Show("更新数据成功！");
            }
            else
            {
                MessageBox.Show("更新数据失败！");
            }
        }
        #endregion

        #region 在Stuff数据表中进行数据删除操作
        /// <summary>
        /// 在Stuff数据表中进行数据删除操作
        /// </summary>
        public void DeleteStuff(string n_StuffNumber)
        {
            string commandString;
            bool flag = true;

            try
            {
                commandString = "DELETE * FROM Stuff WHERE StuffNumber = '";
                commandString += n_StuffNumber + "'";

                flag = DatabaseCommand(commandString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                flag = false;
            }
            finally
            {
                myConn.Close();
            }

            if (flag)
            {
                MessageBox.Show("删除数据成功！");
            }
            else
            {
                MessageBox.Show("删除数据失败！");
            }
        }
        #endregion

		#region 更新密码操作
		public void UpdatePassword(string[] n_commandArray)
		{
			string commandString;
			bool flag = true;

			try
			{
				commandString = "UPDATE Stuff SET StuffPassword = '" + n_commandArray[1] + "' ";
				commandString += "WHERE StuffNumber = '" + n_commandArray[0] + "'";
				flag = DatabaseCommand(commandString);
				Debug.WriteLine(commandString);
			}
			catch(Exception ex)
			{
				Debug.WriteLine(ex.Message);
				flag = false;
			}
			finally
			{
				myConn.Close();
			}

			if (!flag)
			{
				MessageBox.Show("无法再数据库中更新密码！");
			}
			else
			{
				MessageBox.Show("更新数据成功！");
			}
		}
		#endregion

		#region 查询密码操作
		public string PasswordQuery(string n_StuffNumber)
		{
			string commandString = null;
			string resultString = null;
			bool flag = true;

			try
			{
				commandString = "SELECT * FROM Stuff WHERE StuffNumber = '";
				commandString += n_StuffNumber + "'";

				flag = DatabaseCommand(commandString);

				myReader = myCommand.ExecuteReader();
				myReader.Read();

				if (myReader.HasRows == true)
				{
					resultString = myReader[4].ToString();
				}
				else
				{
					resultString = "fail";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				flag = false;
			}
			finally
			{
				myConn.Close();
			}

			if (!flag)
			{
				MessageBox.Show("无法从数据库读取信息！");
			}

			return resultString;
        }
        #endregion
    }
}
