using System.Web.Mvc;

namespace Crucero.Areas.Restaurantes
{
    public class RestaurantesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Restaurantes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Restaurantes_default",
                "Restaurantes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}