namespace SportStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo pageInfo { get; set; }
        //用来增加导航栏
        public string CurrentCategory { get; set; }

    }
}
