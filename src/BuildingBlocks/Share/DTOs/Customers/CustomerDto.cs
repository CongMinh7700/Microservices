﻿namespace Shared.DTOs.Customers;

public class CustomerDto
{
    public long Id { get; set; }

    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? EmailAddress { get; set; }
}
