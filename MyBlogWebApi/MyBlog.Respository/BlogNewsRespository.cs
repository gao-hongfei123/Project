using MyBlog.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Model;

namespace MyBlog.Respository
{
    public class BlogNewsRespository:BaseRespository<BlogNews>,BlogNewsIRespository
    {
    }
}
