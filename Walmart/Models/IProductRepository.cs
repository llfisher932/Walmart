namespace Walmart.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products
        {
            get;

        }
    }

}