using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraSdk.Core
{
    public abstract class Msg
    {
        public abstract MsgData ToData();
    }



}
