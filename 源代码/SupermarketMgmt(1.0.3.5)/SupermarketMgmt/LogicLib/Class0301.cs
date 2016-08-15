using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Class03，表示生鲜食品（0301）类商品
	/// </summary>
	sealed public class Class0301 : Class03
	{
		/// <summary>
		/// 保存此食品的最适温度
		/// </summary>
		private int KeepTemperature;			//	保存此食品的最适温度

		public int pKeepTemperature
		{
			get { return KeepTemperature; }
			set { KeepTemperature = value; }
		}

		public Class0301()
		{
			FirstCategory = "03";
			SecondCategory = "0301";
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

			res[11] = Convert.ToString(KeepTemperature);
			res[12] = "";

			return res;
		}
	}
}
