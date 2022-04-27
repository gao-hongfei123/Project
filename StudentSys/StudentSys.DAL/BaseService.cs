using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    //该方法需要使用using释放接口，同时T是BaseEntity的子类，T可实例化
    public class BaseService<T> : IDisposable where T : BaseEntity, new()
    {
        protected readonly StudentContext _db;
        public BaseService(StudentContext db)
        { 
            _db = db;//获取学生上下文,获得对象。
        }
        public void Dispose()
        {
            _db.Dispose();

        }
        //增,如果多条添加，那么调用多次数据库命令，消耗资源，所以设置一个saved参数
        public async Task CreateAsync(T t, bool saved = true)
        { 
        _db.Set<T>().Add(t);
            if (saved)
            { 
                await _db.SaveChangesAsync();//如果插入五条数据，saved为true，则保存，若不传第二个参数，则立即保存，若传入第二个参数为false，则不会保存，直至save为true时
            }
        }
        //第五条数据插入时执行该方法
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        //删,乱七八糟
        public async Task RemoveAsync(Guid id, bool saved = true)
        {
            T t = new T()
            {
                Id = id
            };//创建一个T对象
            _db.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
            t.IsRemoved = true;
            if (saved)
            { 
                await SaveAsync();
            }
        }

        //改
        public async Task EditAsync(T t, bool saved = true)
        {
            _db.Entry(t).State=System.Data.Entity.EntityState.Modified;
            if (saved)
            {
                await SaveAsync();
            }
        }
        //查
        public IQueryable<T> GetAll()
        { 
            return _db.Set<T>().AsNoTracking().Where(x=>!x.IsRemoved);
        }
        public async Task<T> GetOne(Guid id)
        {
            //return await GetAll().First(x => x.Id == id);报错
            return null;
        }
    }
}
