using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo3.Webapi3.Context
{
    public class MyTodo3DbContext:DbContext
    {
        public MyTodo3DbContext(DbContextOptions options):base(options)
        {
            

        }

        public DbSet<Todo> todos { get; set; }
        public DbSet<Memo> memos { get; set; }
        public DbSet<User> users { get; set; }
        
    }
}
