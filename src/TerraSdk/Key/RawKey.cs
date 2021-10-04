using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraSdk.Key
{
    public class RawKey : Key
    {
        public override Task<byte[]> Sign(byte[] payload)
        {
            throw new NotImplementedException();
        }
    }
}
