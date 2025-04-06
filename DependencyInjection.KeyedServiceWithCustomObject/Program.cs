using DependencyInjection.Services.Constants;
using DependencyInjection.Services.Services.Abstract;
using DependencyInjection.Services.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedTransient<IPaymentService, PayPalPaymentService>(new PaymentServiceKey(PaymentConstants.PayPal, 1));
builder.Services.AddKeyedTransient<IPaymentService, StripePaymentService>(new PaymentServiceKey(PaymentConstants.Stripe, 1));

var app = builder.Build();

app.MapGet("/pay/paypal",
    ([FromServices] IServiceProvider serviceProvider) =>
    {
        var paymentService = serviceProvider
            .GetRequiredKeyedService<IPaymentService>(new PaymentServiceKey(PaymentConstants.PayPal, 1));
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.MapGet("/pay/stripe",
    ([FromServices] IServiceProvider serviceProvider) =>
    {
        var paymentService = serviceProvider
            .GetRequiredKeyedService<IPaymentService>(new PaymentServiceKey(PaymentConstants.Stripe, 1));
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.Run();

record PaymentServiceKey(string Type, int Version);