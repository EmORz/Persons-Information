namespace DateDiff.Core.Factory
{
    using Contract;
    using IO;
    using Models;
    using StaticMessages;
    using System;

    public class PeopleFactory : IPeopleFactory
    {
        private IReader reader = new ConsoleReader();
        private IWriter writer = new ConsoleWriter();
        
        public IPerson CreatePerson(string name)
        {
            writer.WriteLine(Messages.EnterYear);
            var year = int.Parse(reader.Reader());
            writer.WriteLine(Messages.EnterMonth);
            var month = byte.Parse(reader.Reader());
            writer.WriteLine(Messages.EnterDay);
            var days = byte.Parse(reader.Reader());

            DateTime temp = new DateTime(year, month, days);
            var type = typeof(Person);
            var instance = (IPerson)Activator.CreateInstance(type, new object[]{name, temp});
            return instance;
        }
    }
}