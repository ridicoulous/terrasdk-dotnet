using System;
using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace TerraSdk.Test
{
    public abstract class TestBase
    {
        protected ITestOutputHelper Output;

        protected TestBase(ITestOutputHelper output)
        {
            var converter = new Converter(output);
            Console.SetOut(converter);
            Output = output;
        }

        private class Converter : TextWriter
        {
            private readonly ITestOutputHelper _output;

            public Converter(ITestOutputHelper output)
            {
                _output = output;
            }

            public override Encoding Encoding => Encoding.ASCII;

            public override void WriteLine(string message)
            {
                _output.WriteLine(message);
            }

            public override void WriteLine(string format, params object[] args)
            {
                _output.WriteLine(format, args);
            }

            public override void Write(char value)
            {
                throw new NotSupportedException("This text writer only supports WriteLine(string) and WriteLine(string, params object[]).");
            }
        }
    }
}