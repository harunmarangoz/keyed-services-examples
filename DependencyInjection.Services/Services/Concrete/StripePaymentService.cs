using DependencyInjection.Services.Services.Abstract;

namespace DependencyInjection.Services.Services.Concrete;

public class StripePaymentService : IPaymentService
{
    public void ProcessPayment() => Console.WriteLine("Payed with Stripe.");
}