using System;

namespace MobilePhoneApplication
{

    //Problem 8. Create a class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).

    public class Call
    {
        private string dialedPhone;
        private int duration;
        public DateTime DateAndTime { get; set; }
        public string DialedPhone
        {
            get
            {
                return this.dialedPhone;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Error! Dialed Phone cannot be empty.");
                }
                foreach (var item in value)
                {
                    if (!char.IsDigit(item))
                    {
                        throw new ArgumentOutOfRangeException("Error! Phone must consist only of digits");
                    }
                }
                this.dialedPhone = value;
            }
        }
        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Error! Duration must be positive number");
                }
                this.duration = value;
            }
        }

        public Call(DateTime dateAndTime, string dailedPhone, int duration)
        {
            this.DateAndTime = dateAndTime;
            this.DialedPhone = dailedPhone;
            this.Duration = duration;
        }
    }
}
