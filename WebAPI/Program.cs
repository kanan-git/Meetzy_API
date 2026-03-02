using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.AspNetCore.Cors;

using Business;
using DAL;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddWebAPIConfigurations(builder.Configuration);
builder.Services.AddBusinessConfigurations();
builder.Services.AddDALConfigurations(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()  // Allow all origins
               .AllowAnyMethod()  // Allow all HTTP methods (GET, POST, PUT, DELETE)
               .AllowAnyHeader(); // Allow all headers
    });
}); // Add CORS policy here

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}
app.UseCors("AllowAllOrigins");  // Enable CORS with the policy
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
