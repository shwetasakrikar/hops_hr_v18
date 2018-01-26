using GeneratorBase.MVC.Controllers;
using GeneratorBase.MVC.Models;
using Microsoft.Web.Http;
using NSwag.Annotations;
using System.Net;
using System.Web.Http;
namespace GeneratorBase.MVC.ApiControllers.v1
{
    [AuthorizationRequired]
    [ApiVersion("1.0")]
    public partial class PermissionController : ApiBaseController
    {
        //GET api/GetPermission
        [Route("api/v{version:apiVersion}/Permission/getuserpermission")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IUser))]
        public IHttpActionResult GetUserPermission()
        {
            return Ok(User);
        }
    }
}