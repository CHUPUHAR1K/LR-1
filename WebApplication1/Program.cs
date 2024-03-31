using Microsoft.AspNetCore.Mvc;
using System;

public class Company
{
    public string Name { get; set; }
    public int YearFounded { get; set; }
    public double Profit { get; set; }
}

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private static readonly Random _random = new Random();

    [HttpGet("info")]
    public ActionResult<Company> GetCompanyInfo()
    {
        var company = new Company
        {
            Name = "Example Company",
            YearFounded = 2024,
            Profit = 1337.0
        };

        return Ok(company);
    }

    [HttpGet("randomNumber")]
    public ActionResult<int> GetRandomNumber()
    {
        int randomNumber = _random.Next(0, 101);

        return Ok(randomNumber);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();

        app.MapRazorPages();
        app.MapControllers();

        app.Run();
    }
}
