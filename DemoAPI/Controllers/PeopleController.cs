using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    //<summary>
    // This is where all my documentation info will show up
    //</summary>

    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person { FirstName = "Tim", LastName = "Corey", Id = 1 });
            people.Add(new Person { FirstName = "Sue", LastName = "Storm", Id = 2 });
            people.Add(new Person { FirstName = "Bilbo", LastName = "Baggins", Id = 3 });

        }


        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }


        // GET: When we want 2 Get methods
        [Route("api/People/GetFirstNames")]
        [HttpGet]
        public List<string> GetFirstNames()
        {
            List<string> output = new List<string>();

            foreach (var person in people)
            {
                output.Add(person.FirstName);
            }

            return output;
        }

        // GET: The same GET as above, but we want to pass in values from the URL:

   
        /// <summary>
        /// Gets a list of the first names of all users
        /// </summary>
        /// <param name="userId">The unique identifier for this person.</param>
        /// <param name="age">We want to know how old they are.</param>
        /// <returns>A list of first names....duh</returns>
        [Route("api/People/GetFirstNames/{userId:int}/{age:int}")]
        [HttpGet]
        public List<string> GetFirstNames(int userId, int age)
        {
            List<string> output = new List<string>();

            foreach (var person in people)
            {
                output.Add(person.FirstName);
            }

            return output;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }


        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
