using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.Controllers
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        private DataBaseContext<VisitorColloction> _VisitorColloction = new DataBaseContext<VisitorColloction>();
        public string UserIP;
        public VisitorColloction User;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Session["User"] == null)
            {
                this.UserIP = GetRealIP();
                AddNewIP(this.UserIP, requestContext);
            }
            else
            {
                this.UserIP = requestContext.HttpContext.Session["IP"].ToString();
                this.User = requestContext.HttpContext.Session["User"] as VisitorColloction;
            }
            base.Initialize(requestContext);
        }
        /// <summary>  
        /// 获取真ip  
        /// </summary>  
        /// <returns></returns>  
        private string GetRealIP()
        {
            string userIP = "未获取用户IP";

            try
            {
                if (System.Web.HttpContext.Current == null
                 || System.Web.HttpContext.Current.Request == null
                 || System.Web.HttpContext.Current.Request.ServerVariables == null)
                {
                    return "";
                }

                string CustomerIP = "";

                //CDN加速后取到的IP simone 090805
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!String.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                    if (CustomerIP == null)
                    {
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (string.Compare(CustomerIP, "unknown", true) == 0 || String.IsNullOrEmpty(CustomerIP))
                {
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                return CustomerIP;
            }
            catch { }

            return userIP;
        }

        /// <summary>
        /// 添加新的IP信息
        /// </summary>
        /// <param name="ip">IP地址</param>
        private void AddNewIP(string ip, RequestContext requestContext)
        {
            VisitorColloction visitorColloction = new VisitorColloction();
            List<VisitorColloction> list = new List<VisitorColloction>();
            list = _VisitorColloction.GetListAll();
            visitorColloction = _VisitorColloction.Get(p => p.VisitorIP == ip);
            if (visitorColloction == null)
            {
                VisitorColloction colloction = new VisitorColloction()
                {
                    VisitorID = list.Count == 0 ? 1 : list.Max(p => p.VisitorID) + 1,
                    VisitorIP = ip,
                    CreateDate = DateTime.Now,
                    LoginDate = DateTime.Now,
                    IsFirst = true
                };
                _VisitorColloction.Add(colloction);
            }
            else
            {
                visitorColloction.LoginDate = DateTime.Now;
                visitorColloction.IsFirst = false;
                _VisitorColloction.Update(visitorColloction);
            }
            GetUser(ip,requestContext);
            
        }

        private void GetUser(string ip, RequestContext requestContext)
        {
            VisitorColloction visitorColloction=_VisitorColloction.Get(p => p.VisitorIP == this.UserIP);
            requestContext.HttpContext.Session["User"] = visitorColloction;
            requestContext.HttpContext.Session["IP"] = ip;
            requestContext.HttpContext.Session.Timeout = 30;
            this.User = visitorColloction;
        }
    }
}