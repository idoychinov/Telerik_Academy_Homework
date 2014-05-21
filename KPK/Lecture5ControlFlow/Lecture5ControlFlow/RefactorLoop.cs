using System;

namespace Lecture5ControlFlow
{
    public class RefactorLoop
    {
        private void RefactoredLoop(int[] array, int expectedValue)
        {
            bool valueFound=false;
            bool isTenMultiplyer;

            for (int currentElement = 0; currentElement < 100; currentElement++)
            {
                Console.WriteLine(array[currentElement]);
                isTenMultiplyer = (currentElement % 10 == 0);

                if (isTenMultiplyer && (array[currentElement] == expectedValue))
                {
                    valueFound=true;
                    break;
                }
            }
            // More code here
            if (valueFound)
            {
                Console.WriteLine("Value Found");
            }

        }
    }
}
