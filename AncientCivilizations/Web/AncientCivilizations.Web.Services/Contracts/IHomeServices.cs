namespace AncientCivilizations.Web.Services.Contracts
{
    using AncientCivilizations.Web.Models.Public;

    public interface IHomeServices
    {
        AllContentViewModel GetHomePageData();
    }
}
