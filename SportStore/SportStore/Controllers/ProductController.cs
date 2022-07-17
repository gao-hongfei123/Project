using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    //模拟数据库生产产品
    public class ProductController : Controller
    {
        private readonly IProductRepository Repository;
        int pagesize = 4;//每页4个产品
        public ProductController(IProductRepository repository)
        {
            this.Repository = repository;
        }

        //1.实现分页：如果访问不带参数的List方法，则默认page为1，表示第几页
        //2.增加导航功能 ：根据产品种类
        public ViewResult List(string category,  int page = 1) => View(new ProductListViewModel {
            Products = Repository.Products.Where(p=>category==null || p.Category==category )
                                          .OrderBy(p => p.Id)
                                          .Skip((page - 1) * pagesize)
                                          .Take(pagesize),
            pageInfo = new PageInfo {
                CurrentPage = page,
                ItemsPerPage = pagesize,
                //分类之后的某个种类对应的页数。
                TotalItems = category == null? Repository.Products.Count():Repository.Products.Where(e=>e.Category==category).Count(),
                
            }
        });
    }
}
