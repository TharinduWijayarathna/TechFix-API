using TechFixAPI.Model;

namespace TechFixAPI.Data
{
    public class QuotationItemRepo
    {
        private AppDBContext _dbContext;

        public QuotationItemRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool CreateQuotationItem(QuotationItem quotation_item)
        {
            try
            {
                if (quotation_item != null)
                {
                    _dbContext.QuotationItems.Add(quotation_item);
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
        public bool UpdateQuotationItem(QuotationItem quotation_item)
        {
            try
            {
                _dbContext.QuotationItems.Update(quotation_item);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteQuotationItem(QuotationItem quotation_item)
        {
            try
            {
                _dbContext.QuotationItems.Remove(quotation_item);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<QuotationItem> GetQuotationItems()
        {
            try
            {
                return _dbContext.QuotationItems.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public QuotationItem? GetQuotationItemByID(int id) // Mark as nullable
        {
            try
            {
                return _dbContext.QuotationItems.FirstOrDefault(quotation_item => quotation_item.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<QuotationItem> GetQuotationItemsByQuotationID(int id)
        {
            try
            {
                return _dbContext.QuotationItems.Where(quotation_item => quotation_item.QuotationId == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
