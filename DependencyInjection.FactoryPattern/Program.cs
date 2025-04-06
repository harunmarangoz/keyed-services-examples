using DependencyInjection.FactoryPattern.Factories;
using DependencyInjection.Services.Constants;
using DependencyInjection.Services.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<PaymentFactory>();
builder.Services.AddScoped<PayPalPaymentService>();
builder.Services.AddScoped<StripePaymentService>();

var app = builder.Build();

app.MapGet("/pay/paypal",
    ([FromServices] PaymentFactory paymentFactory) =>
    {
        var paymentService = paymentFactory.CreatePaymentService(PaymentConstants.PayPal);
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.MapGet("/pay/stripe",
    ([FromServices] PaymentFactory paymentFactory) =>
    {
        var paymentService = paymentFactory.CreatePaymentService(PaymentConstants.Stripe);
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.Run();