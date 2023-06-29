using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using MyTodo3.Webapi3.Context;
using System.Reflection.Metadata;
using Todo3.Wpf.Shared;
using Todo3.Wpf.Shared.Dtos;

namespace MyTodo3.Webapi3.Service
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public TodoService(IUnitOfWork work, IMapper mapper)
        {
            this.work = work;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(TodoDto model)
        {

            try
            {
                var todo = mapper.Map<Todo>(model);
                var respository = work.GetRepository<Todo>();
                var result = await respository.InsertAsync(todo);
                if (await work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, model);
                }
                else return new ApiResponse(false, "添加失败");
            }
            catch (Exception ex)
            {

               throw new Exception(ex.Message);
            }
            
            
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var respository = work.GetRepository<Todo>();
                var result = await respository.GetFirstOrDefaultAsync(predicate:x=>x.Id==id);
                respository.Delete(result);
                if (await work.SaveChangesAsync() > 0)
                { 
                    return new ApiResponse(true, "删除成功");
                }
                else return new ApiResponse(false, "删除失败");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter )
        {
            try
            {
                var respository = work.GetRepository<Todo>();
                var result = await respository.GetPagedListAsync(predicate: x => String.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search),
                pageIndex: parameter.PageIndex,
                pageSize: parameter.PageSize,
                orderBy: source => source.OrderByDescending(t => t.UpdateTime));

                return new ApiResponse(true, result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAsync(int id)
        {
            try
            {
                var respository = work.GetRepository<Todo>();
                var result = await respository.GetFirstOrDefaultAsync(predicate:x=>x.Id==id);
               
                    return new ApiResponse(true, result);
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(TodoDto model)
        {
            try
            {
                var todo = mapper.Map<Todo>(model);
                var respository = work.GetRepository<Todo>();
                var result = await respository.GetFirstOrDefaultAsync(predicate:x=>x.Id==todo.Id);
                result.Status = todo.Status;
                result.Content = todo.Content;
                result.CreateTime = todo.CreateTime;
                result.UpdateTime = todo.UpdateTime;
                result.Title    = todo.Title;
                respository.Update(result);
                if (await work.SaveChangesAsync() >0)
                {
                    return new ApiResponse(true, model);
                }
                else return new ApiResponse(false, "修改失败");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
