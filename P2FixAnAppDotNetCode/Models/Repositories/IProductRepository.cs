namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        Product[] GetAllProducts();

        Product GetProductById(int productId);

        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
