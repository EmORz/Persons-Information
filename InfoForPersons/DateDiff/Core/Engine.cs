using DateDiff.Models;
using DateDiff.StaticMessages;
using System;
using System.Collections.Generic;

namespace DateDiff.Core
{
    public class Engine : IEngine
    {
        public IPerson Person;
        public List<IPerson> InfoListAcept;
        public List<IPerson> InfoListEject;

        public Engine()
        {
            Person = new Person();
            InfoListAcept = new List<IPerson>();
            InfoListEject = new List<IPerson>();
        }
        public void Run()
        {
            while (true)
            {
                var enterInSystem = Console.ReadLine();
                if (enterInSystem == "y")
                {
                    enterInSystem = Console.ReadLine();
                    Console.WriteLine(Messages.EnterName);
                    var name = Console.ReadLine();

                    Console.WriteLine(Messages.EnterYear);
                    var year = int.Parse(Console.ReadLine());

                    Console.WriteLine(Messages.EnterMonth);
                    var month = byte.Parse(Console.ReadLine());

                    Console.WriteLine(Messages.EnterDay);
                    var days = byte.Parse(Console.ReadLine());


                    DateTime temp = new DateTime(year, month, days);
                    Person = new Person(name, temp);
                    var testIsCanGiveBlood = Person.IsValid(Person.CurrentDay);

                    if (testIsCanGiveBlood)
                    {
                        Console.WriteLine(Messages.ClientCanGiveBlood);
                        InfoListAcept.Add(Person);
                    }
                    else
                    {
                        Console.WriteLine(Messages.ClientCantGiveBlood);
                        Person.Diff();
                        InfoListEject.Add(Person);

                    }
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Acept");
            Console.WriteLine("Total: "+InfoListAcept.Count);
            foreach (var person in InfoListAcept)
            {
                Console.WriteLine(person.Name);
            }
            Console.WriteLine("Decline");
            Console.WriteLine("Total: "+InfoListEject.Count);
            foreach (var person in InfoListEject)
            {
                Console.WriteLine(person.Name);
            }

        }
    }
}