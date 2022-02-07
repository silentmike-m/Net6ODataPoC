namespace Net6ODataPoc.Infrastructure.Customers.Profiles;

using AutoMapper;
using SourceCustomer = Net6ODataPoc.Domain.Entities.CustomerEntity;
using TargetCustomer = Net6ODataPoc.Application.Customers.ViewModels.Customer;

internal sealed class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        this.CreateMap<SourceCustomer, TargetCustomer>()
            .ForMember(target => target.Address, options => options.MapFrom(source => source.Address))
            .ForMember(target => target.City, options => options.MapFrom(source => source.City))
            .ForMember(target => target.CompanyName, options => options.MapFrom(source => source.Company))
            .ForMember(target => target.County, options => options.MapFrom(source => source.County))
            .ForMember(target => target.Email, options => options.MapFrom(source => source.Email))
            .ForMember(target => target.FirstName, options => options.MapFrom(source => source.FirstName))
            .ForMember(target => target.LastName, options => options.MapFrom(source => source.LastName))
            .ForMember(target => target.Phone, options => options.MapFrom(source => source.Phone))
            ;
    }
}
