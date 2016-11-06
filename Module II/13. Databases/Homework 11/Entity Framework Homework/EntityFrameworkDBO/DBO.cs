using System.Linq;

namespace EntityFrameworkDBO
{
    public static class DAO
    {
        public static void AddCustomer(
            string customerId, 
            string companyName, 
            string contactName, 
            string contactTitle, 
            string address, 
            string city, 
            string region, 
            string postalCode, 
            string country, 
            string phone, 
            string fax)
        {
            using (var db = new NorthwindEntities())
            {
                db.Customers.Add(new Customer
                {
                    CustomerID = customerId,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                });

                db.SaveChanges();
            }
        }

        public static void ModifyCustomer(
            string customerId, 
            string companyName, 
            string contactName,
            string contactTitle, 
            string address, 
            string city, 
            string region,
            string postalCode, 
            string country, 
            string phone, 
            string fax)
        {
            using (var db = new NorthwindEntities())
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);

                if (!string.IsNullOrWhiteSpace(companyName))
                {
                    customer.CompanyName = companyName;
                }

                if (!string.IsNullOrWhiteSpace(contactName))
                {
                    customer.ContactName = contactName;
                }

                if (!string.IsNullOrWhiteSpace(contactTitle))
                {
                    customer.ContactTitle = contactTitle;
                }

                if (!string.IsNullOrWhiteSpace(address))
                {
                    customer.Address = address;
                }

                if (!string.IsNullOrWhiteSpace(city))
                {
                    customer.City = city;
                }

                if (!string.IsNullOrWhiteSpace(region))
                {
                    customer.Region = region;
                }

                if (!string.IsNullOrWhiteSpace(postalCode))
                {
                    customer.PostalCode = postalCode;
                }

                if (!string.IsNullOrWhiteSpace(country))
                {
                    customer.Country = country;
                }

                if (!string.IsNullOrWhiteSpace(phone))
                {
                    customer.Phone = phone;
                }

                if (!string.IsNullOrWhiteSpace(fax))
                {
                    customer.Fax = fax;
                }

                db.SaveChanges();
            }
        }

        public static void DeleteCustomer(string customerId)
        {
            using (var db = new NorthwindEntities())
            {
                db.Customers.Remove(db.Customers.FirstOrDefault(c => c.CustomerID == customerId));

                db.SaveChanges();
            }
        }
    }
}
