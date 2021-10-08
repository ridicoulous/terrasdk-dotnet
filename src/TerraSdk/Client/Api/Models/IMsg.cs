﻿namespace TerraSdk.Client.Api.Models
{
    public interface IMsg
    {
        /// <summary>
        /// Object, json representation of which used to make byte array for signing.
        /// In Terra sources similar method returns byte[], but the whole thing will fail
        /// if that array isn't UTF8 encoded json. 
        /// </summary>
        /// <returns></returns>
        object SignBytesObject();
    }
}