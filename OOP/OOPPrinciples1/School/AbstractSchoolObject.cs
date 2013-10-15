using System;

namespace School
{
    public abstract class AbstractSchoolObject
    {
        private string optionalComment;

        public string OptionalComment
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.optionalComment))
                {
                    return string.Empty;
                }
                else
                {
                    return this.optionalComment;
                }
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.optionalComment = string.Empty;
                }
                else
                {
                    this.optionalComment = value;
                }
            }
        }


    }
}
