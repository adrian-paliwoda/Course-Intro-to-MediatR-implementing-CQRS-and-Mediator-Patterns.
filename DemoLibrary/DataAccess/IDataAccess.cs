using System.Collections.Generic;
using DemoLibrary.Models;

namespace DemoLibrary.DataAccess
{
    public interface IDataAccess
    {
        List<Person> GetPeople();
        Person GetPerson(int requestId);
        Person InsertPerson(string firstName, string lastName);
        bool DeletePerson(int id);
    }
}