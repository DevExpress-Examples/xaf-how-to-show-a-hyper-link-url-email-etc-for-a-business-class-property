using HyperLinkPropertyEditor.Mobile;
using System;
using System.Web;

namespace E2096.Mobile {
    public class Global : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CorsSupport.HandlePreflightRequest(HttpContext.Current);
        }
    }
}
