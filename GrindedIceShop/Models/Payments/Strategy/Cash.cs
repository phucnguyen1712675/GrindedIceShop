using System;
using System.Globalization;

namespace GrindedIceShop.Models.Payments.Strategy
{
    public class Cash : IPayment
    {
        public override string ToString() => this.GetType().Name;

        public string ExecutePaymentLogic(decimal amount)
            => $"Step 1: Ask customer to give the amount to be paid ({amount.ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat)} đồng){Environment.NewLine}Step 2: Check if the received amount is enough{Environment.NewLine}Step 3: Refund if needed";
    }
}
