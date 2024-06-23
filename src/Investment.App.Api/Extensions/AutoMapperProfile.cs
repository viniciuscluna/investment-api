using AutoMapper;
using Investment.App.Api.Entities;
using Investment.App.Api.Models;
using Investment.App.Api.ViewModels;
using Investment.App.Api.ViewModels.Login;

namespace Investment.App.Api.Extensions;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile(){
        CreateMap<LoginResponseViewModel, Login>().ReverseMap();

        CreateMap<FinancialProduct, FinancialProductViewModel>().ReverseMap();
        
    }
}
