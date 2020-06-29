using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeTool.Models;
using PracticeTool.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeTool.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TodoExerciseQueueController : ControllerBase {

        private TodoExerciseQueueRepository _todoExerciseRepository;

        public TodoExerciseQueueController()
        {
            _todoExerciseRepository = new TodoExerciseQueueRepository(@"C:\sqlite\PracticeToolDB.db");
        }

        // GET: api/<TodoExerciseController>
        [HttpGet]
        public ActionResult<IEnumerable<TodoExerciseQueue>> Get()
        {
            var todoExerciseQueues = _todoExerciseRepository.GetAll();

            return CreatedAtAction("get",todoExerciseQueues);
        }

        // GET api/<TodoExerciseController>/5
        [HttpGet("{id}")]
        public ActionResult<TodoExerciseQueue> Get(int id)
        {
            var todoExerciseQueue = _todoExerciseRepository.GetById(id.ToString());

            return CreatedAtAction("get", todoExerciseQueue);
        }

        // POST api/<TodoExerciseController>
        [HttpPost]
        public ActionResult<TodoExerciseQueue> Post([FromBody] TodoExerciseQueue todoExerciseQueue)
        {
            _todoExerciseRepository.Update(todoExerciseQueue);

            return CreatedAtAction("added", todoExerciseQueue);
        }

        // PUT api/<TodoExerciseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoExerciseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
