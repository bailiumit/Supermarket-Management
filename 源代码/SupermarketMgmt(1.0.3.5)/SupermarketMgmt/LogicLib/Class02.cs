using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Item类，为所有百货类（02）商品提供抽象基类
	/// </summary>
	abstract public class Class02 : Item
	{
		/// <summary>
		/// 商品产地（国家）
		/// </summary>
		protected string Nationality;			//	商品产地（国家）

		public string pNationality
		{
			get { return Nationality; }
			set { Nationality = value; }
		}


		new protected string[] GetAllFields()
		{
			string[] res = new string[11];
			int i = 0;

			foreach (string str in base.GetAllFields())
			{
				res[i] = str;
				i++;
			}

			res[9] = Convert.ToString(Nationality);
			res[10] = "";

			return res;
		}
	}
}
