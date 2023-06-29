﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo3.Wpf.Common.Models
{
    class MenuBar
    {
		private string icon;

		public string Icon
		{
			get { return icon; }
			set { icon = value; }
		}

		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		private string nameSpace;

		public string NameSpace
		{
			get { return nameSpace; }
			set { nameSpace = value; }
		}

	}
}