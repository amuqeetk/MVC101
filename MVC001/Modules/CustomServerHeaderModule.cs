using System;
using System.Web;

namespace MVC001.Modules
{
    class RemoveServerHeaderModule:IHttpModule
    {
        public void Init(HttpApplication content)
        {
            content.PreSendRequestHeaders += RemoveServerFromHeader;
        }

        public void Dispose()
        {

        }

        void RemoveServerFromHeader(object sender, EventArgs args)
        {
            HttpContext.Current.Response.Headers.Remove("Server");
        }
    }
}
