using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo3.Wpf.Shared
{
    public class QueryParameter
    {
		private int pageIndex;

		public int PageIndex
		{
			get { return pageIndex; }
			set { pageIndex = value; }
		}

		private int pageSize;

		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value; }
		}

		private string? search;

		public string? Search
		{
			get { return search; }
			set { search = value; }
		}

	}
}
