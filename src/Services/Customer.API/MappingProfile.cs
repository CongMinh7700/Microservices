using AutoMapper;

namespace Customer.API;

using Customer.API.Entities;
using Shared.DTOs.Customers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>();
        CreateMap<Customer, CustomerDto>();
    }
}