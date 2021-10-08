using Newtonsoft.Json;
using TerraSdk.Core.Bank;

namespace TerraSdk.Core
{
    /**
     * A sign message is a msgData structure that is used to create a [[StdSignature]] to be later
     * appended to the list of signatures in an [[StdTx]]. Essentially, it contains all the
     * information needed to sign and build a transaction, and can be described as an
     * "unsigned transaction."
     */
    public class StdSignMsg 
    {
        [JsonProperty("account_number"), JsonConverter(typeof(StringJsonConverter))]
        public ulong AccountNumber { get; }
        [JsonProperty("chain_id")]
        public string ChainId { get; }
        
        [JsonProperty("fee")]
        public StdFee Fee { get; }

        [JsonProperty("memo")]
        public string Memo { get; }

        [JsonProperty("msgs")]
        public Msg[] Msgs { get; }

        [JsonProperty("sequence"), JsonConverter(typeof(StringJsonConverter))]
        public ulong Sequence { get; }
        
        [JsonProperty("timeout_height"), JsonConverter(typeof(StringJsonConverter))]
        //[JsonIgnore]
        public int? TimeoutHeight{ get; }

  
        /**
         *
         * @param chain_id ID of blockchain to submit transaction to
         * @param account_number account number on blockchain
         * @param sequence Sequence number (nonce), number of signed previous transactions by
         *    account included on the blockchain at time of broadcast.
         * @param fee transaction fee
         * @param msgs list of messages to include
         * @param memo optional note
         */
        public StdSignMsg(string chainId, ulong accountNumber, ulong sequence, StdFee fee, Msg[] msgs, string memo = "", int? timeoutHeight=null)
        {

            ChainId = chainId;
            AccountNumber = accountNumber;
            Sequence = sequence;
            Fee = fee;
            Msgs = msgs;
            Memo = memo;
            TimeoutHeight = timeoutHeight;
        }


    }
}


//import { StdFee } from './StdFee';
//import { Msg } from './Msg';
//import { JSONSerializable } from '../util/json';
//import { StdTx } from './StdTx';

///**
// * A sign message is a msgData structure that is used to create a [[StdSignature]] to be later
// * appended to the list of signatures in an [[StdTx]]. Essentially, it contains all the
// * information needed to sign and build a transaction, and can be described as an
// * "unsigned transaction."
// */
//export class StdSignMsg extends JSONSerializable<StdSignMsg.MsgData> {
//  /**
//   *
//   * @param chain_id ID of blockchain to submit transaction to
//   * @param account_number account number on blockchain
//   * @param sequence Sequence number (nonce), number of signed previous transactions by
//   *    account included on the blockchain at time of broadcast.
//   * @param fee transaction fee
//   * @param msgs list of messages to include
//   * @param memo optional note
//   */
//  constructor(
//    public chain_id: string,
//    public account_number: number,
//    public sequence: number,
//    public fee: StdFee,
//    public msgs: Msg[],
//    public memo: string = '',
//    public timeout_height: number = 0
//  ) {
//    super();
//  }

//  public toData(): StdSignMsg.MsgData {
//    const {
//      chain_id,
//      account_number,
//      sequence,
//      fee,
//      msgs,
//      memo,
//      timeout_height,
//    } = this;
//    return {
//      chain_id,
//      account_number: account_number.toString(),
//      sequence: sequence.toString(),
//      fee: fee.toData(),
//      msgs: msgs.map(m => m.toData()),
//      memo,
//      timeout_height:
//        timeout_height !== 0 ? timeout_height.toFixed() : undefined,
//    };
//  }

//  public static fromData(msgData: StdSignMsg.MsgData): StdSignMsg {
//    const {
//      chain_id,
//      account_number,
//      sequence,
//      fee,
//      msgs,
//      memo,
//      timeout_height,
//    } = msgData;
//    return new StdSignMsg(
//      chain_id,
//      Number.parseInt(account_number) || 0,
//      Number.parseInt(sequence) || 0,
//      StdFee.fromData(fee),
//      msgs.map(m => Msg.fromData(m)),
//      memo,
//      Number.parseInt(timeout_height ?? '0')
//    );
//  }

//  /**
//   * You get the [[StdTx]] value from a `StdSignMsg` (without the signature).
//   */
//  public toStdTx(): StdTx {
//    const { fee, msgs, memo, timeout_height } = this;
//    return new StdTx(msgs, fee, [], memo, timeout_height);
//  }
//}

//export namespace StdSignMsg {
//  export interface MsgData {
//    chain_id: string;
//    account_number: string;
//    sequence: string;
//    fee: StdFee.MsgData;
//    msgs: Msg.MsgData[];
//    memo: string;
//    timeout_height?: string;
//  }
//}
