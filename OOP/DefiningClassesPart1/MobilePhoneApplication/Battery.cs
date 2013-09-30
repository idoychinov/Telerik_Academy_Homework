using System;
using System.Text;

namespace MobilePhoneApplication
{
    //Problem 1. Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) 
    //and display characteristics (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

    class Battery
    {
        // Problem 3. Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.
        public enum BatteryType { LiIon, NiMH,NiCd, LiPol}

        private string model;
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType? type;

        //Problem 2. Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). 
        //Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

        public Battery(string model)
        {
            this.Model = model;
        }

        public Battery(string model, ushort? hoursIdle, ushort? hoursTalk,BatteryType? type)
            : this(model)
        {
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
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
                    throw new ArgumentNullException("A Battery must have model!");
                }
                if (value.Length > 50 || value.Length < 1)
                {
                    throw new ArgumentOutOfRangeException("Model name must between 1 and 50 symbols");
                }

                this.model = value;
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value!=null&&(value < 1 || value > 5000))
                {
                    throw new ArgumentOutOfRangeException("Error! Value must be between 1 and 5000 hours");
                }
                this.hoursIdle = value;
            }
        }

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value!=null&&(value < 1 || value > 5000))
                {
                    throw new ArgumentOutOfRangeException("Error! Value must be between 1 and 5000 hours");
                }
                this.hoursTalk = value;
            }
        }

        public BatteryType? Type
        {
            get
            {
                return this.type;
            }
            set
            {
                
                if (value!=null&&((int)value < 0 || (int)value > 3))
                {
                    throw new ArgumentOutOfRangeException("Error! Not a valid Battery type");
                }
                this.type = value;
            }
        }

        // Problem 4. Add a method in the GSM class for displaying all information about it. Try to override ToString().

        public override string ToString()
        {
            StringBuilder batteryFullInformation = new StringBuilder();
            batteryFullInformation.AppendLine("Battery Model:" + this.Model);
            
            if (this.hoursIdle != null)
            {
                batteryFullInformation.AppendLine("Battery hours idle: " + this.HoursIdle);
            }
            if (this.hoursTalk != null)
            {
                batteryFullInformation.AppendLine("Battery hours talk: " + this.HoursTalk);
            }
            if (this.type != null)
            {
                batteryFullInformation.AppendLine("Battery type: " + this.Type);
            }
           
            return batteryFullInformation.ToString();
        }
    }
}
