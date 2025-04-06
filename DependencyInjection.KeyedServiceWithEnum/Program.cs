using DependencyInjection.Services.Services.Abstract;
using DependencyInjection.Services.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedScoped<IPaymentService, PayPalPaymentService>(PaymentType.Paypal);
builder.Services.AddKeyedScoped<IPaymentService, StripePaymentService>(PaymentType.Stripe);

var app = builder.Build();
app.MapGet("/pay/paypal",
    ([FromKeyedServices(PaymentType.Paypal)] IPaymentService paymentService) =>
    {
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.MapGet("/pay/stripe",
    ([FromKeyedServices(PaymentType.Stripe)] IPaymentService paymentService) =>
    {
        paymentService.ProcessPayment();
        return Results.Ok();
    });

app.Run();

enum PaymentType
{
    Paypal,
    Stripe
}