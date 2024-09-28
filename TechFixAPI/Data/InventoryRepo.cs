using TechFixAPI.Model;

namespace TechFixAPI.Data
{
    public class InventoryRepo
    {
        private AppDBContext _dbContext;

        public InventoryRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool CreateInventory(Inventory inventory)
        {
            try
            {
                if (inventory != null)
                {
                    _dbContext.Inventories.Add(inventory);
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
        public bool UpdateInventory(Inventory inventory)
        {
            try
            {
                _dbContext.Inventories.Update(inventory);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteInventory(Inventory inventory)
        {
            try
            {
                _dbContext.Inventories.Remove(inventory);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Inventory> GetInventories()
        {
            try
            {
                return _dbContext.Inventories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Inventory? GetInventoryByID(int id) // Mark as nullable
        {
            try
            {
                return _dbContext.Inventories.FirstOrDefault(inventory => inventory.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

