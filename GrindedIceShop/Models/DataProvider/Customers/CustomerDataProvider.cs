using GrindedIceShop.Models.Customers;
using GrindedIceShop.Models.Customers.FacetedBuilder;
using System.Collections.Generic;

namespace GrindedIceShop.Models.DataProvider.Customers
{
    public static class CustomerDataProvider
    {
        public static List<Customer> GetData() =>
            new List<Customer>
            {
                new CustomerBuilderFacade()
                    .Info
                        .WithName("Nguyễn Hữu Khang")
                        .WithPhoneNumber("0988123456")
                    .Account
                        .WithEmail("khangff@gmail.com")
                        .WithPoint(60)
                    .Address
                        .InCity("Sài Gòn")
                        .AtAddress("277 Nguyễn Văn Cừ, phường 16, Quận 5")
                    .Build(),
                new CustomerBuilderFacade()
                    .Info
                        .WithName("Lê Thị Thúy Uyên")
                        .WithPhoneNumber("0951631113")
                    .Account
                        .WithEmail("uyenle@gmail.com")
                        .WithPoint(290)
                    .Address
                        .InCity("Sài Gòn")
                        .AtAddress("13/2 Ngô Gia Tự, phường 14, Quận 11")
                    .Build(),
                new CustomerBuilderFacade()
                    .Info
                        .WithName("Nguyễn Gia Huy")
                        .WithPhoneNumber("0909991543")
                    .Account
                        .WithEmail("hhuygian@gmail.com")
                        .WithPoint(115)
                    .Address
                        .InCity("Sài Gòn")
                        .AtAddress("226/12/1 Trần Hưng Đạo B, phường 1, Quận 5")
                    .Build(),
                new CustomerBuilderFacade()
                    .Info
                        .WithName("Nguyễn Hoàng Yến Nhi")
                        .WithPhoneNumber("0986614733")
                    .Account
                        .WithEmail("nhibanchan@gmail.com")
                        .WithPoint(10)
                    .Address
                        .InCity("Sài Gòn")
                        .AtAddress("90/7 Hoàng Hoa Thám, phường 9, Quận Bình Thạnh")
                    .Build()
            };
    }
}
