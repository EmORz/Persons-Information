namespace DateDiff.Core.IO
{
    using System;

    public class ConsoleReader : IReader
    {
        public string Reader()
        {
            return Console.ReadLine();
        }
    }
}