using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreenginex.Repository;
using coreenginex.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace coreenginex.Controllers
{
    [Route("api/[controller]")]
    public class SubCategoryController : Controller
    {
        private ISubCategoryRepository _repository;

        // GET: api/values

        public SubCategoryController(ISubCategoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<SubCategory> Get()
        {
            return _repository.Get();
        }
        [HttpGet("{id}")]
        public SubCategory Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SubCategory model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _repository.Insert(model);
            try
            {
                _repository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(model);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody]SubCategory model)
        {
            if (!ModelState.IsValid && id != model.subcategoryID)
                return BadRequest(ModelState);

            _repository.Update(model);
            try
            {
                _repository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(model);
        }

        // DELETE api/values/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            try
            {
                _repository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
