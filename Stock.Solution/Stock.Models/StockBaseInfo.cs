using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Models
{
    /// <summary>
    /// 股票基本信息实体类
    /// </summary>
    [Table(Name ="SctockBaseInfo")]
    public class StockBaseInfo
    {
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// 股票标识代码 带交易所字母
        /// </summary>
        public string IdentityCode { get; set; }
        /// <summary>
        /// 股票代码 
        /// </summary>
        public string StockCode { get; set; }
        /// <summary>
        /// 股票名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 交易所
        /// </summary>
        public string Exchange { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
