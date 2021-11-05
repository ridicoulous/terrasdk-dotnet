using System.Collections.Generic;
using TerraSdk.Core;

namespace TerraSdk.Client.Api.Tx
{
    public interface ITx
    {
        IList<Msg> GetMsgs();
    }
}