﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AncientCivilizations.Web.Startup))]

namespace AncientCivilizations.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
