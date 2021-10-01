using System;
using System.Linq;
using System.Text;

namespace TerraSdk.Util
{
    internal static class ArrayUtils
    {
        public static byte[] Concat(byte[] arr, params byte[][] arrs)
        {
            var len = arr.Length + arrs.Sum(a => a.Length);
            var ret = new byte[len];
            Buffer.BlockCopy(arr, 0, ret, 0, arr.Length);
            var pos = arr.Length;
            foreach (var a in arrs)
            {
                Buffer.BlockCopy(a, 0, ret, pos, a.Length);
                pos += a.Length;
            }
            return ret;
        }


        public static byte[] ToByteArray(this string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }


    }
}