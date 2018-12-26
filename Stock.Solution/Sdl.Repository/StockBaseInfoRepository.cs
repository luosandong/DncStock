using Stock.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sdl.Repository
{
    public interface IStockBaseInfoRepository : IBaseRepository<StockBaseInfo>
    {

    }
    public class StockBaseInfoRepository: BaseRepository<StockBaseInfo>, IStockBaseInfoRepository
    {
    }
}
