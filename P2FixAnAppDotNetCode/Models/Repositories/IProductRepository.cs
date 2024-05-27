using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product GetProductById(int productId);

        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
