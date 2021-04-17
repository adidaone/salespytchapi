using SalesPytch.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesPytch.Model;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesPytch.WebAPI.Controllers
{
    [RoutePrefix("api/v1/SalesPytch")]
    public class UserController : ApiController
    {

        private IUserService _userService = null;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// This method will check for th Valid User
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(User))]
        [Route("ValidateUser/{emailAddress}/{password}/")]
        public async Task<IHttpActionResult> ValidateUser(string emailAddress, string password)
        {
            User user = null;
            string conString = string.Empty;
            try
            {
                await ValidateinputParameters(emailAddress, password);
                user = await _userService.ValidateUser(emailAddress, password);

                if (user == null)
                {
                    return Content(HttpStatusCode.NotFound, new HttpError("User Does Not Exists"));
                }
                return Ok(user);
            }
            catch (ValidationException ex)
            {
                return Content(HttpStatusCode.BadRequest, new HttpError(ex.Message));
                //Logging here -App Insights at later stages
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, new HttpError("Internal Server Error"));
                //Loggin here -App Insights at later stages
            }
        }

        private Task ValidateinputParameters(string emailAddress, string password)
        {
            return Task.Factory.StartNew(() =>
            {
                //Validation - Email and Password cannot be null
                if ((String.IsNullOrEmpty(emailAddress) || String.IsNullOrWhiteSpace(emailAddress)) && (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password)))
                    throw new ValidationException("Email Address and Password are mandatory");
                //Validation - Email cannot be null
                if (String.IsNullOrEmpty(emailAddress) || String.IsNullOrWhiteSpace(emailAddress))
                    throw new ValidationException("Email Address is mandatory");
                //Validation - Password cannot be null
                if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
                    throw new ValidationException("Password is mandatory");               
            });
        }
    }
}
