using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Mvc;

namespace Blog
{
    /// <summary>
    /// 身份验证
    /// </summary>
    public class UserAuthorize: AuthorizeAttribute
    {
        string[] LimitIP = { "::1", "120.197.36.210", "223.211.78.195","117.136.79.11","123.197.139.185" };
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            List<string> list = LimitIP.ToList();
            string userIP = filterContext.HttpContext.Session["IP"].ToString();
            if (!list.Contains(userIP))
            {
                filterContext.HttpContext.Response.Redirect("~/UserPower/Index");
            }
        }
    }
}
