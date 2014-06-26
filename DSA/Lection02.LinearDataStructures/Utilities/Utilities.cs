namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Utilities
    {
        public static string ListToString<T>(List<T> list)
        {
            StringBuilder result = new StringBuilder(list.Count * 4);
            result.Append("[");
            foreach (var item in list)
            {
                result.Append(item);
                result.Append(",");
            }

            result[result.Length - 1] = ']';
            return result.ToString();
        }
    }
}
