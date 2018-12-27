using DateDiff.Core.IO;
using DateDiff.Models;
using DateDiff.StaticMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateDiff.Core
{
    public class Engine : IEngine
    {
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
                    writer.WriteLine(Messages.EnterName);
                    var name = reader.Reader();

                    writer.WriteLine(Messages.EnterYear);
                    var year = int.Parse(reader.Reader());

                    writer.WriteLine(Messages.EnterMonth);
                    var month = byte.Parse(reader.Reader());

                    writer.WriteLine(Messages.EnterDay);
                    var days = byte.Parse(reader.Reader());


                    DateTime temp = new DateTime(year, month, days);
                    Person = new Person(name, temp);
                    var testIsCanGiveBlood = Person.IsValid(Person.CurrentDay);

                    if (testIsCanGiveBlood)
                    {
                        sb.AppendLine(Person.Name+"+");
                        writer.WriteLine(Messages.ClientCanGiveBlood);
                        InfoListAcept.Add(Person);
                    }
                    else
                    {
                        sb.AppendLine(Person.Name + "-");
                        writer.WriteLine(Messages.ClientCantGiveBlood);
                        Person.Diff();
                        InfoListEject.Add(Person);
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