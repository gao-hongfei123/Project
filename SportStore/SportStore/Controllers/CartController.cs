using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    //访问购物车
    public class CartController : Controller
    {
        private IProductRepository productRepository;
        public CartController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public RedirectToActionResult AddToCart(int productId,string returnURL) {
            var product = productRepository.Products.Where(p => p.Id == productId).FirstOrDefault();
            if (product != null) {
                //Cart cart = GetCart();省略了
                Cart cart = new Cart();
                cart.AddItem(product, 1);
                 //SaveCart(cart);


            }
            return RedirectToAction("Index",new {returnURL});
        
        }
        //删除购物车中某个产品
        public RedirectToActionResult RemoveFromCart(int ProductId, string returnURL)
        { 
            var product = productRepository.Products.Where(p => p.Id == ProductId).FirstOrDefault();
            if (product != null) { 
             Cart cart = new Cart();
                cart.RemoveLine(product);
                //saveCart(product);
            }
            return RedirectToAction("index", new { returnURL });
        }

       /* public Cart GetCart()
        { 
            Cart cart = HttpContext.Session.
        }*/
    }
}
