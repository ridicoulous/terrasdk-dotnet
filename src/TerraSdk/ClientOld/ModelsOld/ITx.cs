using System.Collections.Generic;
using TerraSdk.Core;

namespace TerraSdk.ClientOld.ModelsOld
{
    public interface ITx
    {
        IList<Msg> GetMsgs();
    }
}