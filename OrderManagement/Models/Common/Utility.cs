using System;
using System.Collections.Generic;
using OrderManagement.Models.Membership;
using OrderManagement.Models.Products;

namespace OrderManagement.Models.Common
{
    public static class Utility
    {
        public static List<ShippingInfo> GetShippingData()
        {
            List<ShippingInfo> shippingInfo = new List<ShippingInfo>();
            shippingInfo.Add(new ShippingInfo()
            {
                MemberId = 1,
                Address1 = "Bangalore",
                Address2 = "Mysore",
                Phone = "1234567890",
                Email = "test123"
            });

            shippingInfo.Add(new ShippingInfo()
            {
                MemberId = 2,
                Address1 = "Bangalore",
                Address2 = "Mysore",
                Phone = "1234567890",
                Email = "test123"
            });

            shippingInfo.Add(new ShippingInfo()
            {
                MemberId = 3,
                Address1 = "Bangalore",
                Address2 = "Mysore",
                Phone = "1234567890",
                Email = "test123"
            });
            return shippingInfo;
        }

        public static List<Member> GetMemberData()
        {
            List<Member> members = new List<Member>();

            members.Add(new Member()
            {
                Id = 1,
                Name = "Meera",
                Address1 = "Bangalore",
                Address2 = "Mysore",
                Phone = "1234567890",
                Email = "meeramohanjm@gmail.com"
            });
            members.Add(new Member()
            {
                Id = 2,
                Name = "Meera1",
                Address1 = "Bangalore1",
                Address2 = "Mysore1",
                Phone = "1234567890",
                Email = "meeramohanjm@gmail.com"
            });
            members.Add(new Member()
            {
                Id = 3,
                Name = "Meera1",
                Address1 = "Bangalore1",
                Address2 = "Mysore1",
                Phone = "1234567890",
                Email = "meeramohanjm@gmail.com"
            });
            return members;

        }

        public static List<Product> GetProductData()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product()
            {
                Id = 1,
                Description = "HTML",
                UnitPrice = 50,
                productType = ProductType.Book
            });


            products.Add(new Product()
            {
                Id = 2,
                Description = "Learning to Ski",
                UnitPrice = 50,
                productType = ProductType.Book
            });

            products.Add(new Product()
            {
                Id = 3,
                Description = "FirstAid",
                UnitPrice = 50,
                productType = ProductType.Book
            });

            return products;
        }
    }
}
