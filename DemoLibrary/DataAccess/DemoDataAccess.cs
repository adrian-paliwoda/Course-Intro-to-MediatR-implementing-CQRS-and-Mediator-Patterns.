using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DemoLibrary.Models;

namespace DemoLibrary.DataAccess;

public class DemoDataAccess : IDataAccess
{
    private readonly List<Person> people = new();


    public DemoDataAccess()
    {
        people.Add(new Person
        {
            Id = 1,
            FirstName = "Adrian",
            LasttName = "Paliwoda"
        });
        people.Add(new Person
        {
            Id = 1,
            FirstName = "Zuza",
            LasttName = "Zuzunia"
        });
    }

    public Person GetPerson(int id)
    {
        var result = people.FirstOrDefault(p => p.Id == id);
        if (result != null)
        {
            return result;
        }

        return new Person();
    }
    
    public List<Person> GetPeople()
    {
        return people;
    }

    public Person InsertPerson(string firstName, string lastName)
    {
        var person = new Person { FirstName = firstName, LasttName = lastName };
        person.Id = people.Max(x => x.Id) + 1;
        people.Add(person);

        return person;
    }

    public bool DeletePerson(int id)
    {
        return people.RemoveAll(p => p.Id == id) > 0;
    }
}