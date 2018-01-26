using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AttributeRouting.Web.Http;
using GeneratorBase.MVC.Models;
using GeneratorBase.MVC.Controllers;
using Newtonsoft.Json;
using System.Web.Http.Description;
using System;
using System.Web.Http.OData;
using Microsoft.AspNet.Identity;
using NSwag.Annotations;
using Microsoft.Web.Http;
using System.Threading.Tasks;
namespace GeneratorBase.MVC.ApiControllers.v1
{
   // [AuthorizationRequired]
    [ApiVersion("1.0")]
    public partial class AuthenticationController : ApiController
    {
        [HttpGet]
        [Route("api/v{version:apiVersion}/Authentication/authenticateuser")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string))]
        public async Task<IHttpActionResult> AuthenticateUser(string UserName, string Password)
        {
            ApplicationDbContext UserDb = new ApplicationDbContext();
            ApplicationContext db = new ApplicationContext(new SystemUser());
            var ssoUsers = await UserDb.Users.FirstOrDefaultAsync(p => p.UserName == UserName);
            if (ssoUsers != null)
            {
                var user = ssoUsers;
                var roles = user.Roles;
                PasswordHasher ph = new PasswordHasher();
                string hashedpwd = ph.HashPassword(Password);
                var result = ph.VerifyHashedPassword(user.PasswordHash, Password);
                if (result.ToString() == "Success")
                {
                    var obj = await db.ApiTokens.FirstOrDefaultAsync(p => p.T_UsersID == user.Id);
                    if (obj != null)
                        return Ok(obj.T_AuthToken);
                    else
                    {
                        var token = GenerateToken.GetToken(user.Id);
                        return Ok(obj.T_AuthToken); 
                    }
                }

                return BadRequest("Invalid Password !"); //Request.CreateResponse(HttpStatusCode.NotFound, "Invalid Password !");
            }
            return BadRequest("Invalid Username/Password !");// Request.CreateResponse(HttpStatusCode.NotFound, "Invalid Username/Password");
        }
        [HttpGet]
        [Route("api/v{version:apiVersion}/Authentication/gettokenbyuserid")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ApiToken))]
        public async Task<IHttpActionResult> GetTokenByUserId(string id)
        {
            ApplicationContext db = new ApplicationContext(new SystemUser());
            var obj = await db.ApiTokens.FirstOrDefaultAsync(p => p.T_UsersID == id);
            if (obj != null)
                return Ok(obj);
            else
            {
                var token = GenerateToken.GetToken(id);
                return Ok(token);
            }
        }
        [HttpGet]
        [Route("api/v{version:apiVersion}/Authentication/gettokenbyusernamepassword")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ApiToken))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string))]
        public async Task<IHttpActionResult> GetTokenByUserNamePassword(string UserName, string Password)
        {
            ApplicationContext db = new ApplicationContext(new SystemUser());
            ApplicationDbContext userdb = new ApplicationDbContext();
            var userinfo = await userdb.Users.FirstOrDefaultAsync(p => p.UserName == UserName);
            if (userinfo != null)
            {
                var user = userinfo;
                PasswordHasher ph = new PasswordHasher();
                string hashedpwd = ph.HashPassword(Password);
                var result = ph.VerifyHashedPassword(user.PasswordHash, Password);
                if (result.ToString() == "Success")
                {
                    var obj = await db.ApiTokens.FirstOrDefaultAsync(p => p.T_UsersID == userinfo.Id);
                    if (obj != null)
                        return Ok(obj);
                    else
                    {
                        var token = GenerateToken.GetToken(userinfo.Id);
                        return Ok(token);
                    }
                }
                return BadRequest("Invalid Password !"); 
            }
            return BadRequest("Invalid Username/Password !");
        }
    }
}
