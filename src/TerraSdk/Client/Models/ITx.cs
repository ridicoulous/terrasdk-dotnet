using System.Collections.Generic;

namespace TerraSdk.Client.Models
{
    public interface ITx
    {
        IList<IMsg> GetMsgs();
    }
}