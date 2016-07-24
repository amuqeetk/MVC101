using System;
using System.Web;

namespace MVC001.Models
{
    public class RemoveServerHeaderModule : IHttpModule
    {

        public RemoveServerHeaderModule()
        {

        }

        public string ModuleName
        {
            get
            {
                return "RemoveServerHeaderModule";
            }
        }


        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;

            context.PreSendRequestHeaders += RemoveServerFromHeader;

            context.EndRequest += Application_EndRequest;
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            // create HttpApplication and HttpContext object to access
            // request and response properties.

            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension = VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<h1><font color =red>" +
                    "RemoveServerHeaderModule: Beginning of Request" +
                    "</font></h1><hr>");
            }
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension = VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<h1><font color =red>" +
                    "RemoveServerHeaderModule: End of Request" +
                    "</font></h1>");
            }
        }

        void RemoveServerFromHeader(object sender, EventArgs args)
        {
            HttpContext.Current.Response.Headers.Set("Server","Guess");
        }
    }
}