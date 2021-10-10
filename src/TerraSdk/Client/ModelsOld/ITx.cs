using System.Collections.Generic;
using TerraSdk.Core;

namespace TerraSdk.Client.ModelsOld
{
    public interface ITx
    {
        IList<Msg> GetMsgs();
    }
}