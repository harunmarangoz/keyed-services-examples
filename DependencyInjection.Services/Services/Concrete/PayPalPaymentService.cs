using DependencyInjection.Services.Services.Abstract;

namespace DependencyInjection.Services.Services.Concrete;

public class PayPalPaymentService : IPaymentService
{
    public void ProcessPayment() => Console.WriteLine("Payed with PayPal.");
}