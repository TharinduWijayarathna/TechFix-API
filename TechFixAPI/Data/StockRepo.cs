﻿using TechFixAPI.Model;
using System.Xml.Linq;
namespace TechFixAPI.Data
{
    public class StockRepo
    {
        private AppDBContext _dbContext;

        public StockRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool CreateStock(Stock stock)
        {
            try
            {
                if (stock != null)
                {
                    _dbContext.Stocks.Add(stock);
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
        public bool UpdateStock(Stock stock)
        {
            try
            {
                _dbContext.Stocks.Update(stock);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteStock(Stock stock)
        {
            try
            {
                _dbContext.Stocks.Remove(stock);
                return Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Stock> GetStocks()
        {
            try
            {
                return _dbContext.Stocks.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Stock? GetStockByID(int id) // Mark as nullable
        {
            try
            {
                return _dbContext.Stocks.FirstOrDefault(stock => stock.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
