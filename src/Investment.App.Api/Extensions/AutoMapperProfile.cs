using AutoMapper;
using Investment.App.Api.Entities;
using Investment.App.Api.ViewModels;

namespace Investment.App.Api.Extensions;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile(){
        CreateMap<FinancialProduct, FinancialProductViewModel>().ReverseMap();
    }
}
