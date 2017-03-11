using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using coreenginex.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace coreenginex.Services
{
   
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private static bool _databaseChecked;
        private readonly ILogger _logger;
        public AccountController(
       UserManager<ApplicationUser> userManager,
       SignInManager<ApplicationUser> signInManager,
       IEmailSender emailSender,
       ISmsSender smsSender,
       ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }
        // GET: api/values
        [HttpPost]
     
        [AllowAnonymous]
        
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
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
            else
            {
                
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    firstName = model.firstName,
                    lastName = model.lastName,
                    PhoneNumber = model.PhoneNumber,
                    EmailConfirmed = true,PhoneNumberConfirmed=true
                   
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok("User created");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            
               
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> addPermanentAddress([FromBody]AddressViewModel address)
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
            else
            {
                try
                {
                    var Username = _userManager.GetUserId(HttpContext.User);
                    var user = await _userManager.FindByNameAsync(Username);
                    if (user == null)
                        return BadRequest(new Error { errorCode = "400", errorDescription = "no user found with username " + Username });
                    Address a = new Address
                    {
                        city = address.city,
                        Country = address.Country,
                        locality = address.locality,
                        PhoneNumber = address.PhoneNumber,
                        email = address.Email,
                        State = address.State,
                        StreetName = address.StreetName
                    };
                    user.permanentAddress = a;
                    await _userManager.UpdateAsync(user);
                    
                        }
                catch(Exception e)
                {
                    return BadRequest(new Error() { errorCode = "400", errorDescription = e.Message });
                }
            }
            return Ok("Permanent address updated");

            }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> addPresentAddress([FromBody]AddressViewModel address)
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
            else
            {
                try
                {
                    var Username = _userManager.GetUserId(HttpContext.User);
                    
                    var user = await _userManager.FindByNameAsync(Username);
                    if (user == null)
                        return BadRequest(new Error { errorCode = "400", errorDescription = "no user found with username " + Username });
                    Address a = new Address
                    {
                        city = address.city,
                        Country = address.Country,
                        locality = address.locality,
                        PhoneNumber = address.PhoneNumber,
                        email = address.Email,
                        State = address.State,
                        StreetName = address.StreetName
                    };
                    user.currentAddress = a;
                    await _userManager.UpdateAsync(user);

                }
                catch (Exception e)
                {
                    return BadRequest(new Error() { errorCode = "400", errorDescription = e.Message });
                }
            }
            return Ok("present address updated");

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddProfilePicture(IFormFile file)
        {
            if(file!=null)
            {
                var fileName = file.FileName;

            }
            return null;
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult show()
        {
            return  Ok("hello");
    }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult showanno()
        {
            return Ok("hello");
        }
    }
   

    public class RegisterViewModel
    {
        [Required(ErrorMessage ="first name is required")]
        public string firstName { get; set; }
        [Required(ErrorMessage ="last name is required")]
        public string lastName { get; set; }
       

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string Email { get; set; }
        [Phone(ErrorMessage ="Invalid phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
       
    }
    public class AddressViewModel
    {
        [Required(ErrorMessage = "Street Name is required")]
        public String StreetName { get; set; }
        [Required(ErrorMessage = "Locality required")]
        public String locality { get; set; }
        [Required(ErrorMessage = "City required")]
        public String city { get; set; }
        [Required(ErrorMessage = "State required")]
        public String State { get; set; }
        [Required(ErrorMessage = "Country required")]

        public String Country { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

    }
}
