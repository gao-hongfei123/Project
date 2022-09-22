using EfcoreTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


    using TestDbContext tb = new TestDbContext();
//添加
    /*var b1 = new Book { AuthorName = "zhangsan", Title = "c语言", Price = 59.8, PubTime = new DateTime(2019, 3, 1) };
    var b2 = new Book { AuthorName = "lisi", Title = "a语言", Price = 59.8, PubTime = new DateTime(2019, 3, 1) };
    var b3 = new Book { AuthorName = "wangwu", Title = "b语言", Price = 59.8, PubTime = new DateTime(2019, 3, 1) };
    var b4 = new Book { AuthorName = "zhaoliu", Title = "d语言", Price = 59.8, PubTime = new DateTime(2019, 3, 1) };
    tb.Books.Add(b1);
    tb.Books.Add(b2);
    tb.Books.Add(b3);
    tb.Books.Add(b4);
    await tb.SaveChangesAsync();
    Console.WriteLine("执行成功");*/

//查询
foreach (var a in tb.Books)
{
    Console.WriteLine(a.Title+a.Price+a.AuthorName);
}

//修改
var update = tb.Books.Single(b => b.AuthorName == "zhangsan");
update.AuthorName = "liuming";
await tb.SaveChangesAsync();

//删除
var delete = tb.Books.Single(a => a.AuthorName == "zhaoliu");
tb.Books.Remove(delete);
await tb.SaveChangesAsync();







