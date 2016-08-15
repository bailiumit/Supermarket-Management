using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Item类，为所有书籍类（04）商品提供抽象基类
	/// </summary>
	abstract public class Class04 : Item
	{
		/// <summary>
		/// 作者
		/// </summary>
		protected string Author;			//	作者

		/// <summary>
		/// 出版社
		/// </summary>
		protected string PublicHouse;		//	出版社

		public string pAuthor
		{
			get { return Author; }
			set { Author = value; }
		}

		public string pPublicHouse
		{
			get { return PublicHouse; }
			set { PublicHouse = value; }
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

			res[9] = Convert.ToString(Author);
			res[10] = Convert.ToString(PublicHouse);

			return res;
		}
	}
}
