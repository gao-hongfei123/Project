using MyBlog.IRespository;
using MyBlog.Model;
using SqlSugar;
using SqlSugar.IOC;
using System.Linq.Expressions;

namespace MyBlog.Respository
{
    public class BaseRespository<TEntity> :SimpleClient<TEntity> ,IBaseRespository<TEntity> where TEntity : class, new()
    {
        public BaseRespository(ISqlSugarClient context =null) : base(context)
        {
            base.Context= DbScoped.Sugar;
            base.Context.DbMaintenance.CreateDatabase();
            base.Context.CodeFirst.InitTables(typeof(BlogNews),typeof(TypeInfo),typeof(Writer));
        }

        //注册

        public async Task<bool> CreateAsync(TEntity enitity)
        {
            return await base.InsertAsync(enitity);
        }

        public async Task<bool> DeleteAsync(TEntity enitity)
        {
            return await base.DeleteAsync(enitity);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity,bool>> func)
        {
            return await base.GetSingleAsync(func);
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await base.GetListAsync();
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.GetListAsync(func);
        }
        //翻页
        public async  Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>().ToPageListAsync(page, size, total);
        }

        public async  Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>().Where(func).ToPageListAsync(page, size,total);
        }

        public async Task<bool> UpdateAsync(TEntity enitity)
        {
            return await base.UpdateAsync(enitity);
        }
    }
}