using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment7.Models;
using System.Data.Entity.Migrations;

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
            pcontext.Persons.AddOrUpdate(p);
            //pcontext.Persons.Add(p);
            pcontext.SaveChanges();
        }

        public void RemovePerson(int id)
        {
            Person toremove = pcontext.Persons.FirstOrDefault(p => p.ID == id);
            pcontext.Persons.Remove(toremove);
            pcontext.SaveChanges();
        }

        public void RefillDB()
        {
            pcontext.Persons.AddOrUpdate(p => p.ID,
             new Person { ID = 1, City = "Skellefteå", Name = "Robert Nyqvist", Occupation = "Studerande" },
             new Person { ID = 2, City = "Stockholm", Name = "Arne Weise", Occupation = "Barista" },
             new Person { ID = 3, City = "Umeå", Name = "Anders Saucig", Occupation = "Arbetslös" },
             new Person { ID = 4, City = "Ursviken", Name = "Urban Ur", Occupation = "Urmakare" }
             );

            pcontext.SaveChanges();
        }

    }
}