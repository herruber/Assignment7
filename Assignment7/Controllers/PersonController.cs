using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Assignment7.DataAccess;
using Assignment7.Models;
using Assignment7.Repository;

namespace Assignment7.Controllers
{
    public class PersonController : ApiController
    {
        //private PersonContext db = new PersonContext();
        Repository.PersonRepo repo = new Repository.PersonRepo();

        // GET: api/GetPersons
        public IEnumerable<Person> GetPersons()
        {
            return repo.GetAllPersons();
        }

        // GET: api/Person/5
        [HttpGet]
        //[ResponseType(typeof(Person))]
        public Person GetPerson(int id)
        {
            return repo.GetPersonById(id);

        }

        // PUT: api/Person/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPerson(int id, Person person)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != person.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(person).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PersonExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Person
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.AddPerson(person);

            return CreatedAtRoute("DefaultApi", new { id = person.ID }, person);
        }

        // DELETE: api/Person/5
        [HttpGet]
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person pers = repo.GetAllPersons().FirstOrDefault(e => e.ID == id);

            
            if (pers == null)
            {
                return NotFound();
            }

            repo.RemovePerson(id);

            return Ok(pers);
        }

        [HttpGet]
        public IHttpActionResult RefillPersons()
        {
            repo.RefillDB();

            return Ok();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PersonExists(int id)
        //{
        //    return db.Persons.Count(e => e.ID == id) > 0;
        //}
    }
}