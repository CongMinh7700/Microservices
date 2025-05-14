namespace Customer.API.Controllers;

using Services.Interfaces;
using Shared.DTOs.Customers;

public static class CustomerController
{

    /// <summary>
    /// MapCustomerAPI
    /// </summary>
    /// <param name="app"></param>
    public static void MapCustomerAPI(this WebApplication app)
    {

        app.MapGet("/api/customers", async (ICustomerService customerService)
         => await customerService.GetCustomersAsync());

        app.MapGet("/api/customers/{username}", async (string username, ICustomerService customerService)
            =>
        {
            var customer = await customerService.GetCustomerByUsernameAsync(username);
            return customer != null ? Results.Ok(customer) : Results.NotFound();
        });

        app.MapGet("/api/customers/by-id/{userId}", async (int userId, ICustomerService customerService)
    =>
        {
            var customer = await customerService.GetCustomerByUserIdAsync(userId);
            return customer != null ? Results.Ok(customer) : Results.NotFound();
        });


        app.MapPost("/api/customers/create", async (CreateCustomerDto customerDto, ICustomerService customerService)
            => await customerService.CreateCustomerAsync(customerDto));

        app.MapPut("/api/customers/update/{userId}", async (int userId, UpdateCustomerDto customerDto, ICustomerService customerService)
            => await customerService.UpdateCustomerAsync(userId, customerDto));

        app.MapDelete("/api/customers/delete/{userId}", async (int userId, ICustomerService customerService)
        => await customerService.DeleteCustomerAsync(userId));
    }
}
