using System.Collections.Generic;
using TerraSdk.Core;

namespace TerraSdk.Client.Models
{
    public interface ITx
    {
        IList<Msg> GetMsgs();
    }
}