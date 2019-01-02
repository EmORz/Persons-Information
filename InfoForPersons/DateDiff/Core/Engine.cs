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
        public List<int> Count = new List<int>();

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
                writer.WriteLine(Messages.EnterName);
                var name = reader.Reader();
                if (name == "y")
                {
                    break;
                }
                var instance = peopleFactory.CreatePerson(name);
                var temporalDate = instance.CurrentDay;
                var testIsCanGiveBlood = instance.IsValid(instance.CurrentDay);

                if (testIsCanGiveBlood)
                {
                    writer.WriteLine(Messages.ClientCanGiveBlood);
                    InfoListAcept.Add(instance);
                }
                else
                {
                    writer.WriteLine(Messages.ClientCantGiveBlood);
                    Person.Diff(temporalDate);
                    Count.Add(Person.NeededDays(temporalDate));
                    InfoListEject.Add(instance);
                }
            }
            //Total Result
            writer.WriteLine("Acept");
            writer.WriteLine("Total: " + InfoListAcept.Count);
            Printing(InfoListAcept);

            writer.WriteLine("Decline");
            writer.WriteLine("Total: " + InfoListEject.Count);
            PrintPeople(InfoListEject);
        }

        private void Printing(List<IPerson> infoListAcept)
        {
            foreach (var person in infoListAcept)
            {
                writer.WriteLine(person.Name);
            }
        }

        private void PrintPeople(List<IPerson> temp)
        {
            for (int i = 0; i < temp.Count; i++)
            {
                var person = (temp[i].Name);
                writer.WriteLine("After "+Count[i]+$" days {person} will can give blood");
            }
        }
    }
}