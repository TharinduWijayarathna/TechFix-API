using TechFixAPI.Model;

namespace TechFixAPI.Data
{
    public class QuotationRepo
    {
        private AppDBContext _dbContext;

        public QuotationRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool CreateQuotation(Quotation quotation)
        {
            try
            {
                if (quotation != null)
                {
                    _dbContext.Quotations.Add(quotation);
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
        public bool UpdateQuotation(Quotation quotation)
        {
            try
            {
                _dbContext.Quotations.Update(quotation);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteQuotation(Quotation quotation)
        {
            try
            {
                _dbContext.Quotations.Remove(quotation);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Quotation> GetQuotations()
        {
            try
            {
                return _dbContext.Quotations.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Quotation? GetQuotationByID(int id) // Mark as nullable
        {
            try
            {
                return _dbContext.Quotations.FirstOrDefault(quotation => quotation.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Quotation> GetQuotationsBySupplierID(int id)
        {
            try
            {
                return _dbContext.Quotations.Where(quotation => quotation.SupplierId == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
