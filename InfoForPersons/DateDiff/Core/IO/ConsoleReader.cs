using System;

namespace DateDiff.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string Reader()
        {
            return Console.ReadLine();
        }
    }
}