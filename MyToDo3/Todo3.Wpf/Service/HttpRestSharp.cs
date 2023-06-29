using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Todo3.Wpf.Shared;

namespace Todo3.Wpf.Service
{
    /// <summary>
    /// 封装一个请求类，以便service进行调用
    /// </summary>
    public class HttpRestSharp
    {
        private string apiUrl;

        private RestClient client { get; set; }

        public HttpRestSharp(string apiUrl)
        {
            this.apiUrl= apiUrl;
            //client = new RestClient();
        }


        public async Task<ApiResponse> ExecuteAsync(BaseRequst? parameter)
        {
            client = new RestClient(apiUrl + parameter.Route);
            var request = new RestRequest();//设置请求参数的对象,并对其相关的请求参数进行赋值
            request.Method = parameter.Method;
            request.AddHeader("Content-type", parameter.ContentType);
            if (parameter.Parameter != null)
                request.AddParameter("param", JsonConvert.SerializeObject(parameter.Parameter));//请求参数由string类型转为object类型
            //client.BaseUrl = new Uri(ApiUrl + baseRequst.Route);
            //上面设置完毕，下面开始请求
            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<ApiResponse>(response.Content);//返回对象转化为APiresponse中的类型
        }

        //泛型方法是代替Object类型的另一种方式
        public async Task<ApiResponse<T>> ExecuteAsync<T>(BaseRequst parameter)
        {
            client = new RestClient(apiUrl + parameter.Route);
            var request = new RestRequest();//设置请求参数的对象,并对其相关的请求参数进行赋值
            request.Method = parameter.Method;
            request.AddHeader("Content-type", parameter.ContentType);
            if (parameter.Parameter != null)
                request.AddParameter("param", JsonConvert.SerializeObject(parameter.Parameter));//请求参数由string类型转为object类型
            //client.BaseUrl = new Uri(ApiUrl + baseRequst.Route);
            //上面设置完毕，下面开始请求
            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);//返回对象转化为APiresponse中的类型
        }
    }
}