using System;
using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace TerraSdk.Test
{
    public abstract class BaseTest : IDisposable
    {
        private readonly Converter converter;
        private readonly TextWriter originalConsoleOut;
        protected ITestOutputHelper Output;

        protected BaseTest(ITestOutputHelper output)
        {
            originalConsoleOut = Console.Out;
            converter = new Converter(output);
            Console.SetOut(converter);
            Output = output;
        }

        public virtual void Dispose()
        {
            Console.SetOut(originalConsoleOut);
            converter.Dispose();
        }

        private class Converter : TextWriter
        {
            private readonly ITestOutputHelper output;

            public Converter(ITestOutputHelper output)
            {
                this.output = output;
            }

            public override Encoding Encoding => Encoding.ASCII;

            public override void WriteLine(string? message)
            {
                output.WriteLine(message);
            }

            public override void WriteLine(string? format, params object?[] args)
            {
                output.WriteLine(format, args);
            }

            public override void Write(char value)
            {
                throw new NotSupportedException(
                    "This text writer only supports WriteLine(string) and WriteLine(string, params object[]).");
            }
        }
    }
}