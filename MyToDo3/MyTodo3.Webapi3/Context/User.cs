using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo3.Webapi3.Context
{
    public class User:BaseEntity
    {
		private string account;

		public string Account
		{
			get { return account; }
			set { account = value; }
		}

		private string userName;

		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}

		private string password;

		public string PassWord
		{
			get { return password; }
			set { password = value; }
		}

	}
}
