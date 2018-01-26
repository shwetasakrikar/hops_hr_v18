using GeneratorBase.MVC.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Reflection;
using System;
namespace GeneratorBase.MVC
{
public static class EntitySearchFilter
{
public static T ApplyFilter<T>(this T query, string EntityName, string FilterName, IUser User, ApplicationContext db)
{
    return query;
 }
    }
}

