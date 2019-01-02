namespace DateDiff.Core.Factory.Contract
{
    using Models;

    public interface IPeopleFactory
    {
        IPerson CreatePerson(string name);
    }
}