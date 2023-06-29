using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo3.Wpf.Shared;

namespace Todo3.Wpf.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly HttpRestSharp client;
        private readonly string serviceName;

        public BaseService(HttpRestSharp client,string serviceName)
        {
            this.client = client;
            this.serviceName = serviceName;
        }
        public async Task<ApiResponse<TEntity>> AddAsync(TEntity entity)
        {
            BaseRequst request = new BaseRequst();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Add";
            request.Parameter = entity;
            return await client.ExecuteAsync<TEntity>(request);
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            BaseRequst request = new BaseRequst();
            request.Method = RestSharp.Method.Delete;
            request.Route = $"api/{serviceName}/delete?id={id}";
            return await  client.ExecuteAsync(request);
        }

        public async Task<ApiResponse<PagedList<TEntity>>> GetAllAsync(Shared.QueryParameter parameter)
        {
            BaseRequst request = new BaseRequst();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/GetAll?pageIndex={parameter.PageIndex}"+$"&pagesize={parameter.PageSize}"+$"&search={parameter.Search}";
            return await client.ExecuteAsync<PagedList<TEntity>>(request);
        }

        public async Task<ApiResponse<TEntity>> GetSingleAsync(int id)
        {
            BaseRequst request = new BaseRequst();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/getSingle?id={id}";
            return await client.ExecuteAsync<TEntity>(request);
        }

        public async Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            BaseRequst request = new BaseRequst();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Update";
            request.Parameter = entity;
            return await client.ExecuteAsync<TEntity>(request);
        }

        
    }
}
