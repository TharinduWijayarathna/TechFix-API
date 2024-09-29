using TechFixAPI.Model;

namespace TechFixAPI.Data
{
    public class OrderItemRepo
    {
         private AppDBContext _dbContext;

        public OrderItemRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool CreateOrderItem(OrderItem order_item)
        {
            try
            {
                if (order_item != null)
                {
                    _dbContext.OrderItems.Add(order_item);
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
        public bool UpdateOrderItem(OrderItem order_item)
        {
            try
            {
                _dbContext.OrderItems.Update(order_item);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteOrderItem(OrderItem order_item)
        {
            try
            {
                _dbContext.OrderItems.Remove(order_item);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<OrderItem> GetOrderItems()
        {
            try
            {
                return _dbContext.OrderItems.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderItem? GetOrderItemByID(int id) // Mark as nullable
        {
            try
            {
                return _dbContext.OrderItems.FirstOrDefault(order_item => order_item.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
