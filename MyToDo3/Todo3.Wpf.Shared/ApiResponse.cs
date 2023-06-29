using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo3.Wpf.Shared
{
    public class ApiResponse
    {
        //上面这个非泛型类应用到api层
		public ApiResponse(bool Status,Object Result)
		{
			this.Status = Status;
			this.Result = Result;
		}
		private bool status;

		public bool Status
		{
			get { return status; }
			set { status = value; }
		}

		private Object result;

		public Object Result
        {
			get { return result; }
			set { result = value; }
		}

	}

    //下面这个泛型类应用到wpf层
    public class ApiResponse<T>
    {
        
        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private T result;

        public T Result
        {
            get { return result; }
            set { result = value; }
        }

    }
}
