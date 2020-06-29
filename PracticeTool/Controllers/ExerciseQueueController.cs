using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeTool.Models;
using PracticeTool.Repository;

namespace PracticeTool.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseQueueController : ControllerBase {

        ExerciseQueueRepository _exerciseQueueRepository;

        public ExerciseQueueController()
        {
            _exerciseQueueRepository = new ExerciseQueueRepository(@"C:\sqlite\PracticeToolDB.db");
        }


        [HttpGet]
        public ActionResult<IEnumerable<ExerciseQueue>> Get()
        {

            var queues = _exerciseQueueRepository.GetAll();

            return CreatedAtAction("get", queues);
        }

        [HttpDelete]
        public ActionResult<ExerciseQueue> Delete(ExerciseQueue exerciseQueue)
        {
            _exerciseQueueRepository.Delete(exerciseQueue);

            return CreatedAtAction("Delete", true);
        }

        [HttpPost]
        public ActionResult<ExerciseQueue> Insert(ExerciseQueue exerciseQueue)
        {
            _exerciseQueueRepository.Insert(exerciseQueue);

            return CreatedAtAction("Insert", exerciseQueue);


        }
    }
}
