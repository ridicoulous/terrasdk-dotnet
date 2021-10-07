using System;
using Newtonsoft.Json;

namespace TerraSdk.Core
{
    ///**
    // * A signature consists of a message signature with a public key to verify its validity.
    // * You likely will not need to work with StdSignature objects directly as they are automatically created for you.
    // */
    public class StdSignature
    {

        public StdSignature()
        {
            
        }

        //  /**
        //   *
        //   * @param signature Message signature string (base64-encoded).
        //   * @param pub_key Public key
        //   */
        public StdSignature(string signature, PublicKey publicKey)
        {
  
            Signature= signature;
            PublicKey = publicKey;
        }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("pub_key")]
        public PublicKey PublicKey { get; init; }
    }
}
