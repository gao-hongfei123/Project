using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MyTodo3.Webapi3.Context;

namespace MyTodo3.Webapi3.Repository
{
    public class MemoRepository : Repository<Memo>, IRepository<Memo>
    {
        public MemoRepository(MyTodo3DbContext dbContext) : base(dbContext)
        {
        }
    }
}
