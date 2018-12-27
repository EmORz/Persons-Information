using System;

namespace DateDiff.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}