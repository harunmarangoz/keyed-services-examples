using DependencyInjection.Services.Constants;
using DependencyInjection.Services.Services.Abstract;
using DependencyInjection.Services.Services.Concrete;

namespace DependencyInjection.FactoryPattern.Factories;

public class PaymentFactory(IServiceProvider serviceProvider)
{
    public IPaymentService CreatePaymentService(string paymentType)
    {
        return paymentType switch
        {
            PaymentConstants.Stripe => serviceProvider.GetRequiredService<StripePaymentService>(),
            PaymentConstants.PayPal => serviceProvider.GetRequiredService<PayPalPaymentService>(),
            _ => throw new ArgumentException("Invalid payment type", nameof(paymentType))
        };
    }
}