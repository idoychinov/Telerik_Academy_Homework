namespace Task11LinkedList
{
    using System;

    /// <summary>
    /// Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and 
    /// NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).
    /// </summary>
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
