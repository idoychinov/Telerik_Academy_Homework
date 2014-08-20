namespace Task11LinkedList
{
    using System;

    public class Task11LinkedList
    {
        public static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.FirstElement = new ListItem<int>(43);
            list.FirstElement.NextItem = new ListItem<int>(32);
            list.FirstElement.NextItem.NextItem = new ListItem<int>(21);

            ListItem<int> current;
            current = list.FirstElement;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.NextItem;
            }
        }
    }
}
