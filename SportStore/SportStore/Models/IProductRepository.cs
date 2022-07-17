namespace SportStore.Models
{
    //依赖于该接口的类可以获得product对象
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
