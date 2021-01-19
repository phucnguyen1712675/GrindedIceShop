using GrindedIceShop.Models.Bills;
using GrindedIceShop.Models.Bills.FluentBuilder;
using System;
using System.Collections.Generic;

namespace GrindedIceShop.Models.DataProvider.Bills
{
    public static class BillDataProvider
    {
        public static List<Bill> GetData() =>
            new List<Bill>
            {
                BillBuilderDirector
                .NewBill
                .AtDate(DateTime.ParseExact("2020-11-14", "yyyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))
                .Receive(78000m)
                .ByCashier(0)
                .OfCustomer(1)
                .Build(),
                BillBuilderDirector
                .NewBill
                .AtDate(DateTime.ParseExact("2020-12-5", "yyyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))
                .Receive(224000m)
                .ByCashier(1)
                .OfCustomer(2)
                .Build(),
                BillBuilderDirector
                .NewBill
                .AtDate(DateTime.ParseExact("2020-12-22", "yyyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))
                .Receive(121000m)
                .ByCashier(1)
                .OfCustomer(2)
                .Build(),
            };
    }
}
