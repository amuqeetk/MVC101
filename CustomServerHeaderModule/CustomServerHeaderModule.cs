using System;
using System.Web;

namespace CustomServerHeaderModule
{
    class CustomServerHeaderModule:IHttpModule
    {
        public void Init(HttpApplication content)
        {
            content.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }

        public void Dispose()
        {

        }

        void OnPreSendRequestHeaders(object sender, EventArgs args)
        {
            HttpContext.Current.Response.AddHeader("Server", "Scott Lau");
        }
    }
}
