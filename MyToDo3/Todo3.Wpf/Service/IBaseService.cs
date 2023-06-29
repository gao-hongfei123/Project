using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo3.Wpf.Shared;

namespace Todo3.Wpf.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        public Task<ApiResponse<TEntity>> AddAsync(TEntity entity);

        public Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity);
        //不返回实体，所以不使用泛型
        public Task<ApiResponse> DeleteAsync(int id);

        public Task<ApiResponse<TEntity>> GetSingleAsync(int id);

        public Task<ApiResponse<PagedList<TEntity>>> GetAllAsync(QueryParameter parameter);
    }
}
