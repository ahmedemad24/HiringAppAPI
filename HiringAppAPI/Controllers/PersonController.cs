using HiringAppAPI.Models;
using HiringAppAPI.Models.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HiringAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<PersonController>
        [HttpGet("GetAll")]
        public ActionResult<Person> GetAll()
        {
            var people = _unitOfWork.Person.GetAll();

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var people = _unitOfWork.Person.GetById(id);

            if (people == null)
            {
                return NotFound();
            }

            return people;
        }

        // POST api/<PersonController>
        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            
            _unitOfWork.Person.Add(person);
            _unitOfWork.Complete();

            return Ok(true);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Person.Update(person);
            _unitOfWork.Complete();

            return Ok(true);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var people = _unitOfWork.Person.GetById(id);
            if (people == null)
            {
                return NotFound();
            }

            _unitOfWork.Person.Delete(people);
            _unitOfWork.Complete();

            return Ok(people);
        }
    }
}
