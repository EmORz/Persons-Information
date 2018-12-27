using System;
using System.Text;

namespace DateDiff.Models
{
    /// <summary>
    /// Base class for patient
    /// </summary>
    public class Person : IPerson
    {
        /// <summary>
        /// constant days
        /// </summary>
        private const int AditionalDays = 60;
        
        public string Name { get; set; }
      
        public DateTime CurrentDay { get; set; }
        /// <summary>
        /// empty Ctor
        /// </summary>
        public Person(){}
        /// <summary>
        /// Ctor with input data for class Person
        /// </summary>
        /// <param name="name"></param>
        /// <param name="currentDay"></param>
        public Person(string name, DateTime currentDay)
        {
            this.Name = name;
            this.CurrentDay = currentDay.AddDays(AditionalDays);
        }
        public bool IsValid(DateTime currentDate)
        {
            var now = DateTime.Now.Ticks;
            var current = currentDate.Ticks;
            if (now > current)
            {
                return true;
            }
            return false;
        }
        public void Diff()
        {
            StringBuilder sb = new StringBuilder();
            var current = this.CurrentDay;
            var now = DateTime.Now;
            var temp = (current - now);
            var days = temp.Days;
            sb.AppendLine($"You will can give blood after {days} days");
            var date = now.AddDays(days);
            sb.AppendLine($"After {date} wellcome in our blood bank center!");

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}