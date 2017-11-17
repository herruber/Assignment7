using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment7.Models;

namespace Assignment7.Repository
{
    public class PersonRepo
    {

        public enum menuOption
        {
            Name,
            City,
            Occupation,
            ID
        }

        DataAccess.PersonContext pcontext = new DataAccess.PersonContext();

        public IEnumerable<Person> GetAllPersons()
        {
            return pcontext.Persons;
        }

        public Person GetPersonById(int id)
        {
            return pcontext.Persons.FirstOrDefault(e => e.ID == id);
        }

        public void AddPerson(Person p)
        {
            pcontext.Persons.Add(p);
            pcontext.SaveChanges();
        }

        public void RemovePerson(int id)
        {
            Person toremove = pcontext.Persons.FirstOrDefault(p => p.ID == id);
            pcontext.Persons.Remove(toremove);
            pcontext.SaveChanges();
        }

    }
}