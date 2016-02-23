namespace AncientCivilizations.Web.Models.Public
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
