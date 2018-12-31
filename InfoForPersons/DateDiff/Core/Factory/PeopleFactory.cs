namespace DateDiff.Core.Factory
{
    using Contract;
    using IO;
    using Models;
    using StaticMessages;
    using System;

    public class PeopleFactory : IPeopleFactory
    {
        private IPerson person;
        private IReader reader = new ConsoleReader();
        private IWriter writer = new ConsoleWriter();

        public PeopleFactory()
        {
            this.person = new Person();
        }
        public IPerson CreatePerson()
        {
            writer.WriteLine(Messages.EnterName);
            var name = reader.Reader();
            writer.WriteLine(Messages.EnterYear);
            var year = int.Parse(reader.Reader());
            writer.WriteLine(Messages.EnterMonth);
            var month = byte.Parse(reader.Reader());
            writer.WriteLine(Messages.EnterDay);
            var days = byte.Parse(reader.Reader());
            DateTime temp = new DateTime(year, month, days);
            person = new Person(name, temp);
            return person;
        }
    }
}