using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo3.Wpf.Service
{
    //封装基本的请求参数
    public class BaseRequst
    {
        public Method Method { get; set; }

        public string Route { get; set; }

        public string ContentType { get; set; } = "application/json";

        //前端的请求实体
        public Object Parameter { get; set; }
    }
}
