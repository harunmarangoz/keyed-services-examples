using DependencyInjection.Services.Constants;
using DependencyInjection.Services.Services.Abstract;
using DependencyInjection.Services.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedScoped<IPaymentService, PayPalPaymentService>(PaymentConstants.PayPal);
builder.Services.AddKeyedScoped<IPaymentService, StripePaymentService>(PaymentConstants.Stripe);

var app = builder.Build();
app.MapGet("/pay/paypal",
    ([FromKeyedServices(PaymentConstants.PayPal)] IPaymentService paymentService) =>
    {
        paymentService.ProcessPayment();
        return Results.Ok();
    });

var serviceProvider = builder.Services.BuildServiceProvider();
var paymentService = serviceProvider.GetKeyedService<IPaymentService>(PaymentConstants.PayPal);

app.MapGet("/pay/stripe",
    ([FromKeyedServices(PaymentConstants.Stripe)] IPaymentService paymentService) =>
    {
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.Run();