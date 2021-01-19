using System;
using System.Globalization;

namespace GrindedIceShop.Models.Payments.Strategy
{
    public class ZaloPay : IPayment
    {
        public override string ToString() => this.GetType().Name;

        public string ExecutePaymentLogic(decimal amount)
            => $"Step 1: Ask customer to open {this}{Environment.NewLine}Step 2: Customer enter the amount to be paid ({amount.ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat)} đồng){Environment.NewLine}Step 3: Customer scan {this}'s QR Code of our Shop{Environment.NewLine}Step 4: Check result";
    }
}
