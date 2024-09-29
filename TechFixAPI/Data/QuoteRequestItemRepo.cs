using TechFixAPI.Model;

namespace TechFixAPI.Data
{
    public class QuoteRequestItemRepo
    {
        private AppDBContext _dbContext;

        public QuoteRequestItemRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool CreateQuoteRequestItem(QuoteRequestItem quote_request_item)
        {
            try
            {
                if (quote_request_item != null)
                {
                    _dbContext.QuoteRequestItems.Add(quote_request_item);
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
        public bool UpdateQuoteRequestItem(QuoteRequestItem quote_request_item)
        {
            try
            {
                _dbContext.QuoteRequestItems.Update(quote_request_item);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteQuoteRequestItem(QuoteRequestItem quote_request_item)
        {
            try
            {
                _dbContext.QuoteRequestItems.Remove(quote_request_item);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<QuoteRequestItem> GetQuoteRequestItems()
        {
            try
            {
                return _dbContext.QuoteRequestItems.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public QuoteRequestItem? GetQuoteRequestItemByID(int id) // Mark as nullable
        {
            try
            {
                return _dbContext.QuoteRequestItems.FirstOrDefault(quote_request_item => quote_request_item.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<QuoteRequestItem> GetQuoteRequestItemsByQuoteRequestID(int id)
        {
            try
            {
                return _dbContext.QuoteRequestItems.Where(quote_request_item => quote_request_item.QuoteRequestId == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
