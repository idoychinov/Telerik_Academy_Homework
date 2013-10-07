using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Problem 5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    // Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
    // Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, 
    // clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.


    class GenericList<T>
    {
        private T[] list;

        public GenericList(int initialElementsCount)
        {
            list = new T[initialElementsCount];
        }

    }
}
