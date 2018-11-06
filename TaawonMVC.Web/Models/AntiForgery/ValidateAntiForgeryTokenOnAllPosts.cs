using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using FilterAttribute = System.Web.Http.Filters.FilterAttribute;
using IAuthorizationFilter = System.Web.Http.Filters.IAuthorizationFilter;
using System.Web.Helpers;



namespace TaawonMVC.Web.Models.AntiForgery
{
    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    //public class AjaxValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    //{
    //    public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        try
    //        {
    //            if (filterContext.HttpContext.Request.IsAjaxRequest()) // if it is ajax request.
    //            {
    //                this.ValidateRequestHeader(filterContext.HttpContext.Request); // run the validation.
    //            }
    //            else
    //            {
    //                System.Web.Helpers.AntiForgery.Validate();


    //            }
    //        }
    //        catch (HttpAntiForgeryException e)
    //        {
    //            throw new HttpAntiForgeryException("Anti forgery token not found");
    //        }
    //    }

    //    private void ValidateRequestHeader(HttpRequestBase request)
    //    {
    //        string cookieToken = string.Empty;
    //        string formToken = string.Empty;
    //        string tokenValue = request.Headers["VerificationToken"]; // read the header key and validate the tokens.
    //        if (!string.IsNullOrEmpty(tokenValue))
    //        {
    //            string[] tokens = tokenValue.Split(',');
    //            if (tokens.Length == 2)
    //            {
    //                cookieToken = tokens[0].Trim();
    //                formToken = tokens[1].Trim();
    //            }
    //        }

    //        System.Web.Helpers.AntiForgery.Validate(cookieToken, formToken); // this validates the request token.
    //    }
    //}


    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ValidateAntiForgeryTokenOnAllPosts : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            //  Only validate POSTs
            if (request.HttpMethod == WebRequestMethods.Http.Post)
            {
                //  Ajax POSTs and normal form posts have to be treated differently when it comes
                //  to validating the AntiForgeryToken
                if (request.IsAjaxRequest())
                {
                    var antiForgeryCookie = request.Cookies[AntiForgeryConfig.CookieName];

                    var cookieValue = antiForgeryCookie != null
                        ? antiForgeryCookie.Value
                        : null;

                    System.Web.Helpers.AntiForgery.Validate(cookieValue, request.Headers["__RequestVerificationToken"]);
                }
                else
                {
                    new ValidateAntiForgeryTokenAttribute()
                        .OnAuthorization(filterContext);
                }
            }
        }
    }
}