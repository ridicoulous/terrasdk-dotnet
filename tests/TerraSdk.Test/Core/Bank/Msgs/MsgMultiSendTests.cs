namespace TerraSdk.Test.Core.Bank.Msgs
{
    class MsgMultiSendTests
    {
    }
}


//import
//{ MsgMultiSend }
//from './MsgMultiSend';
//import
//{ Coins }
//from '../../Coins';
//import
//{ Coin }
//from '../../Coin';

//const example: MsgMultiSend.Data = {
//type: 'bank/MsgMultiSend',
//  value:
//    {
//    inputs:
//        [
//      {
//        address: 'terra1fex9f78reuwhfsnc8sun6mz8rl9zwqh03fhwf3',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '1',
//          },
//        ],
//      },
//      {
//        address: 'terra1gg64sjt947atmh45ls45avdwd89ey4c4r72u9h',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '6900000000',
//          },
//        ],
//      },
//      {
//        address: 'terra1yh9u2x8phrh2dan56nntgpmg7xnjrwtldhgmyu',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '1000000',
//          },
//        ],
//      },
//      {
//        address: 'terra1c5a0njk9q6q6nheja8gp4ymt2c0qspd8ggpg49',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '16430000000',
//          },
//        ],
//      },
//      {
//        address: 'terra1psswnm8mvy9qg5z4cxc2nvptc9dx62r4tvfrmh',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '9900000000',
//          },
//        ],
//      },
//      {
//        address: 'terra10lgpfm8wjrl4d9datzw6r6dl83k977afzel4t5',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '15800000000',
//          },
//        ],
//      },
//      {
//        address: 'terra13uj5qs3lcqtffqtu6aa089uf6a2pusgwndzzch',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '6900000000',
//          },
//        ],
//      },
//    ],
//    outputs:
//        [
//      {
//        address: 'terra1fex9f78reuwhfsnc8sun6mz8rl9zwqh03fhwf3',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '1',
//          },
//        ],
//      },
//      {
//        address: 'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axf6p',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '6900000000',
//          },
//        ],
//      },
//      {
//        address: 'terra1fex9f78reuwhfsnc8sun6mz8rl9zwqh03fhwf3',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '1000000',
//          },
//        ],
//      },
//      {
//        address: 'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axf6p',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '16430000000',
//          },
//        ],
//      },
//      {
//        address: 'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axf6p',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '9900000000',
//          },
//        ],
//      },
//      {
//        address: 'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axf6p',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '15800000000',
//          },
//        ],
//      },
//      {
//        address: 'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axf6p',
//        coins:
//            [
//          {
//            denom: 'ukrw',
//            amount: '6900000000',
//          },
//        ],
//      },
//    ],
//  },
//};

//describe('MsgMultiSend', () => {
//it('deserializes correctly', () => {
//    const multisend = MsgMultiSend.fromData(example);
//    expect(multisend.toData()).toMatchObject(example);
//});

//it('can be created manually', () => {
//    const inputs: MsgMultiSend.Input[] = [
//      new MsgMultiSend.Input(
//        'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axf6p',
//        new Coins({
//          ukrw: 123123,
//        })
//      ),
//      new MsgMultiSend.Input('terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axfad', [
//        new Coin('uluna', 123123),
//      ]),
//    ];

//const outputs: MsgMultiSend.Output[] = [
//  new MsgMultiSend.Output(
//    'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axfad',
//    new Coins({
//      ukrw: 123123,
//    })
//      ),
//      new MsgMultiSend.Output('terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axfga', {
//        uluna: 123123,
//      }),
//    ];
//const multisend = new MsgMultiSend(inputs, outputs);
//expect(multisend.toData()).toMatchObject({
//type: 'bank/MsgMultiSend',
//      value:
//    {
//    inputs:
//        [
//          {
//        address: 'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axf6p',
//            coins:
//            [
//              {
//            denom: 'ukrw',
//                amount: '123123',
//              },
//            ],
//          },
//          {
//        address: 'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axfad',
//            coins:
//            [
//              {
//            denom: 'uluna',
//                amount: '123123',
//              },
//            ],
//          },
//        ],
//        outputs:
//        [
//          {
//        address: 'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axfad',
//            coins:
//            [
//              {
//            denom: 'ukrw',
//                amount: '123123',
//              },
//            ],
//          },
//          {
//        address: 'terra105rz2q5a4w7nv7239tl9c4px5cjy7axx3axfga',
//            coins:
//            [
//              {
//            denom: 'uluna',
//                amount: '123123',
//              },
//            ],
//          },
//        ],
//      },
//    });
//  });
//});
