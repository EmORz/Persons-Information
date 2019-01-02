namespace DateDiff.Models
{
    using System;

    /// <summary>
    /// base class for Person with Interface IPerson
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// string Name of patient
        /// </summary>
        string Name { get; set; }

        int Days { get; set; }
        /// <summary>
        /// DateTime last date when he is giving blood
        /// </summary>
        DateTime CurrentDay { get; set; }


        /// <summary>
        /// bool method for validation is patient can give blood
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        bool IsValid(DateTime currentDate);



        /// <summary>
        /// void method for calculation, when patient will be in condition to give blood
        /// </summary>
        void Diff(DateTime temporal);

        int NeededDays(DateTime temporal);
    }
}