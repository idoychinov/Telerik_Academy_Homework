using System;
using System.Text;

namespace MobilePhoneApplication
{
    //Problem 1. Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) 
    //and display characteristics (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
    
    class Display
    {
        private string size;
        private long? numberOfColors;

        //Problem 2. Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). 
        //Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

        public Display(string size, long? numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public Display(string size)
            : this(size, null)
        {
        }

        public Display(long? numberOfColors)
            : this(null, numberOfColors)
        {
        }

        public Display()
            : this(null, null)
        {
        }

        // Problem 5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. Ensure all fields hold correct data at any given time.

        public string Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public long? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                this.numberOfColors = value;
            }
        }

        // Problem 4. Add a method in the GSM class for displaying all information about it. Try to override ToString().

        public override string ToString()
        {
            StringBuilder displayFullInformation = new StringBuilder();

            if (this.Size != null)
            {
                displayFullInformation.AppendLine("Display size: " + this.Size);
            }
            if (this.NumberOfColors != null)
            {
                displayFullInformation.AppendLine("Display number of colors: " + this.NumberOfColors);
            }
            
            return displayFullInformation.ToString();
        }
    }
}
