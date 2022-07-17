namespace SportStore.Models.ViewModels
{
    //没引入identity efcore框架
    //只针对用户管理使用identity efcore，商品中使用的仍然是efcore，所以需要两个连接字符串
    public class AppIdentityDbContext:identitydbcontext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
    }
}
