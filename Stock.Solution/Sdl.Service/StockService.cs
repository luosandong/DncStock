using Sdl.Repository;
using Stock.Models;
using System;

namespace Sdl.Service
{
    public interface IStockService
    {
        bool SaveStock(StockBaseInfo baseInfo); 
    }

    public class StockService: IStockService
    {
        private IStockBaseInfoRepository _baseInfo;
        private IStockDayInfoRepository _dayInfo;
        public StockService(IStockBaseInfoRepository baseInfo, IStockDayInfoRepository dayInfo)
        {
            _baseInfo = baseInfo;
            _dayInfo = dayInfo;
        }

        public bool SaveStock(StockBaseInfo baseInfo)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
