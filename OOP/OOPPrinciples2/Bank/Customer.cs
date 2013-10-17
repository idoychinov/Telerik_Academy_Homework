using System;

namespace Bank
{
    public class Customer
    {
        public CustomerType Type { get; private set; }
        public string Id {get; private set;}

        public Customer(CustomerType type, string id)
        {
            this.Type=type;
            this.Id = id;
        }
    }
}
