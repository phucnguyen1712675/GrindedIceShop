using GrindedIceShop.Models.Payments.Strategy;
using System.Collections.Generic;

namespace GrindedIceShop.Models.Payments.Factory
{
    public sealed class PaymentFactory
    {
        private readonly Dictionary<string, IPayment> _payments;

        private PaymentFactory()
        {
            _payments = new Dictionary<string, IPayment>
            {
                { "Cash", new Cash() },
                { "Momo", new Momo() },
                { "ZaloPay", new ZaloPay() }
            };
        }

        public IPayment this[string paymentName]
        {
            get => _payments[paymentName];
            set => _payments[paymentName] = value;
        }

        public static PaymentFactory InitializeFactory() => new PaymentFactory();
    }
}
