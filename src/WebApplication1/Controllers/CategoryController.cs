using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    /// <summary>
    /// category controller class
    /// </summary>
    /// 

    [Produces("application/json")]
    public class CategoryController : Controller
    {
        
        private readonly ICategoryRepository _repository;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repository"></param>
        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        /// <summary>
        /// gets all the categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
      
         public IEnumerable<Category> GetAll()
        {
            return _repository.Get();
        }

        // GET api/values/5
       [HttpGet]
        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _repository.Insert(model);
            try
            {
                _repository.Save();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody]Category model)
        {
            if (!ModelState.IsValid && id!=model.categoryID)
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
