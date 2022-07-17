using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class BlogNews:BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(30)")]
        public string Title { get; set; }
        [SugarColumn(ColumnDataType = "text")]
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int BrowerCount { get; set; }
        public int LikeCount { get; set; }
        public int TypeId { get; set; }
        public int WriterId { get; set; }
        [SugarColumn(IsIgnore =true)]
        [Navigate(NavigateType.OneToOne, nameof(TypeId))]
        public TypeInfo TypeInfo { get; set; }
        [SugarColumn(IsIgnore =true)]
        [Navigate(NavigateType.OneToOne, nameof(WriterId))]
        public Writer Writer { get; set; }

    }
}
