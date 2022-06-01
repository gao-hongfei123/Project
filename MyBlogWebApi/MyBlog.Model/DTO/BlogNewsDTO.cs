using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.DTO
{
    public class BlogNewsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int BrowerCount { get; set; }
        public int LikeCount { get; set; }
        public int TypeId { get; set; }
        public int WriterId { get; set; }
        public string TypeName { get; set; }
        public int WriterName { get; set; }

    }
}
