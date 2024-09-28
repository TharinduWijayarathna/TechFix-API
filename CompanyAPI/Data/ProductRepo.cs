using CompanyAPI.Model;
namespace CompanyAPI.Data
{
    public class ProductRepo
    {
        private AppDBContext _dbContext;

        public ProductRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool CreateProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    _dbContext.Products.Add(product);
                    return Save();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Save()
        {
            try
            {
                int count = _dbContext.SaveChanges();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateProduct(Product product)
        {
            try
            {
                _dbContext.Products.Update(product);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteProduct(Product product)
        {
            try
            {
                _dbContext.Products.Remove(product);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return _dbContext.Products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Product? GetProductByID(int id) // Mark as nullable
        {
            try
            {
                return _dbContext.Products.FirstOrDefault(product => product.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
