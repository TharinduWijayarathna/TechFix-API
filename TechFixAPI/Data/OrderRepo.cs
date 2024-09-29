using TechFixAPI.Model;

namespace TechFixAPI.Data
{
    public class OrderRepo
    {
        private AppDBContext _dbContext;

        public OrderRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool CreateOrder(Order order)
        {
            try
            {
                if (order != null)
                {
                    _dbContext.Orders.Add(order);
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
        public bool UpdateOrder(Order order)
        {
            try
            {
                _dbContext.Orders.Update(order);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteOrder(Order order)
        {
            try
            {
                _dbContext.Orders.Remove(order);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Order> GetOrders()
        {
            try
            {
                return _dbContext.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Order? GetOrderByID(int id) // Mark as nullable
        {
            try
            {
                return _dbContext.Orders.FirstOrDefault(order => order.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
