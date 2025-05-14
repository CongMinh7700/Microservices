using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Services;

using Interfaces;
using Repositories.Interfaces;
using Shared.DTOs.Customers;
using System;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public AutoMapper.IConfigurationProvider ConfigurationProvider => throw new NotImplementedException();

    public async Task<IResult> CreateCustomerAsync([FromBody] CreateCustomerDto customerDto)
    {
        var existCustomer = await _repository.GetCustomerByUsernameAsync(customerDto.Username);
        if (existCustomer != null)
        {
            return Results.NotFound("Exitst UserName");
        }

        var customer = _mapper.Map<Entities.Customer>(customerDto);

        await _repository.CreateCustomerAsync(customer);
        await _repository.SaveChangesAsync();

        var result = _mapper.Map<CustomerDto>(customer);
        return Results.Ok(result);
    }

    public async Task<IResult> DeleteCustomerAsync(int userId)
    {
        var customer = await _repository.GetCustomerByUserIdAsync(userId);
        if (customer == null)
        {
            return Results.NotFound();
        }

        await _repository.DeleteCustomerAsync(userId);
        await _repository.SaveChangesAsync();

        return Results.Ok();
    }

    public async Task<IResult> GetCustomerByUsernameAsync(string username) =>
        Results.Ok(await _repository.GetCustomerByUsernameAsync(username));

    public async Task<IResult> GetCustomerByUserIdAsync(int userId) =>
    Results.Ok(await _repository.GetCustomerByUserIdAsync(userId));

    public async Task<IResult> GetCustomersAsync() =>
        Results.Ok(await _repository.GetCustomersAsync());

    public async Task<IResult> UpdateCustomerAsync(int userId, UpdateCustomerDto customerDto)
    {
        var customer = await _repository.GetCustomerByUserIdAsync(userId);
        if (customer == null)
        {
            return Results.NotFound();
        }

        var updateCustomer = _mapper.Map(customerDto, customer);
        await _repository.UpdateCustomerAsync(updateCustomer);
        await _repository.SaveChangesAsync();

        var result = _mapper.Map<CustomerDto>(customer);
        return Results.Ok(result);
    }
}
