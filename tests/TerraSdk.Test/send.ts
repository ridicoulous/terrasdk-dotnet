import { LCDClient, MsgSend, MnemonicKey } from '../src';

// create a key out of a mnemonic
const mk = new MnemonicKey({
  mnemonic:
    'notice oak worry limit wrap speak medal online prefer cluster roof addict wrist behave treat actual wasp year salad speed social layer crew genius',
});

// To use LocalTerra
const terra = new LCDClient({
  URL: 'http://localhost:1317',
  chainID: 'testnet',
  gasPrices: '169.77ukrw',
});

// a wallet can be created out of any key
// wallets abstract transaction building
const wallet = terra.wallet(mk);

// create a simple message that moves coin balances
const send = new MsgSend(
  'terra1x46rqay4d3cssq8gxxvqz8xt6nwlz4td20k38v',
  'terra17lmam6zguazs5q5u6z5mmx76uj63gldnse2pdp',
  { ukrw: 13120 }
);

wallet
  .createAndSignTx({
    msgs: [send],
    memo: 'test from terra.js!',
    timeout_height: 14500,
  })
  .then(async tx => {
    const hash = await terra.tx.hash(tx);
    const result = await terra.tx.broadcast(tx);
    console.log(`Encode hash: ${hash}`)
    console.log(`Result hash: ${result.txhash}`)
    return result
  })
  .then(result => {
    console.log(`TX raw_log: ${result.raw_log}`);
    console.log(`TX hash: ${result.txhash}`);
  });
