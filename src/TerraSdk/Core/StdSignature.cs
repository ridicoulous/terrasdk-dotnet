using System.Collections.Generic;

namespace TerraSdk.Core
{
    public class StdSignature
    {
        public byte[] Value { get; }

        public StdSignature(byte[] value)
        {
            Value = value;
        }
     
    }
}


//import { PublicKey } from './PublicKey';
//import { JSONSerializable } from '../util/json';

///**
// * A signature consists of a message signature with a public key to verify its validity.
// * You likely will not need to work with StdSignature objects directly as they are automatically created for you.
// */
//export class StdSignature extends JSONSerializable<StdSignature.MsgData> {
//  /**
//   *
//   * @param signature Message signature string (base64-encoded).
//   * @param pub_key Public key
//   */
//  constructor(public signature: string, public pub_key: PublicKey) {
//    super();
//  }

//  public static fromData(data: StdSignature.MsgData): StdSignature {
//    const { signature, pub_key } = data;
//    return new StdSignature(
//      signature,
//      PublicKey.fromData(
//        pub_key || {
//          type: 'tendermint/PubKeySecp256k1',
//          value: '',
//        }
//      )
//    );
//  }

//  public toData(): StdSignature.MsgData {
//    const { signature, pub_key } = this;
//    return {
//      signature,
//      pub_key: pub_key?.toData(),
//    };
//  }
//}
//export namespace StdSignature {
//  export interface MsgData {
//    signature: string;
//    pub_key: PublicKey.MsgData | null;
//  }
//}
