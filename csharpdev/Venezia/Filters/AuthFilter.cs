using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Venezia.Filters
{
	public class AuthFilter : IActionFilter
	{
		public void OnActionExecuting(ActionExecutingContext context)
		{
            if (!context.HttpContext.User.Identity.IsAuthenticated)
			{
				context.HttpContext.Response.Redirect("/Identity/Account/Login");
			}
		}

		public void OnActionExecuted(ActionExecutedContext context) {}
	}
}