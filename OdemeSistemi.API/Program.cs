using Microsoft.AspNetCore.Mvc;
using OdemeSistemi.Business.Services;
using OdemeSistemi.Core.Abstract;
using OdemeSistemi.Data.Concrate;
using System.Runtime.ConstrainedExecution;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<KrediKartiOdeme>(); //Her talepte yeni bir nesne oluþturulur. Bu, iþ mantýðýnýn esnekliðini korur.
builder.Services.AddTransient<EftOdeme>(); // Her talepte yeni bir nesne oluþturulur. Bu, iþ mantýðýnýn esnekliðini korur.

builder.Services.AddScoped<IOdemeStratejisiFabrikasi, OdemeStratejisiFabrikasi>(); //Her Http isteði için bir kez oluþturur.kurumsal servisler için sýkça tercih edilir.
builder.Services.AddScoped<SiparisService>(); //Her Http isteði için bir kez oluþturur.kurumsal servisler için sýkça tercih edilir.

// Controller'larý ve diðer API servislerini ekle
builder.Services.AddControllers();

// Swagger/OpenAPI desteði (Opsiyonel ama iyi bir pratik)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Bu, swagger adresinde UI'ý gösterir.
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

//Controller'larý haritala
app.MapControllers();
app.Run();

