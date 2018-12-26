using Stock.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sdl.Repository
{
    public interface IStockDayInfoRepository:IBaseRepository<StockDayInfo>
    {
    }

    public class StockDayInfoRepository:BaseRepository<StockDayInfo>, IStockDayInfoRepository
    {

    }
}
