using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Item类，为所有电器类（01）商品提供抽象基类
	/// </summary>
	abstract public class Class01 : Item
	{
		/// <summary>
		/// 保修年限
		/// </summary>
		protected int Guarantee;			//	保修年限

		public int pGuarantee
		{
			get { return Guarantee; }
			set { Guarantee = value; }
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
			res[9] = Convert.ToString(Guarantee);
			res[10] = "";

			return res;
		}
	}
}
