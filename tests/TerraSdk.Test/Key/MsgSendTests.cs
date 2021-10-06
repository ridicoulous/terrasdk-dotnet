using Newtonsoft.Json;
using TerraSdk.Common;
using TerraSdk.Core;
using TerraSdk.Core.Bank.Msgs;
using Xunit;

namespace TerraSdk.Test.Key
{
    public class MsgSendTests
    {
        [Fact]
        public void MsgSend_deserializes_correctly()
        {

            var json = @"{
            type: 'bank/MsgSend',
                        value:
                {
                from_address: 'terra1y4umfuqfg76t8mfcff6zzx7elvy93jtp4xcdvw',
                            to_address: 'terra1v9ku44wycfnsucez6fp085f5fsksp47u9x8jr4',
                            amount:
                    [
                            {
                    denom: 'uluna',
                                amount: '8102024952',
                            },
                            ],
                        },
                    }";


            var data = JsonConvert.DeserializeObject<Data>(json);
            
            data.Dump();

            var send = MsgSend.FromData(data);

            send.Dump();

            var dataOut = send.ToData();

            dataOut.Dump();



            //expect(send).toMatchObject({
            //from_address: 'terra1y4umfuqfg76t8mfcff6zzx7elvy93jtp4xcdvw',
            //            to_address: 'terra1v9ku44wycfnsucez6fp085f5fsksp47u9x8jr4',
            //            amount: new Coins({
            //                uluna: 8102024952,
            //            }),
            //        });

            //expect(send.toData()).toMatchObject({ });
        }
    }
}

//import
//{ MsgSend }
//from './MsgSend';
//import
//{ Coins }
//from '../../Coins';

//describe('MsgSend', () => {
//    it('deserializes correctly', () => {
//        const send = MsgSend.fromData({
//            type: 'bank/MsgSend',
//            value:
//            {
//                from_address: 'terra1y4umfuqfg76t8mfcff6zzx7elvy93jtp4xcdvw',
//                to_address: 'terra1v9ku44wycfnsucez6fp085f5fsksp47u9x8jr4',
//                amount:
//                [
//                {
//                    denom: 'uluna',
//                    amount: '8102024952',
//                },
//                ],
//            },
//        });

//        expect(send).toMatchObject({
//            from_address: 'terra1y4umfuqfg76t8mfcff6zzx7elvy93jtp4xcdvw',
//            to_address: 'terra1v9ku44wycfnsucez6fp085f5fsksp47u9x8jr4',
//            amount: new Coins({
//                uluna: 8102024952,
//            }),
//        });

//        expect(send.toData()).toMatchObject({ });
//    });
//});
