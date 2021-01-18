using GrindedIceShop.Models.Customers;
using GrindedIceShop.Models.DataProvider.Customers;
using System;
using System.Collections.Generic;

namespace GrindedIceShop.Models.Data.ThreadSafeSingleton
{
    public sealed class CustomerDataContainer : ISingletonContainer
    {
        private readonly Dictionary<int, Customer> _customers = new Dictionary<int, Customer>();
        private readonly Dictionary<string, Customer> _customersWithPhoneNumberKey = new Dictionary<string, Customer>();

        private static readonly Lazy<CustomerDataContainer> instance = new Lazy<CustomerDataContainer>(() => new CustomerDataContainer());

        private CustomerDataContainer()
        {
            var customers = CustomerDataProvider.GetData();
            customers.ForEach(customer => _customers.Add(customer.CustomerId, customer));
            customers.ForEach(customer => _customersWithPhoneNumberKey.Add(customer.PhoneNumeber, customer));
        }

        public dynamic GetById(int id) => _customers[id];

        public Customer GetByPhoneNumber(string phoneNumber) => _customersWithPhoneNumberKey[phoneNumber];

        public static CustomerDataContainer Instance => instance.Value;
    }
}
