using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo3.Wpf.Shared.Dtos;

namespace Todo3.Wpf.Service
{
    public class TodoService : BaseService<TodoDto>,ITodoService
    {
        public TodoService(HttpRestSharp client) : base(client, "Todo")
        {
        }
    }
}
