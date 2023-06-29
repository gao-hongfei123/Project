using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MyTodo3.Webapi3.Context;
using Todo3.Wpf.Shared.Dtos;

namespace MyTodo3.Webapi3.Repository
{
    public class TodoRepository : Repository<Todo>, IRepository<Todo>

    {
        public TodoRepository(MyTodo3DbContext dbContext) : base(dbContext)
        {
        }
    }
}
