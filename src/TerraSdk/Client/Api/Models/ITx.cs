using System.Collections.Generic;

namespace TerraSdk.Client.Api.Models
{
    public interface ITx
    {
        IList<IMsg> GetMsgs();
    }
}