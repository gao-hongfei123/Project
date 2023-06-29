using Todo3.Wpf.Shared;

namespace MyTodo3.Webapi3.Service
{
    public interface IBaseService<T> where T : class
    {
        public Task<ApiResponse> GetAsync(int id);
        public Task<ApiResponse> GetAllAsync(QueryParameter parameter );
        public Task<ApiResponse> DeleteAsync(int id);
        public Task<ApiResponse> UpdateAsync(T model);
        public Task<ApiResponse> AddAsync(T model);
    }
}
