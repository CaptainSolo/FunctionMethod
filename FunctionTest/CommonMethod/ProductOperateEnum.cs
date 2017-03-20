using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethod
{
    /// <summary>
    /// 线路操作日志枚举
    /// 操作类型 1、基本信息，2、产品推荐，3、产品标签，4、线路行程，5、重要信息，6、费用详情，7、预订须知，8、特殊人群，9、其他，
    /// 10、团期报价 ，11、交通资源，12、行程资源-交通信息，13、行程资源-酒店信息，14、行程资源-其他服务，15、销售配置，16、操作记录
    /// </summary>
    public enum ProductOperateEnum
    {
        /// <summary>
        /// 基本信息 1
        /// </summary>
        [Description("基本信息")]
        Basic = 1,

        /// <summary>
        /// 产品推荐 2
        /// </summary>
        [Description("产品推荐")]
        Recommend = 2,

        /// <summary>
        /// 产品标签 3
        /// </summary>
        [Description("产品标签")]
        Label = 3,

        /// <summary>
        /// 线路行程 4
        /// </summary>
        [Description("线路行程")]
        Journey = 4,

        /// <summary>
        /// 重要信息 5
        /// </summary>
        [Description("重要信息")]
        Important = 5,

        /// <summary>
        /// 费用详情 6
        /// </summary>
        [Description("费用详情")]
        FeeDescription = 6,

        /// <summary>
        /// 预订须知 7
        /// </summary>
        [Description("预订须知")]
        BookingNotice = 7,

        /// <summary>
        /// 特殊人群 8
        /// </summary>
        [Description("特殊人群")]
        Limit = 8,

        /// <summary>
        /// 其他 9
        /// </summary>
        [Description("其他")]
        Other = 9,

        /// <summary>
        /// 团期报价 10
        /// </summary>
        [Description("团期报价")]
        ProductPrice = 10,

        /// <summary>
        /// 交通资源 11
        /// </summary>
        [Description("交通资源")]
        TrafficType = 11,

        /// <summary>
        /// 行程资源-交通信息 12
        /// </summary>
        [Description("行程资源-交通信息")]
        Trans = 12,

        /// <summary>
        /// 行程资源-酒店信息 13
        /// </summary>
        [Description("行程资源-酒店信息")]
        Hotel = 13,

        /// <summary>
        /// 行程资源-其他服务 14
        /// </summary>
        [Description("行程资源-其他服务")]
        OtherService = 14,

        /// <summary>
        /// 销售配置 15
        /// </summary>
        [Description("销售配置")]
        ReleaseChannels = 15,

        /// <summary>
        /// 操作记录 16
        /// </summary>
        [Description("操作记录")]
        Operate = 16,

        /// <summary>
        /// 导入行程 17
        /// </summary>
        [Description("导入行程")]
        ImportStroke = 17

    }
}
