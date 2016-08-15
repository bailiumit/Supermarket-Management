using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;

namespace GUI.Window
{
    public partial class ItemAccess
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
                    Console.WriteLine("Failed in opening the database!");
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

        #region 向Item数据表添加数据
        /// <summary>
        /// 向Item数据表中添加数据
        /// </summary>
        public void AddItem(string[] n_commandArray)
        {
            string commandString = "";
            DateTime curTime;
            bool flag = true;

            try
            {
                

                string[] strDivideQuarter = new string[5] { "2014.1.1", "2014.4.1", "2014.7.1", "2014.10.1", "2015.1.1" };
                DateTime[] divideQuarer = new DateTime[5]{
                    Convert.ToDateTime(strDivideQuarter[0]),
                    Convert.ToDateTime(strDivideQuarter[1]),
                    Convert.ToDateTime(strDivideQuarter[2]),
                    Convert.ToDateTime(strDivideQuarter[3]),
                    Convert.ToDateTime(strDivideQuarter[4]),
                };
                curTime = DateTime.Now;
                if (n_commandArray[4] == "3")
                {
                    if (DateTime.Compare(curTime, divideQuarer[0]) > 0 && DateTime.Compare(curTime, divideQuarer[1]) <= 0)
                    {
                        n_commandArray[7] = "1";
                    }
                    else if (DateTime.Compare(curTime, divideQuarer[1]) > 0 && DateTime.Compare(curTime, divideQuarer[2]) <= 0)
                    {
                        n_commandArray[7] = "2";
                    }
                    else if (DateTime.Compare(curTime, divideQuarer[2]) > 0 && DateTime.Compare(curTime, divideQuarer[3]) <= 0)
                    {
                        n_commandArray[7] = "3";
                    }
                    else if (DateTime.Compare(curTime, divideQuarer[3]) > 0 && DateTime.Compare(curTime, divideQuarer[4]) <= 0)
                    {
                        n_commandArray[7] = "4";
                    }
                    else
                    {
                        n_commandArray[7] = "0";
                    }
                }
                else
                {
                    n_commandArray[7] = "0";
                }

                commandString = "INSERT INTO Item (FirstCategory, SecondCategory, Code, ItemName, Condition, BuyingPrice, SellingPrice, Quarter, Remark, FirstSubClassA, FirstSubClassB, SecondSubClassA, SecondSubClassB, ManipulateTime) VALUES('";
                commandString += n_commandArray[0] + "', '";
                commandString += n_commandArray[1] + "', '";
                commandString += n_commandArray[2] + "', '";
                commandString += n_commandArray[3] + "', '";
                commandString += n_commandArray[4] + "', '";
                commandString += n_commandArray[5] + "', '";
                commandString += n_commandArray[6] + "', '";
                commandString += n_commandArray[7] + "', '";
                commandString += n_commandArray[8] + "', '";
                commandString += n_commandArray[9] + "', '";
                commandString += n_commandArray[10] + "', '";
                commandString += n_commandArray[11] + "', '";
                commandString += n_commandArray[12] + "', '";
                commandString += curTime.ToString("yyyy.MM.dd") + "')";

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

        #region 在Item数据表中进行单条数据查询
        /// <summary>
        /// 在Item数据表中进行单条数据查询
        /// </summary>
        public string[] SingleQueryItem(string n_code)
        {
            string commandString;
            string[] queryResult = new string[15];
            bool flag = true;

            try
            {
                commandString = "SELECT * FROM Item WHERE Code = '";
                commandString += n_code + "'";

                flag = DatabaseCommand(commandString);

                myReader = myCommand.ExecuteReader();
                myReader.Read();
                if (myReader.HasRows == true)
                {
                    for (int i = 1; i < 15; i++)
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

        #region 在Item数据表中进行数据更新操作
        /// <summary>
        /// 在Item数据表中进行数据更新操作
        /// </summary>
        public void UpdateItem(string[] n_commandArray)
        {
            string commandString;
            string quarterString = null;
            DateTime curTime;
            bool flag = true;

            try
            {              
                string[] strDivideQuarter = new string[5] { "2014.1.1", "2014.4.1", "2014.7.1", "2014.10.1", "2015.1.1" };
                DateTime[] divideQuarer = new DateTime[5]{
                    Convert.ToDateTime(strDivideQuarter[0]),
                    Convert.ToDateTime(strDivideQuarter[1]),
                    Convert.ToDateTime(strDivideQuarter[2]),
                    Convert.ToDateTime(strDivideQuarter[3]),
                    Convert.ToDateTime(strDivideQuarter[4]),
                };
                curTime = DateTime.Now;
                if (n_commandArray[3] == "3")
                {
                    if (DateTime.Compare(curTime, divideQuarer[0]) > 0 && DateTime.Compare(curTime, divideQuarer[1]) <= 0)
                    {
                        quarterString = "1";
                    }
                    else if (DateTime.Compare(curTime, divideQuarer[1]) > 0 && DateTime.Compare(curTime, divideQuarer[2]) <= 0)
                    {
                        quarterString = "2";
                    }
                    else if (DateTime.Compare(curTime, divideQuarer[2]) > 0 && DateTime.Compare(curTime, divideQuarer[3]) <= 0)
                    {
                        quarterString = "3";
                    }
                    else if (DateTime.Compare(curTime, divideQuarer[3]) > 0 && DateTime.Compare(curTime, divideQuarer[4]) <= 0)
                    {
                        quarterString = "4";
                    }
                    else
                    {
                        quarterString = "0";
                    }
                }
                else
                {
                    quarterString = "0";
                }

                commandString = "UPDATE Item SET Code = '" + n_commandArray[1] + "', ";
                commandString += "ItemName = '" + n_commandArray[2] + "',";
                commandString += "Condition = '" + n_commandArray[3] + "', ";
                commandString += "BuyingPrice = '" + n_commandArray[4] + "', ";
                commandString += "SellingPrice = '" + n_commandArray[5] + "', ";
                commandString += "Quarter = '" + quarterString + "', ";
                commandString += "Remark = '" + n_commandArray[6] + "', ";
                commandString += "ManipulateTime = '" + curTime.ToString("yyyy.MM.dd") + "'";
                commandString += "WHERE Code = '" + n_commandArray[0] + "'";
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
                MessageBox.Show("更新数据成功！");
            }
            else
            {
                MessageBox.Show("更新数据失败！");
            }
        }
        #endregion

        #region 在Item数据表中进行数据删除操作
        /// <summary>
        /// 在Item数据表中进行数据删除操作
        /// </summary>
        public void DeleteItem(string n_code)
        {
            string commandString;
            bool flag = true;

            try
            {
                commandString = "DELETE * FROM Item WHERE Code = '";
                commandString += n_code + "'";

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

        #region 从Item数据表中根据商品状态获取想要的数据的数组
        /// <summary>
        /// 从Item数据表中根据商品状态获取想要的数据的数组
        /// </summary>
        public string[] GetData(string n_condition, string n_dataName)
        {
            string numCommand;
            string commandString;
            string[] acquireResult = null;
            int length, count = 0;
            bool flag = true;

            try
            {
                //获取满足查询条件的数据条数，用于确定字符串数组的长度
                numCommand = "SELECT COUNT(*) AS RowNum FROM Item WHERE Condition = ";
                numCommand += Convert.ToInt16(n_condition);
                flag = DatabaseCommand(numCommand);
                myReader = myCommand.ExecuteReader();
                myReader.Read();
                length = Convert.ToInt16(myReader["RowNum"]);
                acquireResult = new string[length];

                //将字符串存到对应的数组中
                commandString = "SELECT "+ n_dataName +" FROM Item WHERE Condition = ";
                commandString += Convert.ToInt16(n_condition);
                flag = DatabaseCommand(commandString);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    acquireResult[count] = myReader[0].ToString();
                    count++;
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
                MessageBox.Show("获取信息功能出现故障！");
            }

            return acquireResult;
        }
        #endregion
        
        #region 从Item数据表中根据商品状态、操作时间获取想要的数据的数组
        /// <summary>
        /// 从Item数据表中根据商品状态、操作时间获取想要的数据的数组
        /// </summary>
        public string[] GetDataWithTime(string n_condition, string n_dataName, int n_year, int n_month)
        {
            string[] timeData = GetData(n_condition, "ManipulateTime");
            string[] originData = GetData(n_condition, n_dataName);
            int originLength = timeData.Length;

            int[] orderData = new int[originLength];
            int resultLength = 0;
            string[] resultData = null;

            bool flag = true;

            try
            {
                //从查到的原始数据中筛选出符合要求时间段的数据
                for (int i = 0; i < originLength; i++)
                {
                    DateTime temp = Convert.ToDateTime(timeData[i]);
                    if (temp.Year == n_year && temp.Month == n_month)
                    {
                        orderData[resultLength] = i;
                        resultLength++;
                    }
                }

                if (resultLength == 0)
                {
                    resultData = new string[1];
                    resultData[0] = "fail";
                    return resultData;
                }

                resultData = new string[resultLength];
                for (int i = 0; i < resultLength; i++)
                {
                    resultData[i] = originData[orderData[i]];
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
                MessageBox.Show("获取信息功能出现故障！");
            }

            return resultData;
        }
        #endregion
    }  
}
