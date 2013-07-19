using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwhindEntity.Client
{
    public class CustomerData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public CustomerData(string id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Title = null;
            this.Address = null;
            this.City = null;
            this.Postal = null;
            this.Country = null;
            this.Phone = null;
            this.Fax = null;
        }

        public CustomerData(string id, string name, string title, string address,
               string city, string postal, string country, string phone, string fax)
            : this(id, name)
        {
            this.Title = title;
            this.Address = address;
            this.City = city;
            this.Postal = postal;
            this.Country = country;
            this.Phone = phone;
            this.Fax = fax;
        }
    }
}
