using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Abstraction;
using Moq;

namespace ir.anka.LifeTraders.Trader.Test.PaymentAggregate;

public class PaymentTestProvider
{
    public Mock<IPaymentValidator> paymentValidator;
    public Mock<ISharedValidator> sharedValidator;

    public PaymentTestProvider()
    {
        paymentValidator = new Mock<IPaymentValidator>();
        sharedValidator = new Mock<ISharedValidator>();
    }
}