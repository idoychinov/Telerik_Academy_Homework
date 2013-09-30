using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneApplication
{
    //Problem 1. Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) 
    //and display characteristics (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

    class GSM
    {
        private static GSM iPhone4S = new GSM("iPhone 4S", "Apple");
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery batteryCharacteristics;
        private Display displayCharacteristics;

        //Problem 2. Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). 
        //Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery batteryCharacteristics, Display displayCharacteristics)
            : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.BatteryCharacteristics = batteryCharacteristics;
            this.DisplayCharacteristics = displayCharacteristics;
        }


        // Problem 6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        // Problem 5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. Ensure all fields hold correct data at any given time.

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("A GSM must have model!");
                }
                if (value.Length > 50 || value.Length < 1)
                {
                    throw new ArgumentOutOfRangeException("Model name must between 1 and 50 symbols");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error! A GSM must have Manufacturer!");
                }
                if (value.Length > 50 || value.Length < 1)
                {
                    throw new ArgumentOutOfRangeException("Error! Model name must between 1 and 50 symbols");
                }

                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value != null)
                {
                    decimal roundedPrice;
                    roundedPrice = Math.Round((decimal)value, 2);
                    this.price = roundedPrice;
                }
                else
                {
                    this.price = null;
                }
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        if (!char.IsLetter(item))
                        {
                            throw new ArgumentException("Error! Owner name must contain only letters.");
                        }
                    }
                }

                this.owner = value;
            }
        }

        public Battery BatteryCharacteristics
        {
            get
            {
                return this.batteryCharacteristics;
            }
            set
            {
                this.batteryCharacteristics = value;
            }
        }

        public Display DisplayCharacteristics
        {
            get
            {
                return this.displayCharacteristics;
            }
            set
            {
                this.displayCharacteristics = value;
            }
        }

        // Problem 9. Add a property CallHistory in the GSM class to hold a list of the performed calls. Try to use the system class List<Call>.
        private List<Call> callHistory = new List<Call>();
        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                this.callHistory = value;
            }
        }
        // Problem 4. Add a method in the GSM class for displaying all information about it. Try to override ToString().

        public override string ToString()
        {
            StringBuilder GSMFullInformation = new StringBuilder();
            GSMFullInformation.AppendLine("GSM:");
            GSMFullInformation.AppendLine("Model: " + this.Model);
            GSMFullInformation.AppendLine("Manufacturer: " + this.Manufacturer);
            if (this.price != null)
            {
                GSMFullInformation.AppendLine("Price: " + this.Price);
            }
            if (this.owner != null)
            {
                GSMFullInformation.AppendLine("Owner: " + this.Owner);
            }
            if (this.batteryCharacteristics != null)
            {
                GSMFullInformation.AppendLine(this.BatteryCharacteristics.ToString());
            }
            if (this.displayCharacteristics != null)
            {
                GSMFullInformation.AppendLine(this.DisplayCharacteristics.ToString());
            }

            return GSMFullInformation.ToString();
        }

        // Problem 10. Add methods in the GSM class for adding and deleting calls from the calls history. Add a method to clear the call history.

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public void DeleteCall(int callIndex)  // 1 based index
        {
            if (callIndex > this.CallHistory.Count || callIndex < 1)
            {
                throw new ArgumentOutOfRangeException("Error! There is no call with index " + callIndex);
            }
            this.CallHistory.RemoveAt(callIndex - 1);
        }

        public void ClearCallHistory()
        {
            callHistory.Clear();
        }

        // Problem 11. Add a method that calculates the total price of the calls in the call history. Assume the price per minute is fixed and is provided as a parameter.

        public decimal TotalCallPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0;
            foreach (var item in CallHistory)
            {
                totalPrice += (pricePerMinute / 60M) * (decimal)item.Duration;
            }
            return totalPrice;
        }
    }
}
