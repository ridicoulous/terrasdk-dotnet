using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TerraSdk.Core
{
    public class PublicKey
    {

        public PublicKey(string type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

    }
}


//import
//{ JSONSerializable }
//from '../util/json';

//export class PublicKey extends JSONSerializable<PublicKey.Data> {
//    constructor(
//public readonly type: PublicKey.Data['type'],
//public readonly value: PublicKey.Data['value']
//    ) {
//    super();
//}

//public static fromData(data: PublicKey.Data): PublicKey
//{
//    const { type, value } = data;
//    return new PublicKey(type, value);
//}

//public toData(): PublicKey.Data {
//    const { type, value } = this;
//    if (type === 'tendermint/PubKeySecp256k1' && typeof value === 'string')
//    {
//        return {
//            type,
//            value,
//        };
//    }
//    else if (
//        type === 'tendermint/PubKeyMultisigThreshold' &&
//                 typeof value !== 'string'
//        )
//    {
//        return {
//            type,
//            value,
//        };
//    }
//    throw new TypeError('invalid public key: type and value do not match');
//}
//}

//export namespace PublicKey
//{
//    export type Data = SimplePublicKey.Data | MultisigPublicKey.Data;
//}

//export namespace SimplePublicKey
//{
//    export interface Data
//    {
//        type: 'tendermint/PubKeySecp256k1';
//        value: string;
//    }
//}

//export namespace MultisigPublicKey
//{
//    export interface Data
//    {
//        type: 'tendermint/PubKeyMultisigThreshold';
//        value: {
//            threshold: string;
//            pubkeys: SimplePublicKey.Data[];
//        };
//}
//}
