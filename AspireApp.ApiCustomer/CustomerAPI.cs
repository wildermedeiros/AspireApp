using AspireApp.ApiCustomer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using AspireApp.ApiCustomer.Model;

namespace AspireApp.ApiCustomer;

public static class CustomerAPI
{
    public static RouteGroupBuilder MapCustomerAPI (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Customer").WithTags(nameof(Customer));

        group.MapGet("/", async (CustomerContext db) =>
        {
            return await db.Customer.ToListAsync();
        })
        .WithName("GetAllCustomers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Customer>, NotFound>> (int id, CustomerContext db) =>
        {
            return await db.Customer.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Customer model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCustomerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Customer customer, CustomerContext db) =>
        {
            var affected = await db.Customer
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Name, customer.Name)
                    .SetProperty(m => m.LastName, customer.LastName)
                    .SetProperty(m => m.Email, customer.Email)
                    .SetProperty(m => m.PhoneNumber, customer.PhoneNumber)
                    .SetProperty(m => m.DateOfBirth, customer.DateOfBirth)
                    .SetProperty(m => m.Adress, customer.Adress)
                    .SetProperty(m => m.ClientSince, customer.ClientSince)
                    .SetProperty(m => m.Balance, customer.Balance)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCustomer")
        .WithOpenApi();

        group.MapPost("/", async (Customer customer, CustomerContext db) =>
        {
            db.Customer.Add(customer);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Customer/{customer.Id}", customer);
        })
        .WithName("CreateCustomer")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, CustomerContext db) =>
        {
            var affected = await db.Customer
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCustomer")
        .WithOpenApi();

        return group;
    }
}

