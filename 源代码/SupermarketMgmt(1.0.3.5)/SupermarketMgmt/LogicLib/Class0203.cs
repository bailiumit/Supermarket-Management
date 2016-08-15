using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Class02，表示体育用品（0203）类商品
	/// </summary>
	sealed public class Class0203 : Class02
	{
		/// <summary>
		/// 体育用品的品牌
		/// </summary>
		private string Brand;			//	体育用品的品牌

		public string pBrand
		{
			get { return Brand; }
			set { Brand = value; }
		}

		public Class0203()
		{
			FirstCategory = "02";
			SecondCategory = "0203";
		}

		new public string[] GetAllFields()
		{
			string[] res = new string[13];
			int i = 0;

			foreach (string str in base.GetAllFields())
			{
				res[i] = str;
				i++;
			}

			res[11] = Convert.ToString(Brand);
			res[12] = "";

			return res;
		}
	}
}
