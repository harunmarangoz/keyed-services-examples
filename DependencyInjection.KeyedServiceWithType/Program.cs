using DependencyInjection.Services.Services.Abstract;
using DependencyInjection.Services.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedScoped<IPaymentService, PayPalPaymentService>(typeof(PayPalPaymentService));
builder.Services.AddKeyedScoped<IPaymentService, StripePaymentService>(typeof(StripePaymentService));

var app = builder.Build();

app.MapGet("/pay/paypal",
    ([FromKeyedServices(typeof(PayPalPaymentService))] IPaymentService paymentService) =>
    {
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.MapGet("/pay/stripe",
    ([FromKeyedServices(typeof(StripePaymentService))] IPaymentService paymentService) =>
    {
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.Run();