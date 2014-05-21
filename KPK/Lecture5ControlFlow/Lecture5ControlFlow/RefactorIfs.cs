using System;

namespace Lecture5ControlFlow
{
    public class RefactorIFs
    {

        private void FirstIf()
        {

            Vegetable potato = new Potato();

            if (potato != null && potato.HasBeenPeeled && potato.IsNotRotten)
            {
                Cook(potato);
            }
        }

        private void Cook(Vegetable vegetable)
        {
            //...
        }

        private void SecondIf(int x, int y)
        {
            const int MinX = 1,
                MaxX = 2,
                MinY = 5,
                MaxY = 10;
            bool shouldVisitCell = true;
            bool xIsInBoundries = (MinX <= x && x <= MaxX);
            bool yIsInBoundries = (MinY <= y && y <= MaxY);

            if (shouldVisitCell && xIsInBoundries && yIsInBoundries)
            {
                VisitCell();
            }
        }

        private void VisitCell()
        {
            //...
        }
    }

}
