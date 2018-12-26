using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Models
{
    /// <summary>
    /// 股票的每日行情
    /// </summary>
    [Table(Name ="StockDayInfo")]
    public class StockDayInfo
    {
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// 股票代码
        /// </summary>
        public string IdentityCode { get; set; }
        public string StockName { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 开盘价
        /// </summary>
        public decimal StartPrice { get; set; }
        /// <summary>
        /// 收盘价
        /// </summary>
        public decimal EndPrice { get; set; }
        /// <summary>
        /// 涨跌金额，，，，，，
        /// </summary>
        public decimal ChangePrice { get; set; }
        /// <summary>
        /// 涨跌幅度
        /// </summary>
        public string ChangeRatio { get; set; }
        /// <summary>
        /// 最低价格
        /// </summary>
        public decimal LowPrice { get; set; }
        /// <summary>
        /// 最高价格
        /// </summary>
        public decimal HighPrice { get; set; }
        /// <summary>
        /// 总手
        /// </summary>
        public decimal TotalHand { get; set; }
        /// <summary>
        /// 总金额(万)
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 换手率
        /// </summary>
        public string HandRate { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
