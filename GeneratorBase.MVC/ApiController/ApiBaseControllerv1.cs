using GeneratorBase.MVC.Models;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
namespace GeneratorBase.MVC.Controllers
{
    [NoCache]
    public class ApiBaseControllerv1 : ApiController
    {
        private const int PageSize = 10;
        private const string Token = "Token";
        public ApplicationContext db { get; private set; } //removed static for race condition
        private ApplicationDbContext UserContext = new ApplicationDbContext();
        public new IUser User { get; private set; }//removed static for race condition
        //
        private const string Origin = "Origin";
        private const string AccessControlRequestMethod = "Access-Control-Request-Method";
        private const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        private const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        private const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        private const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";
        //
        [SwaggerIgnore]
        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            bool isCorsRequest = controllerContext.Request.Headers.Contains(Origin);
            bool isPreflightRequest = controllerContext.Request.Method == HttpMethod.Options;
            TokenServicesController provider = new TokenServicesController();
            if (controllerContext.Request.Headers.Contains(Token))
            {
                var tokenValue = controllerContext.Request.Headers.GetValues(Token).FirstOrDefault();
                if (tokenValue == null || (provider != null && !provider.ValidateToken(tokenValue)))
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
                    controllerContext.Request.CreateResponse(responseMessage);
                }
                else
                {
                    ApplicationContext db1 = new ApplicationContext(new SystemUser());
                    var _tokenInfo = db1.ApiTokens.FirstOrDefault(p => p.T_AuthToken == tokenValue);
                    var _userId = _tokenInfo.T_UsersID;
                    ApplicationDbContext userdb = new ApplicationDbContext();
                    var _userInfo = userdb.Users.FirstOrDefault(p => p.Id == _userId);
                    ApiUser _apiuser = new ApiUser(_userInfo.UserName);
                    _apiuser.JavaScriptEncodedName = _userInfo.Email;
                    var roles = _apiuser.GetRoles();
                    var isAdmin = _apiuser.IsAdminUser();
                    _apiuser.IsAdmin = isAdmin;
                    _apiuser.userroles = roles.ToList();
                    List<Permission> permissions = new List<Permission>();
                    using (var pc = new PermissionContext())
                    {
                        // so we only make one database call instead of one per entity?
                        var rolePermissions = pc.Permissions.Where(p => roles.Contains(p.RoleName)).ToList();
                        foreach (var entity in GeneratorBase.MVC.ModelReflector.Entities)
                        {
                            var calculated = new Permission();
                            var raw = rolePermissions.Where(p => p.EntityName == entity.Name);
                            calculated.EntityName = entity.Name;
                            calculated.CanEdit = isAdmin || raw.Any(p => p.CanEdit);
                            calculated.CanDelete = isAdmin || raw.Any(p => p.CanDelete);
                            calculated.CanAdd = isAdmin || raw.Any(p => p.CanAdd);
                            calculated.CanView = isAdmin || raw.Any(p => p.CanView);
                            calculated.IsOwner = raw.Any(p => p.IsOwner != null && p.IsOwner.Value);
                            if (!isAdmin)
                                calculated.SelfRegistration = raw.Any(p => p.SelfRegistration != null && p.SelfRegistration.Value);
                            else calculated.SelfRegistration = false;
                            if (calculated.IsOwner != null && calculated.IsOwner.Value)
                                calculated.UserAssociation = raw.FirstOrDefault().UserAssociation;
                            else
                                calculated.UserAssociation = string.Empty;
                            //FLS
                            if (!isAdmin)
                            {
                                var listEdit = raw.Select(p => p.NoEdit).ToList();
                                var listView = raw.Select(p => p.NoView).ToList();
                                var resultEdit = "";
                                var resultView = "";
                                foreach (var str in listEdit)
                                {
                                    if (str != null)
                                        resultEdit += str;
                                }
                                foreach (var str in listView)
                                {
                                    if (str != null)
                                        resultView += str;
                                }
                                calculated.NoEdit = resultEdit;
                                calculated.NoView = resultView;
                            }
                            //
                            permissions.Add(calculated);
                        }
                    }
                    _apiuser.permissions = permissions;
                    List<BusinessRule> businessrules = new List<BusinessRule>();
                    using (var br = new BusinessRuleContext())
                    {
                        var rolebr = br.BusinessRules.Where(p => p.Roles != null && p.Roles.Length > 0 && !p.Disable && p.AssociatedBusinessRuleTypeID != 5).ToList();
                        foreach (var rules in rolebr)
                        {
                            if (_apiuser.IsInRole(rules.Roles.Split(",".ToCharArray())))
                            {
                                businessrules.Add(rules);
                            }
                        }
                    }
                    _apiuser.businessrules = new List<BusinessRule>();//businessrules.ToList();

                    User = _apiuser;
                    db = new ApplicationContext(_apiuser);
                    if (isCorsRequest)
                    {
                        if (isPreflightRequest)
                        {
                            var response = new HttpResponseMessage(HttpStatusCode.OK);
                            response.Headers.Add(AccessControlAllowOrigin, (controllerContext.Request.Headers.GetValues(Origin).First()));

                            string accessControlRequestMethod = controllerContext.Request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
                            if (accessControlRequestMethod != null)
                            {
                                response.Headers.Add(AccessControlAllowMethods, accessControlRequestMethod);
                            }

                            string requestedHeaders = string.Join(", ", controllerContext.Request.Headers.GetValues(AccessControlRequestHeaders));
                            if (!string.IsNullOrEmpty(requestedHeaders))
                            {
                                response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);
                            }

                            var tcs = new TaskCompletionSource<HttpResponseMessage>();
                            tcs.SetResult(response);
                            return tcs.Task;

                        }

                        return base.ExecuteAsync(controllerContext, cancellationToken).ContinueWith(t =>
                        {
                            HttpResponseMessage resp = t.Result;
                            resp.Headers.Add(Token, controllerContext.Request.Headers.GetValues(Token).First());
                            return resp;
                        });
                        //
                    }
                }
                return base.ExecuteAsync(controllerContext, cancellationToken).ContinueWith(t =>
                {
                    HttpResponseMessage resp = t.Result;
                    resp.Headers.Add(Token, controllerContext.Request.Headers.GetValues(Token).First());
                    return resp;
                });
            }
            else
            {
                return base.ExecuteAsync(controllerContext, cancellationToken).ContinueWith(t =>
                {
                    HttpResponseMessage resp = t.Result;
                    resp.StatusCode = HttpStatusCode.NotFound;
                    resp.ReasonPhrase = "Unauthorized access !";
                    return resp;
                });
            }
        }

        protected async Task<IHttpActionResult> Page<T>(IQueryable<T> list, int page)
        {
            var count = await list.CountAsync();
            var results = await list.Skip(PageSize * (page - 1))
                               .Take(PageSize)
                               .ToListAsync();

            return Ok(new PaginatedList<T>()
            {
                Results = results,
                CurrentPage = page,
                TotalPages = 1 + (count / PageSize),
                TotalResults = count,
                Pagination = new PaginationInformation()
                {
                    More = count - (PageSize * page) > 0
                }
            });
        }

        protected IQueryable<T> Sort<T>(IQueryable<T> list, string sortBy, bool ascending) where T : IEntity
        {
            string methodName = ascending ? "OrderBy" : "OrderByDescending";

            ParameterExpression paramExpression = Expression.Parameter(typeof(T));
            MemberExpression memExp = Expression.PropertyOrField(paramExpression, sortBy);
            LambdaExpression lambda = Expression.Lambda(memExp, paramExpression);
            return (IQueryable<T>)list.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { list.ElementType, lambda.Body.Type },
                    list.Expression,
                    lambda));
        }

        protected string ConditionExpression(string entityname, string property, string operators, string value)
        {
            string expression = string.Empty;
            var PrpertyType = GetDataTypeOfProperty(entityname, property);
            var dataType = PrpertyType[0];
            property = PrpertyType[1];
            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                var ValueType = GetDataTypeOfProperty(entityname, value, true);
                if (ValueType != null && ValueType[0] == "dynamic")
                {
                    dataType = ValueType[0];
                    value = ValueType[1];
                }
            }
            if (value.ToLower().Trim() == "null")
            {
                expression = string.Format(" " + property + " " + operators + " {0}", "null");
                return expression;
            }
            switch (dataType)
            {
                case "Int32":
                case "Int64":
                case "Double":
                case "Boolean":
                case "Decimal":
                    {
                        expression = string.Format(" " + property + " " + operators + " {0}", value);
                        break;
                    }
                case "DateTime":
                    {
                        if (value.Trim().ToLower() == "today")
                        {
                            expression = string.Format(" DbFunctions.TruncateTime(" + property + ") " + operators + " (\"{0}\")", (TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (new JournalEntry()).m_Timezone)).Date);
                        }
                        else
                        {
                            DateTime val = Convert.ToDateTime(value);
                            expression = string.Format(" " + property + " " + operators + " (\"{0}\")", val);
                        }
                        break;
                    }
                case "Text":
                case "String":
                    {
                        if (operators.ToLower() == "contains")
                            expression = string.Format(" " + property + "." + operators + "(\"{0}\")", value);
                        else
                            expression = string.Format(" " + property + " " + operators + " \"{0}\"", value);
                        break;
                    }
                default:
                    {
                        expression = string.Format(" " + property + " " + operators + " {0}", value);
                        break;
                    }
            }

            return expression;
        }

        protected List<string> GetDataTypeOfProperty(string entityName, string propertyName, bool valueType = false)
        {
            var listString = new List<string>();
            System.Reflection.PropertyInfo[] properties = (propertyName.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            var Property = properties.FirstOrDefault(p => p.Name == propertyName);
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == entityName);
            if (EntityInfo == null) return listString;
            var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == propertyName);
            var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == propertyName);
            var associatedprop = string.Empty;
            if (propertyName.StartsWith("[") && propertyName.EndsWith("]"))
            {
                propertyName = propertyName.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                if (propertyName.Contains("."))
                {
                    var targetProperties = propertyName.Split(".".ToCharArray());
                    if (targetProperties.Length > 1)
                    {
                        AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                        if (AssociationInfo != null)
                        {
                            var EntityInfo1 = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                            PropInfo = EntityInfo1.Properties.FirstOrDefault(p => p.Name == targetProperties[1]);
                            associatedprop = AssociationInfo.Name.ToLower() + "." + PropInfo.Name;
                        }
                    }
                }
            }
            string DataType = string.Empty;
            if (valueType)
                DataType = "dynamic";
            else
                DataType = PropInfo.DataType;
            listString.Add(DataType);
            if (AssociationInfo != null)
                listString.Add(associatedprop);
            else
                listString.Add(propertyName);
            return listString;
        }

        protected void DeleteDocument(long? docID)
        {
            var document = db.Documents.Find(docID);
            db.Entry(document).State = EntityState.Deleted;
            db.Documents.Remove(document);
            db.SaveChanges();
        }

        protected void DeleteImageGalleryDocument(string docIDs)
        {
            if (!String.IsNullOrEmpty(docIDs))
            {
                string[] strDocIds = docIDs.Split(',');
                foreach (string strDocId in strDocIds)
                {
                    var document = db.Documents.Find(Convert.ToInt64(strDocId));
                    db.Entry(document).State = EntityState.Deleted;
                    db.Documents.Remove(document);
                    db.SaveChanges();
                }
            }
        }



    }
}