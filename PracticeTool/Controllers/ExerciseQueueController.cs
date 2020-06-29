using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeTool.Models;

namespace PracticeTool.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseQueueController : ControllerBase {
        [HttpGet]
        public ActionResult<IEnumerable<ExerciseQueue>> Get()
        {

        }
    }
}
