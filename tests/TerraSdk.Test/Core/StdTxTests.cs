using System.IO;
using TerraSdk.Common.Helpers;
using TerraSdk.Core;
using TerraSdk.Test.Utils;
using Xunit;
using Xunit.Abstractions;

namespace TerraSdk.Test.Core
{
    public class StdTxTests : BaseTest
    {
        public StdTxTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void StdTx_deserializes()
        {
            var stdTxData = File.ReadAllText("../../../Core/StdTx.data.json");
            // stdTxData.DumpToConsole();
            var msgDatas = stdTxData.FromJson<MsgData[]>();
            foreach (var msgData in msgDatas)
            {
                // Output.WriteLine("Test JSON");
                // msgData.DumpToConsole();
                var stdTx = StdTx.FromData(msgData);
                var dataOutput = stdTx.ToData();
                // Output.WriteLine("Output JSON");
                //dataOutput.DumpToConsole();

                CompareExtensions.CompareObj(msgData, dataOutput);
            }
        }
    }
}


//import
//{ StdTx }
//from './StdTx';
//const StdTxData = require('./StdTx.data.json');

//describe('StdTx', () => {
//    it('deserializes', () => {
//        StdTxData.forEach((tx: any) => {
//            expect(tx).toMatchObject(StdTx.fromData(tx).toData());
//        });
//    });
//});