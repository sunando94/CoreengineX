using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using coreenginex.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace coreenginex.Controllers
{
    [Route("api/[controller]")]
    public class BListingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnviroment;
        public BListingController(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context, IHostingEnvironment hostingEnviroment)
        {
            _userManager = userManager;
            _context = context;
            _hostingEnviroment = hostingEnviroment;

        }
        /// <summary>
        /// Creates a business
        /// </summary>
        /// <param name="model">Business model input</param>
        /// <returns>
        /// if successful the returns a created string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>
        // POST api/values
        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody]BusinessViewModel model)
        {
            Business b;
            if (!ModelState.IsValid)
            {
                List<Error> errors = new List<Error>();
                foreach (ModelError error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Error e = new Error
                    {
                        errorCode = "400",
                        errorDescription = error.ErrorMessage

                    };
                    errors.Add(e);
                }
                return BadRequest(errors);
            }

            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                ApplicationUser user = await _userManager.FindByNameAsync(userId);
                b = new Business()
                {
                    businessName = model.businessName,
                    alias = model.alias,
                    category = _context.categories.Where(r => r.categoryID == model.categoryID).First(),
                    subCategory = _context.subCategories.Where(r => r.subcategoryID == model.subCategoryID).First(),
                    User = user,
                    Type = model.Type

                };
                _context.businesses.Add(b);
                _context.Entry(b.subCategory).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                _context.Entry(b.category).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });
            }
            return Ok("Business Created");
        }
        /// <summary>
        /// Add store to a business
        /// </summary>
        /// <param name="model">Store information</param>
        /// <param name="Bid">Business ID</param>
        /// <returns>
        /// if successful the returns a created string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>
        [Authorize]
        [HttpPost("AddStore/{Bid}")]
        public async Task<IActionResult> AddStore([FromBody]StoreViewModel model, [FromRoute]int Bid)
        {
            Store s;
            if (!ModelState.IsValid)
            {
                List<Error> errors = new List<Error>();
                foreach (ModelError error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Error e = new Error
                    {
                        errorCode = "400",
                        errorDescription = error.ErrorMessage

                    };
                    errors.Add(e);
                }
                return BadRequest(errors);
            }
            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                ApplicationUser user = await _userManager.FindByNameAsync(userId);
                var b = _context.businesses.Where(r => r.businessID == Bid).First();
                if (user.UserName != b.User.UserName)
                    return BadRequest(new Error() { errorCode = "400", errorDescription = "logged in user is not the owner of the current business" });

                s = new Store()
                {
                    closingTime = model.closingTime,
                    openingTime = model.openingTime,
                    location = model.location,

                };

                _context.shop.Add(s);
                await _context.SaveChangesAsync();
                //  var b = _context.businesses.Find(Bid);
                if (b.Store == null)
                    b.Store = new List<Store>();
                b.Store.Add(s);
                _context.Entry(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });
            }
            return Ok("store created");

        }
        /// <summary>
        /// adds or modifies a store thumbnail image
        /// </summary>
        /// <param name="file">Image file in formdata</param>
        /// <param name="Sid">Store ID</param>
        /// <returns>
        /// if successful the returns a created string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>
        [Authorize]
        [HttpPost("AddStoreThumb/{Sid}")]
        public async Task<IActionResult> addStoreThumb(IFormFile file, [FromRoute]int Sid)
        {
            try
            {
                var filename = Guid.NewGuid().ToString() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                var path = _hostingEnviroment.WebRootPath.ToString() + @"\images\profilepic\" + filename;
                var store = _context.shop.Where(r => r.storeID == Sid).First();
                store.storeThumb = new Image()
                {
                    imageUrl = (_hostingEnviroment.IsDevelopment()) ? "http://localhost:58319/images/" + filename
                    : "http://coreenginex.azurewebsites.net/images/" + filename
                };
                using (FileStream fs = System.IO.File.Create(path))
                {
                    file.CopyTo(fs);
                    fs.FlushAsync();
                }
                _context.Entry(store).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });
            }
            return Ok("Store thumbnail added");
        }
        /// <summary>
        /// Mark a store to be open
        /// </summary>
        /// <param name="Sid">Store ID</param>
        /// <returns>
        /// if successful the returns a created string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>
        [Authorize]
        [HttpPost("SetStoreOpen/{Sid}")]
        public async Task<IActionResult> StoreActive([FromRoute]int Sid)
        {
            Store store;
            try
            {
                store = _context.shop.Where(r => r.storeID == Sid).First();
                store.status = "Open";
                _context.Entry(store).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });

            }
            return Ok(new { storename = store.storeID, status = store.status });
        }
        /// <summary>
        /// marks a store to be closed
        /// </summary>
        /// <param name="Sid">Store ID</param>
        /// <returns>
        /// if successful the returns a created string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>
        [Authorize]
        [HttpPost("SetStoreClosed/{Sid}")]
        public async Task<IActionResult> StoreDeactivate([FromRoute]int Sid)
        {
            Store store;
            try
            {
                store = _context.shop.Where(r => r.storeID == Sid).First();
                store.status = "Closed";
                _context.Entry(store).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });

            }
            return Ok(new { storename = store.storeID, status = store.status });
        }
        /// <summary>
        /// Add a review to a store,review must be added by user
        ///
        /// </summary>
        /// <param name="Sid">Store ID</param>
        /// <param name="model">review and rating of the store</param>
        /// <returns>
        /// if successful the returns a added string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>
        [Authorize]
        [HttpPost("addReview/{Sid}")]
        public async Task<IActionResult> addReview([FromRoute]int Sid,[FromBody] reviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                List<Error> errors = new List<Error>();
                foreach (ModelError error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Error e = new Error
                    {
                        errorCode = "400",
                        errorDescription = error.ErrorMessage

                    };
                    errors.Add(e);
                }
                return BadRequest(errors);
            }
            Store store;
            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                ApplicationUser user = await _userManager.FindByNameAsync(userId);
                store = _context.shop.Where(r => r.storeID == Sid).First();
                if (store.reviews == null)
                    store.reviews = new List<Reviews>();
                store.reviews.Add(new Reviews() { rating = model.rating, review = model.review, user = user });
                decimal totalrating = 0.0M;
                foreach (Reviews r in store.reviews)
                    totalrating += r.rating;
                store.totalRating = totalrating/store.reviews.Count;
                _context.Entry(store).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
              await  _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });
            }
            return Ok("Review added");
        }

        /// <summary>
        /// add a logo to the business
        /// </summary>
        /// <param name="file">logo file image</param>
        /// <param name="Bid">Business ID</param>
        /// <returns>
        /// if successful the returns a add string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>
        [Authorize]
        [HttpPost("AddLogo/{Bid}")]
        public async Task<IActionResult> addLogo(IFormFile file, [FromRoute]int Bid)
        {
            try
            {
                var filename = Guid.NewGuid().ToString() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                var path = _hostingEnviroment.WebRootPath.ToString() + @"\images\logo\" + filename;
                var b = _context.businesses.Where(r => r.businessID == Bid).First();
                b.logo = new Image()
                {
                    imageUrl = (_hostingEnviroment.IsDevelopment()) ? "http://localhost:58319/logo/" + filename
                    : "http://coreenginex.azurewebsites.net/logo/" + filename
                };
                using (FileStream fs = System.IO.File.Create(path))
                {
                    file.CopyTo(fs);
                    fs.FlushAsync();
                }
                _context.Entry(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });
            }
            return Ok("logo added");
        }
        /// <summary>
        /// Add Image to store gallery
        /// </summary>
        /// <param name="file">Image file</param>
        /// <param name="Sid">Store Id</param>
        /// <returns>
        /// if successful the returns a created string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>
        [Authorize]
        [HttpPost("AddGalleryImage/{Sid}")]
        public async Task<IActionResult> addGalleryImage(IFormFile file, [FromRoute]int Sid)
        {
            try
            {       var filename = Guid.NewGuid().ToString() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                    var path = _hostingEnviroment.WebRootPath.ToString() + @"\images\profilepic\" + filename;
                    var store = _context.shop.Where(r => r.storeID == Sid).First();
               if (store.storeGallery == null)
                    store.storeGallery = new List<Image>();

                    Image i = new Image()
                    {
                        imageUrl = (_hostingEnviroment.IsDevelopment()) ? "http://localhost:58319/gallery/" + filename
                        : "http://coreenginex.azurewebsites.net/gallery/" + filename
                    };
                store.storeGallery.Add(i);
                    using (FileStream fs = System.IO.File.Create(path))
                    {
                        file.CopyTo(fs);
                        fs.FlushAsync();
                    }
                    _context.Entry(store).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                
            }
            
            catch (Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });
            }
            return Ok("Store thumbnail added");
        }
        /// <summary>
        /// Adds a user to the following list of the store
        /// </summary>
        /// <param name="Sid">StoreID</param>
        /// <returns>
        /// if successful the returns a created string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>

        [Authorize]
        [HttpGet("follow/{Sid}")]

        public async Task<IActionResult> follow([FromRoute]int Sid)
        {
            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                ApplicationUser user = await _userManager.FindByNameAsync(userId);
                Store store = _context.shop.Where(r => r.storeID == Sid).First();
                StoreApplicationUser sa = new StoreApplicationUser()
                {
                    Id = user.Id,
                    User = user,
                    store = store,
                    storeID = store.storeID
                };
                if (store.followers == null)
                    store.followers = new List<StoreApplicationUser>();
                if (user.watch == null)
                    user.watch = new List<StoreApplicationUser>();

                store.followers.Add(sa);
                user.watch.Add(sa);
                _context.Entry(store).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await  _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();

            }
            catch(Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });
            }
            return Ok("User added to follow list");

        }

        /// <summary>
        /// Add Departments where business type is "Manufacturer"
        /// </summary>
        /// <param name="Bid">Business ID</param>
        /// <param name="model">Department Name and Department incharge username</param>
        /// <returns>
        /// if successful the returns a created string with status code 200 
        /// if failure returns a 500 status code
        /// </returns>
        [Authorize]
        [HttpPost("AddDepartment/{Bid}")]
        public async Task<IActionResult> addDepartment([FromRoute]int Bid,[FromBody]departmentViewModel model)
        {
            try
            {
                var b = _context.businesses.Where(r => r.businessID == Bid).First();
                if(b.Type=="Manufacturer")
                {
                    var User = await _userManager.FindByNameAsync(model.DepartmentIncharge);
                    if(User!=null)
                    {
                        Department d = new Department()
                        {
                            DepartmentName = model.DepartmentName,
                            Poc = User
                        };
                        if (b.departments == null)
                            b.departments = new List<Department>();
                        b.departments.Add(d);
                        _context.Entry(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else
                    {
                        return BadRequest(new Error() { errorCode = "400", errorDescription = "User doesn't exists" });
                    }

                }
            }
            catch(Exception e)
            {
                return BadRequest(new Error() { errorCode = "500", errorDescription = e.InnerException.Message });
            }
            return Ok("Department Added");
        }

    }

    public class BusinessViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string businessName { get; set; }
        [Required]
        public string alias { get; set; }
        [Required]
        public String Type { get; set; } = "Retail";
        [Required]
       
        public int categoryID { get; set; }
        [Required]
        
        public int subCategoryID { get; set; }
    }

    public class StoreViewModel
    {
        [Required]
        public Location location { get; set; }
        [Required]
        public string openingTime { get; set; }
        [Required]
        public string closingTime { get; set; }
    }

  public class reviewViewModel
    {
        /// <summary>
        /// review comment
        /// </summary>
        public string review { get; set; }
        /// <summary>
        /// rating in decimal and less than 5
        /// </summary>
        public decimal rating { get; set; }
    }

    public class departmentViewModel
    {
        /// <summary>
        /// Name of the department
        /// </summary>
        public String DepartmentName { get; set; }
        /// <summary>
        /// username of Department Incharge
        /// </summary>
        public String DepartmentIncharge { get; set; }
    }
}
