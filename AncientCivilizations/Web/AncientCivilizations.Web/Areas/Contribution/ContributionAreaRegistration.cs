using System.Web.Mvc;

namespace AncientCivilizations.Web.Areas.Contribution
{
    public class ContributionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Contribution";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Contribution_default",
                url: "Contribution/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "AncientCivilizations.Web.Areas.Contribution.Controllers" }
            );
        }
    }
}