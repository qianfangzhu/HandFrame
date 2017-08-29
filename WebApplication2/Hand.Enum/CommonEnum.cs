using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hand.Enum
{
    /// <summary>
    /// 朱乾方
    /// 20170829
    /// 是否在职
    /// </summary>
    public enum CommonEnum
    {
        [Description("离职")]
        //离职
        Quit = 0,

        [Description("在职")]
        //在职
        Job = 1
    }

    /// <summary>
    /// 朱乾方
    /// 20170829
    /// 工作流审批状态
    /// </summary>
    public enum WorkStatusEnum
    {
        //已通过
        [Description("已通过")]
        HavePassed=0,

        //已驳回
        [Description("已驳回")]
        Rejected=1,

        //审批中
        [Description("审批中")]
        Approval=2
    }
}
