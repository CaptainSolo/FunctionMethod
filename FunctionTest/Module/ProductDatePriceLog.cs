using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class ProductDatePriceLog 
    {
        /// 产品Id
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// 报价方案Id
        /// <summary>
        /// 报价方案Id
        /// </summary>
        public int SchemeId { get; set; }

        /// 操作团期
        /// <summary>
        /// 操作团期
        /// </summary>
        public DateTime _priceDate;

        /// 操作团期
        /// <summary>
        /// 操作团期
        /// </summary>
        public DateTime PriceDate
        {
            get
            {
                return _priceDate.ToLocalTime();
            }
            set
            {
                _priceDate = value.ToUniversalTime();
            }
        }

        /// 操作类型 1-操作结算价、库存、清位、停团  2-操作卖价
        /// <summary>
        /// 操作类型 1-操作结算价、库存、清位、停团  2-操作卖价
        /// </summary>
        public int OperateType { get; set; }

        /// 操作人Id
        /// <summary>
        /// 操作人Id
        /// </summary>
        public int OperatorId { get; set; }

        /// 操作人名称
        /// <summary>
        /// 操作人名称
        /// </summary>
        public string OperatorName { get; set; }

        /// 操作时间
        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime _operateTime;

        /// 操作时间
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTime
        {
            get
            {
                return _operateTime.ToLocalTime();
            }
            set
            {
                _operateTime = value.ToUniversalTime();
            }
        }

        /// 成人结算价
        /// <summary>
        /// 成人结算价
        /// </summary>
        public decimal ContractAdultPrice { get; set; }

        /// 成人销售价
        /// <summary>
        /// 成人销售价
        /// </summary>
        public decimal AdultPrice { get; set; }

        /// 儿童结算价
        /// <summary>
        /// 儿童结算价
        /// </summary>
        public decimal ContractChildPrice { get; set; }

        /// 儿童销售价
        /// <summary>
        /// 儿童销售价
        /// </summary>
        public decimal ChildPrice { get; set; }

        /// 单房差结算价
        /// <summary>
        /// 单房差结算价
        /// </summary>
        public decimal ContractRoomAddPrice { get; set; }

        ///  单房差销售价
        /// <summary>
        ///  单房差销售价
        /// </summary>
        public decimal RoomAddPrice { get; set; }

        /// 销售价操作信息
        /// <summary>
        /// 销售价操作信息
        /// </summary>
        public string OperateSalePriceContext { get; set; }

        /// 结算价操作信息
        /// <summary>
        /// 结算价操作信息
        /// </summary>
        public string OperateContractPriceContext { get; set; }

        /// 库存、清位时间、停团操作信息
        /// <summary>
        /// 库存、清位时间、停团操作信息
        /// </summary>
        public string OperateUtilityContext { get; set; }

        /// 操作备注
        /// <summary>
        /// 操作备注
        /// </summary>
        public string OperateExt { get; set; }

        /// 操作站点环境 站点名称
        /// <summary>
        /// 操作站点环境 站点名称
        /// </summary>
        public string OperateCondition { get; set; }

        /// 操作时间描述
        /// <summary>
        /// 操作时间描述
        /// </summary>
        
        public string OperateTimeDesc { get; set; }

        /// 操作类型描述
        /// <summary>
        /// 操作类型描述
        /// </summary>
        
        public string OperateTypeDesc { get; set; }
    }
}
