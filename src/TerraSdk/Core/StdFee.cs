using Newtonsoft.Json;
using TerraSdk.Core.Bank;

namespace TerraSdk.Core
{
    /**
     * A transaction must include a fee, otherwise it will be rejected.
     */
    public class StdFee
    {
        [JsonProperty("amount")]
        public Coins Amount { get; }
        [JsonProperty("gas"), JsonConverter(typeof(StringJsonConverter))]
        public int Gas { get; }
        
        /**
         * Creates a new StdFee object.
         * @param gas gas limit
         * @param amount amount to be paid to validator
         */
        public StdFee(int gas, Coins amount)
        {
            Gas = gas;
            Amount = amount;
        }
    }
}


//import { JSONSerializable } from '../util/json';
//import { Coins } from './Coins';
//import { Int } from './numeric';

///**
// * A transaction must include a fee, otherwise it will be rejected.
// */
//export class StdFee extends JSONSerializable<StdFee.MsgData> {
//  /** Fee amount to be paid */
//  public readonly amount: Coins;

//  /**
//   * Creates a new StdFee object.
//   * @param gas gas limit
//   * @param amount amount to be paid to validator
//   */
//  constructor(public readonly gas: number, amount: Coins.Input) {
//    super();
//    this.amount = new Coins(amount);
//  }

//  public static fromData(data: StdFee.MsgData): StdFee {
//    const { gas, amount } = data;
//    return new StdFee(Number.parseInt(gas), Coins.fromData(amount));
//  }

//  public toData(): StdFee.MsgData {
//    return {
//      gas: new Int(this.gas).toString(),
//      amount: this.amount.toData(),
//    };
//  }

//  /**
//   * Gets the mininimum gas prices implied by the fee. Minimum gas prices are `fee amount / gas`.
//   */
//  public gasPrices(): Coins {
//    return this.amount.toDecCoins().div(this.gas);
//  }
//}

//export namespace StdFee {
//  export interface MsgData {
//    gas: string;
//    amount: Coins.MsgData;
//  }
//}
