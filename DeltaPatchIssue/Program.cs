using DeltaPatchIssue.Cache;
using DeltaPatchIssue.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddControllers()
    .AddOData(options => options.Select()
        .OrderBy()
        .Filter()
        .Count()
        .EnableQueryFeatures()
        .AddRouteComponents("odata", GetEdmModel(), new DefaultODataBatchHandler()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

IEdmModel GetEdmModel()
{
    var oDataConventionModelBuilder = new ODataConventionModelBuilder();
    oDataConventionModelBuilder.EntitySet<SomeSystem>("SomeSystem");
    return oDataConventionModelBuilder.GetEdmModel();
}