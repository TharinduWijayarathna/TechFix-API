using TechFixAPI.Model;

namespace TechFixAPI.Data
{
    public class QuoteRequestRepo
    {
        private AppDBContext _dbContext;

        public QuoteRequestRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool CreateQuoteRequest(QuoteRequest quote_request)
        {
            try
            {
                if (quote_request != null)
                {
                    _dbContext.QuoteRequests.Add(quote_request);
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
        public bool UpdateQuoteRequest(QuoteRequest quote_request)
        {
            try
            {
                _dbContext.QuoteRequests.Update(quote_request);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteQuoteRequest(QuoteRequest quote_request)
        {
            try
            {
                _dbContext.QuoteRequests.Remove(quote_request);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<QuoteRequest> GetQuoteRequests()
        {
            try
            {
                return _dbContext.QuoteRequests.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public QuoteRequest? GetQuoteRequestByID(int id) // Mark as nullable
        {
            try
            {
                return _dbContext.QuoteRequests.FirstOrDefault(quote_request => quote_request.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
