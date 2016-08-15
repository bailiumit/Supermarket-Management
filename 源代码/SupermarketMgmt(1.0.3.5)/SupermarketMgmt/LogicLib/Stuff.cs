using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLib
{
	/// <summary>
	/// 用户类，涉及用户的各基本信息及访问权限
	/// </summary>
	sealed public class Stuff
	{
		public string stuffNumber;
        public string stuffName;
        public string stuffPosition;
		public string stuffPassword;

		public bool[] Rights;

        public Stuff(string n_stuffNumber, string n_stuffName, string n_stuffPosition, string n_stuffPassword)
        {
            stuffNumber = n_stuffNumber;
            stuffName = n_stuffName;
            stuffPosition = n_stuffPosition;
            stuffPassword = n_stuffPassword;
        }

        public string GetStuffNumber()
        {
            return stuffNumber;
        }

        public string GetStuffName()
        {
            return stuffName;
        }

        public string GetStuffPosition()
        {
            return stuffPosition;
        }

        public string GetStuffPassword()
        {
            return stuffPassword;
        }
	}
}
