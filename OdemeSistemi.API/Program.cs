using Microsoft.AspNetCore.Mvc;
using OdemeSistemi.Business.Services;
using OdemeSistemi.Core.Abstract;
using OdemeSistemi.Data.Concrate;
using OdemeSistemi.Core.Concrate;
using System.Runtime.ConstrainedExecution;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<KrediKartiOdeme>(); //Her talepte yeni bir nesne olu�turulur. Bu, i� mant���n�n esnekli�ini korur.
builder.Services.AddTransient<EftOdeme>(); // Her talepte yeni bir nesne olu�turulur. Bu, i� mant���n�n esnekli�ini korur.


builder.Services.AddScoped<IOdemeStratejisiFabrikasi, OdemeStratejisiFabrikasi>(); //Her Http iste�i i�in bir kez olu�turur.kurumsal servisler i�in s�k�a tercih edilir.
builder.Services.AddScoped<SiparisService>(); //Her Http iste�i i�in bir kez olu�turur.kurumsal servisler i�in s�k�a tercih edilir.

// Controller'lar� ve di�er API servislerini ekle
builder.Services.AddControllers();

// Swagger/OpenAPI deste�i (Opsiyonel ama iyi bir pratik)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Bu, swagger adresinde UI'� g�sterir.
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

//Controller'lar� haritala
app.MapControllers();
app.Run();

