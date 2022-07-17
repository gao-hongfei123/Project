namespace SportStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public EFProductRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IQueryable<Product> Products => applicationDbContext.Products;
    }
}
