namespace AncientCivilizations.Web.Areas.Administration.ViewModels.Content
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using Base;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ArticlesViewModel : AdministrationViewModel, IMapFrom<Article>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Content { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsApproved { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ApproverId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ApproverFullName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string LastEditorId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string LastEditorFullName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticlesViewModel>("")
                .ForMember(m => m.ApproverId, opt => opt.MapFrom(a => a.Approver.Id));
            configuration.CreateMap<Article, ArticlesViewModel>("")
                .ForMember(m => m.ApproverFullName, opt => opt.MapFrom(u => u.Approver.FullName));
            configuration.CreateMap<Article, ArticlesViewModel>("")
                .ForMember(m => m.LastEditorId, opt => opt.MapFrom(u => u.LastEditor.Id));
            configuration.CreateMap<Article, ArticlesViewModel>("")
                .ForMember(m => m.LastEditorFullName, opt => opt.MapFrom(u => u.LastEditor.FullName));
        }
    }
}