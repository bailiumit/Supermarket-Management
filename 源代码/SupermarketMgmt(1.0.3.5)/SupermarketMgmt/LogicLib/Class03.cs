using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Item类，为所有食品类（03）商品提供抽象基类
	/// </summary>
	abstract public class Class03 : Item
	{
		/// <summary>
		/// 食品的保质期
		/// </summary>
		protected int QualityPeriod;			//	食品的保质期

		public int pQualityPeriod
		{
			get { return QualityPeriod; }
			set { QualityPeriod = value; }
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

			res[9] = Convert.ToString(QualityPeriod);
			res[10] = "";

			return res;
		}
	}
}
