using DependencyInjection.Services.Services.Abstract;
using DependencyInjection.Services.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPaymentService, PayPalPaymentService>();
builder.Services.AddScoped<IPaymentService, StripePaymentService>();

var app = builder.Build();

app.MapGet("/pay/paypal",
    ([FromServices] IEnumerable<IPaymentService> paymentServices) =>
    {
        var paymentService = paymentServices
            .FirstOrDefault(x => x.GetType() == typeof(PayPalPaymentService));
        if (paymentService == null) return Results.NotFound("PayPal payment service not found.");
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.MapGet("/pay/stripe",
    ([FromServices] IEnumerable<IPaymentService> paymentServices) =>
    {
        var paymentService = paymentServices.FirstOrDefault(x => x.GetType() == typeof(StripePaymentService));
        if (paymentService == null) return Results.NotFound("Stripe payment service not found.");
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.Run();