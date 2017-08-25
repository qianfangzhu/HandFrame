using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hand.Enum
{
    public enum CommonEnum
    {
        [Description("离职")]
        //离职
        Quit = 0,

        [Description("在职")]
        //在职
        Job = 1
    }
}
