namespace SportsStore2.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products
        {
            get;

        }
    }

}