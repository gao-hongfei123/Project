namespace SportStore.Models
{
    //模拟数据库中的数据
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{ Name="football",Price=25},
            new Product{ Name="RunningShoe",Price=75},
            new Product{ Name="basketball",Price=45}
        }.AsQueryable();
    }
}
