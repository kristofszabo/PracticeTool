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
    public class ComponentTypeController : ControllerBase {

        ComponentTypeRepository _componentTypeRepository;

        public ComponentTypeController()
        {
            _componentTypeRepository = new ComponentTypeRepository(@"C:\sqlite\PracticeToolDB.db");
        }

        // GET: api/<ComponentTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<ComponentType>> Get()
        {
            var componentTypes = _componentTypeRepository.GetAll();
            return CreatedAtAction("get", componentTypes);
        }

        // GET api/<ComponentTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<ComponentType> Get(string id)
        {
            var componentType = _componentTypeRepository.GetById(id);
            return CreatedAtAction("GetById", componentType);
        }

        

        

        
    }
}
