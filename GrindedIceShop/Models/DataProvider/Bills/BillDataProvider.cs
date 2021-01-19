using GrindedIceShop.Models.Bills;
using GrindedIceShop.Models.Bills.FluentBuilder;
using GrindedIceShop.Models.Bills.Strategy;
using GrindedIceShop.Models.Payments.Strategy;
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
                .AtDate(DateTime.Now)
                .Receive(78000m)
                .ByCashier(1)
                .OfCustomer(1)
                .PaidByPayment(new Momo())
                .WithStatus(BillStatus.UnFinished)
                .WithMenuItems(null)
                .Build(),
                BillBuilderDirector
                .NewBill
                .AtDate(DateTime.Now)
                .Receive(224000m)
                .ByCashier(1)
                .OfCustomer(2)
                .PaidByPayment(new ZaloPay())
                .WithStatus(BillStatus.UnFinished)
                .WithMenuItems(null)
                .Build(),
                BillBuilderDirector
                .NewBill
                .AtDate(DateTime.Now)
                .Receive(121000m)
                .ByCashier(1)
                .OfCustomer(3)
                .PaidByPayment(new Cash())
                .WithStatus(BillStatus.UnFinished)
                .WithMenuItems(null)
                .Build()
            };

        /*public static List<Bill> GetData()
        {
            var list = new List<Bill>();
            list.Add(BillBuilderDirector
                .NewBill
                .AtDate(DateTime.Now)
                .Receive(78000m)
                .ByCashier(1)
                .OfCustomer(1)
                //.PaidByPayment(new Momo())
                //.WithStatus(BillStatus.UnFinished)
                .Build());
            *//*list.Add(BillBuilderDirector
                .NewBill
                .AtDate(DateTime.Now)
                .Receive(224000m)
                .ByCashier(1)
                .OfCustomer(2)
                .PaidByPayment(new ZaloPay())
                .WithStatus(BillStatus.UnFinished)
                .Build());
            list.Add(BillBuilderDirector
                .NewBill
                .AtDate(DateTime.Now)
                .Receive(121000m)
                .ByCashier(1)
                .OfCustomer(3)
                .PaidByPayment(new Cash())
                .WithStatus(BillStatus.UnFinished)
                .Build());*//*
            return list;
        }*/
    }
}
