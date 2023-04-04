using System;
using Librarian.Application;
using Librarian.Infrastructure.EntityFramework;
using Librarian.WebAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.ApplicationDependencyInjection();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql();

builder.Services.AddDbContext<LibraryContext>(opt => opt
    .UseLazyLoadingProxies().UseInMemoryDatabase("Library"));

builder.Services.SeedDatabase();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();