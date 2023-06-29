using Arch.EntityFrameworkCore.UnitOfWork;
using MyTodo3.Webapi3.Context;

namespace MyTodo3.Webapi3.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>

    {
        public UserRepository(MyTodo3DbContext dbContext) : base(dbContext)
        {
        }
    }
}

