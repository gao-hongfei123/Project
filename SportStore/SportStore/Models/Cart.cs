namespace SportStore.Models
{
    //创建购物车类，控制器调用该类即可
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        //用户选择的某个商品添加到购物车
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else { 
                line.Quantity = quantity+1;
            }
        }
        //删除某个商品
        public virtual void RemoveLine(Product product) { 
            lineCollection.RemoveAll(p => p.Product.Id == product.Id);
        }
        //计算总量
        public virtual decimal ComputeTotalValue() {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }
        //清理购物车
        public virtual void Clear() { 
            lineCollection.Clear();
        }
        //返回所有产品
        public virtual IEnumerable<CartLine> Lines() {
            return lineCollection;
        }

    }

    //用户可以选择的商品和数量封装为类
        public class CartLine {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int  Quantity { get; set; }
    }
}
