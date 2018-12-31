namespace DateDiff.Core
{
    using Factory;
    using Factory.Contract;
    using IO;
    using Models;
    using StaticMessages;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        public IPeopleFactory peopleFactory;
        public IReader reader;
        public IWriter writer;
        public IPerson Person;
        public List<IPerson> InfoListAcept;
        public List<IPerson> InfoListEject;

        public Engine()
        {
            reader = new ConsoleReader();
            writer = new ConsoleWriter();
            Person = new Person();
            peopleFactory = new PeopleFactory();
            InfoListAcept = new List<IPerson>();
            InfoListEject = new List<IPerson>();
        }
        public void Run()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                var enterInSystem = reader.Reader() ;
                if (enterInSystem.Equals("y"))
                {
                    enterInSystem = reader.Reader();
                    var instance = peopleFactory.CreatePerson();
                    var temporalDate = instance.CurrentDay;
                    var testIsCanGiveBlood = instance.IsValid(instance.CurrentDay);

                    if (testIsCanGiveBlood)
                    {
                        sb.AppendLine(instance.Name+"+");
                        writer.WriteLine(Messages.ClientCanGiveBlood);
                        InfoListAcept.Add(instance);
                    }
                    else
                    {
                        sb.AppendLine(instance.Name + "-");
                        writer.WriteLine(Messages.ClientCantGiveBlood);
                        Person.Diff(temporalDate);
                        InfoListEject.Add(instance);
                    }
                }
                else
                {
                    break;
                }
            }
            writer.WriteLine("Acept");
            writer.WriteLine("Total: "+InfoListAcept.Count);
            foreach (var person in InfoListAcept)
            {
                writer.WriteLine(person.Name);
            }
            writer.WriteLine("Decline");
            writer.WriteLine("Total: "+InfoListEject.Count);
            foreach (var person in InfoListEject)
            {
                writer.WriteLine(person.Name);
            }
        }
    }
}