using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using PracticeTool.Models;
using PracticeTool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeTool.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase {
        private readonly ExerciseRepository _exerciseRepository = new ExerciseRepository(@"C:\sqlite\PracticeToolDB.db");

        [HttpGet]
        public IEnumerable<Exercise> Get()
        {
            var exercises = _exerciseRepository.GetAll();

            return exercises;
        }

        [HttpPost]
        public ActionResult<Exercise> DeleteExercise([FromBody]Exercise exercise)
        {
            _exerciseRepository.Delete(exercise);
             
            return CreatedAtAction(nameof(DeleteExercise), exercise);

        }

        [HttpPut]
        public ActionResult<Exercise> InsertExercise([FromBody] Exercise exercise)
        {
            _exerciseRepository.Insert(exercise,[]);

            return CreatedAtAction(nameof(InsertExercise), exercise);
        }

        [HttpDelete]
        public ActionResult<Exercise> PutExercise([FromBody] Exercise exercise)
        {
            _exerciseRepository.Insert(exercise);
            return CreatedAtAction(nameof(PutExercise), exercise);
        }
        
    }
}
